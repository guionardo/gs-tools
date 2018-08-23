using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GS.Tools
{
    /// <summary>
    /// Log class to journalize yours infos
    /// </summary>
    public class Log
    {
        private static Calendar _cal;
        private static string _system;
        private static string _vendor;
        private string _filename;
        private string _folder;
        private int _grouptextmaxlength = 10;
        private int _maxLogs = 10;
        private string _timestampformat;
        private TimeStampType _timestamptype;
        static Log()
        {
            _vendor = Application.CompanyName;
            if (string.IsNullOrEmpty(_vendor))
                _vendor = "Guiosoft";
            _system = Application.ProductName;
            if (string.IsNullOrEmpty(_system))
                _system = "GS.Tools";

            _cal = DateTimeFormatInfo.CurrentInfo.Calendar;
        }

        public Log(string fileName, LocationLog locationLog = LocationLog.LogFolder, TimeStampType timestampType = TimeStampType.JustTime, FileNameSuffixLog suffixLog = FileNameSuffixLog.Date, int maxLogs = 10)
        {
            TimeStampType = timestampType;
            LocationLog = locationLog;
            FileNameSuffix = suffixLog;
            _maxLogs = maxLogs;

            if (!string.IsNullOrEmpty(Path.GetDirectoryName(fileName)))
            {
                LocationLog = LocationLog.Custom;
                _folder = Path.GetDirectoryName(fileName);
                _filename = Path.GetFileNameWithoutExtension(fileName);
            }
            else
            {
                _filename = Path.GetFileNameWithoutExtension(fileName);
                switch (locationLog)
                {
                    case LocationLog.Custom:
                    case LocationLog.SameFolder:
                        _folder = ".";
                        break;
                    case LocationLog.LogFolder:
                        _folder = "./log";
                        break;
                    case LocationLog.ProgramDataFolder:
                        _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), _vendor, _system);
                        break;
                }
                _folder = Path.GetFullPath(_folder);
            }
            LastException = "";
            if (!Directory.Exists(_folder))
            {
                try
                {
                    Directory.CreateDirectory(_folder);
                }
                catch (Exception e)
                {
                    LastException = e.Message;
                    throw new LogException("Erro ao criar diretório " + _folder, e);
                }
                if (!Directory.Exists(_folder))
                    throw new LogException("Diretório " + _folder + " não foi encontrado");
            }
        }

        ~Log()
        {
            Purge();
        }
        public FileNameSuffixLog FileNameSuffix { get; set; }

        public int GroupTextMaxLength { get => _grouptextmaxlength; set { if (value >= 0 && value <= 20) _grouptextmaxlength = value; } }

        public string LastException { get; private set; } = "";

        public LocationLog LocationLog { get; }

        public TimeStampType TimeStampType
        {
            get => _timestamptype; set
            {
                switch (value)
                {
                    case TimeStampType.JustTime:
                        _timestampformat = "HHmmss";
                        break;
                    case TimeStampType.JustTimeSeparator:
                        _timestampformat = "HH:mm:ss";
                        break;
                    case TimeStampType.JustTimeMilliseconds:
                        _timestampformat = "HHmmss.fff";
                        break;
                    case TimeStampType.JustTimeSeparatorMilliseconds:
                        _timestampformat = "HH:mm:ss.fff";
                        break;
                    case TimeStampType.DateTime:
                        _timestampformat = "yyyyMMddHHmmss";
                        break;
                    case TimeStampType.DateTimeSeparator:
                        _timestampformat = "yyyy-MM-dd HH:mm:ss";
                        break;
                    case TimeStampType.DateTimeMilliseconds:
                        _timestampformat = "yyyyMMddHHmmss.fff";
                        break;
                    case TimeStampType.DateTimeSeparatorMilliseconds:
                        _timestampformat = "yyyy-MM-dd HH:mm:ss.fff";
                        break;
                }
                _timestamptype = value;
            }
        }

        public bool Add(string logText, string groupText = null)
        {
            if (string.IsNullOrEmpty(logText))
                return false;
            var l = logText.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (l.Length == 0)
                return false;
            string ts = DateTime.Now.ToString(_timestampformat);
            groupText = " " + (groupText ?? "").PadRight(GroupTextMaxLength).Substring(0, GroupTextMaxLength);
            for (int i = 0; i < l.Length; i++)
                l[i] = ts + groupText + " " + l[i];
            string fileName = _filename;
            switch (FileNameSuffix)
            {
                case FileNameSuffixLog.None:
                    fileName = _filename;
                    break;
                case FileNameSuffixLog.Date:
                    fileName = _filename + "." + DateTime.Now.ToString("yyyyMMdd");
                    break;
                case FileNameSuffixLog.YearMonth:
                    fileName = _filename + "." + DateTime.Now.ToString("yyyyMM");
                    break;
                case FileNameSuffixLog.YearMonthWeek:
                    fileName = _filename + "." + DateTime.Now.ToString("yyyyMM.") +
                        (_cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday) -
                        _cal.GetWeekOfYear(DateTime.Now.AddDays(-DateTime.Now.Day - 1), CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday)).ToString("D2");
                    break;
                case FileNameSuffixLog.YearWeek:
                    fileName = _filename + "." + DateTime.Now.ToString("yyyy.") +
                    _cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday).ToString("D2");
                    break;
            }
            fileName = Path.Combine(_folder, fileName + ".log");
            try
            {
                File.AppendAllLines(fileName, l);
                LastException = "";
                return true;
            }
            catch (Exception e)
            {
                LastException = e.Message;
                return false;
            }
        }

        public void Purge(int maxLogs = -999)
        {
            if (maxLogs == -999)
                maxLogs = _maxLogs;
            if (maxLogs <= 0)
                return;
            try
            {
                var logs = Directory.GetFiles(_folder, _filename + "*.*", SearchOption.TopDirectoryOnly);
                if (logs.Length <= maxLogs)
                    return;
                for (int i = 0; i < logs.Length - maxLogs; i++)
                    try
                    {
                        File.Delete(logs[i]);
                    }
                    catch { }
            }
            catch { }
        }
    }
}
