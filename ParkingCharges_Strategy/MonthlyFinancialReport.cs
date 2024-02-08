using System;
using System.Collections.Generic;


namespace SE_Assignment
{
    public class MonthlyFinancialReport
    {
        // Attributes
        private string reportType;
        private DateTime monthYear;
        private string reportSummary;
        private List<ParkingRecord> parkingRecords; // Association


        // Constructor
        public MonthlyFinancialReport(string reportType, DateTime monthYear, string reportSummary)
        {
            this.reportType = reportType;
            this.monthYear = monthYear;
            this.reportSummary = reportSummary;
            this.parkingRecords = new List<ParkingRecord>();
        }

        // Method to add a parking record to the report
        public void AddParkingRecord(ParkingRecord record)
        {
            parkingRecords.Add(record);
        }

        // Operation: Generate Report
        public string GenerateReport()
        {
            // Implementation of report generation logic
            // You can customize this according to your requirements
            string report = "Monthly Financial Report\n";
            report += $"Report Type: {reportType}\n";
            report += $"Month-Year: {monthYear.ToString("MM/yyyy")}\n";
            report += $"Report Summary: {reportSummary}\n";

            // Adding parking records
            report += "\nParking Records:\n";
            foreach (var record in parkingRecords)
            {
                report += $"{record}\n";
            }

            return report;
        }

    }
}
