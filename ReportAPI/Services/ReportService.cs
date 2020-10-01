using AspNetCore.Reporting;
using Report.Data;
using ReportAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Services
{
    public class ReportService : IReportService
    {
        public byte[] GenerateReportAsync(string reportName)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ReportAPI.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(rdlcFilePath);

            List<UserDto> userList = new List<UserDto>();
            userList.Add(new UserDto
            {
                FirstName = "Alex",
                LastName = "Smith",
                Email = "alex.smith@gmail.com",
                Phone = "2345334432"
            });

            userList.Add(new UserDto
            {
                FirstName = "John",
                LastName = "Legend",
                Email = "john.legend@gmail.com",
                Phone = "5633435334"
            });

            userList.Add(new UserDto
            {
                FirstName = "Stuart",
                LastName = "Jones",
                Email = "stuart.jones@gmail.com",
                Phone = "3575328535"
            });

            report.AddDataSource("dsUsers", userList);
            var result = report.Execute(GetRenderType("pdf"), 1, parameters);
            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = RenderType.Pdf;
                    break;
                case "word":
                    renderType = RenderType.Word;
                    break;
                case "excel":
                    renderType = RenderType.Excel;
                    break;
            }

            return renderType;
        }
    }
}
