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
    }
}
