using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GS.Tools;
using GS.Tools.Extensions;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestCategory("Log")]
        [TestMethod]
        public void TestLog_YearMonthWeek()
        {
            var l = new Log("teste.log", suffixLog: FileNameSuffixLog.YearMonthWeek, timestampType: TimeStampType.JustTimeMilliseconds);
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

        [TestMethod]
        public void TestExtensionsString()
        {
            Console.WriteLine("ContainsOne = " + ("hello world".ContainsOne(new string[] { "Hello", "Earth", "World" }, true)));
            Console.WriteLine("Justnumbers = " + "ABC1234DEF9999".JustNumbers());
            Console.WriteLine("PhoneNumber = " + "4730419009".PhoneNumber());
            Console.WriteLine("RemoveAccents = " + "Não quero ver nenhum áçento põr aquí".RemoveAccents());
            foreach (var d in new string[] { "2018-02-09", "01022020", "05/02/1977", "7/2/2004" })
                Console.WriteLine("ToDate(" + d + ") = " + d.ToDate());
            foreach (var d in new string[] {
                "2018-02-09",
                "01022020",
                "05/02/1977",
                "7/2/2004",
                "2018-03-04 00:20:21",
                "10:00:12",
                "5:2",
                "01/02/2003 01:02:03"
            })
                Console.WriteLine("ToDateTime(" + d + ") = " + d.ToDateTime());

            Console.WriteLine("ToDecimal = " + "10.23".ToDecimal());
            Console.WriteLine("ToDecimal = " + "10,113".ToDecimal());
            Console.WriteLine("ToDouble = " + "10.23".ToDouble());
            Console.WriteLine("ToDouble = " + "10,113".ToDouble());
            Console.WriteLine("ToInt = " + "10".ToInt());

            foreach (var d in new string[] { "14:00:21", "16:23", "6:9" })
                Console.WriteLine("ToTime(" + d + ") = " + d.ToTime());
        }

        [TestMethod]
        public void TestExtensionsNumber()
        {
            double do1 = 12.2983, do2 = 12.291;

            Console.WriteLine(string.Format("Equals (double) ({0} , {1}) = {2}", do1, do2, do1.Equivalent(do2,mode:Numbers.EqualsTestMode.Round)));
            Console.WriteLine(string.Format("Equals (double) ({0} , {1}) = {2}", do1, do2, do1.Equivalent(do2, mode: Numbers.EqualsTestMode.Truncate)));

            decimal de1 = 12.0195m, de2 = 12.01m;
            Console.WriteLine(string.Format("Equals (decimal) ({0} , {1}) = {2}", de1, de2, de1.Equivalent(de2, mode: Numbers.EqualsTestMode.Round)));
            Console.WriteLine(string.Format("Equals (decimal) ({0} , {1}) = {2}", de1, de2, de1.Equivalent(de2, mode: Numbers.EqualsTestMode.Truncate)));

            Console.WriteLine(string.Format("IsBetween({0},{1},{2}) = {3}", (int)4, 2, 9, 4.IsBetween(2, 9)));
            Console.WriteLine(string.Format("IsBetween({0},{1},{2}) = {3}", (double)4, 5, 9, ((double)4).IsBetween(5, 9)));
            Console.WriteLine(string.Format("IsBetween({0},{1},{2}) = {3}", (decimal)2, 1, 9, ((decimal)2).IsBetween(1, 9)));

            Console.WriteLine(string.Format("ForceInterval({0},{1},{2}) = {3}", 10, 4, 5, 10.ForceInterval(4, 5)));
            Console.WriteLine(string.Format("ForceInterval({0},{1},{2}) = {3}", (double)1, 4, 5, ((double)1).ForceInterval(4, 5)));
            Console.WriteLine(string.Format("ForceInterval({0},{1},{2}) = {3}", (decimal)3, 4, 5, ((decimal)3).ForceInterval(4, 5)));

            Console.WriteLine(string.Format("IsZero({0}) = {1}", 0.0001, ((double)0.0001).IsZero()));
            Console.WriteLine(string.Format("IsZero({0}) = {1}", 0.01, ((decimal)0.01).IsZero()));

            Console.WriteLine(string.Format("{0} = {1}", 1548, 1548.ToBytes()));
            Console.WriteLine(string.Format("{0} = {1}", 1000, 1000.ToBytes()));
            Console.WriteLine(string.Format("{0} = {1}", 248456848465, 248456848465.ToBytes()));

            Console.WriteLine(string.Format("{0} = {1}", 109032.02090, (109032.02090).ToInvariantString()));
        }

    }
}
