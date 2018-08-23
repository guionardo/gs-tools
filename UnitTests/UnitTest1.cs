using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GS.Tools;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("Log")]
        [TestMethod]
        public void TestLog_YearMonthWeek()
        {
            var l = new Log("teste.log",suffixLog:FileNameSuffixLog.YearMonthWeek,timestampType:TimeStampType.JustTimeMilliseconds);
            l.Add("TESTE DE LINHA\nLinha2", "Grupo");
        }
        [TestCategory("Log")]
        [TestMethod]
        public void TestLog_YearWeek()
        {
            var l = new Log("teste.log", suffixLog: FileNameSuffixLog.YearWeek, timestampType: TimeStampType.JustTimeSeparatorMilliseconds);
            l.Add("TESTE DE LINHA", "Grupo");
        }
        [TestCategory("Log")]
        [TestMethod]
        public void TestLog_YearMonth()
        {
            var l = new Log("teste.log", suffixLog: FileNameSuffixLog.YearMonth, timestampType: TimeStampType.DateTime);
            l.Add("TESTE DE LINHA", "Grupo");
        }
        [TestCategory("Log")]
        [TestMethod]
        public void TestLog_Date()
        {
            var l = new Log("teste.log", suffixLog: FileNameSuffixLog.Date, timestampType: TimeStampType.DateTimeMilliseconds);
            l.Add("TESTE DE LINHA", "Grupo");
        }
    }
}
