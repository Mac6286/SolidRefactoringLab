using System;

namespace SolidRefactoringLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Choose the formatter (OCP)
            IReportFormatter formatter = new PdfFormatter();

            // 2. Pass it to the manager
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            // 3. Use the dedicated saver (SRP)
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }

    public class ReportManager
    {
        private readonly IReportFormatter _formatter;
        public string ReportData { get; set; }

        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }

    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    public interface IReportFormatter
    {
        public void FormatReport();
    }

    public class PdfFormatter : IReportFormatter
    {   
        public readonly string fileType = "PDF";
        public void FormatReport()
        {
            Console.WriteLine($"Formatting report as a {fileType}...");
        }
    }

    public class WordFormatter : IReportFormatter
    {
        public readonly string fileType = "Word Document";
        public void FormatReport()
        {
            Console.WriteLine($"Formatting report as a {fileType}...");
        }
    }

    public class PlainTextFormatter : IReportFormatter
    {
        public readonly string fileType = "plain text";
        public void FormatReport()
        {
            Console.WriteLine($"Formatting report as a {fileType}...");
        }
    }
}