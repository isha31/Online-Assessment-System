using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IReports
    {
        List<ReportMarks> GetTopicReport(string id);
        List<SubCategoryReportMarks> GetSubCategoryReport(string id);
        List<CategoryReportMarks> GetCategoryReport(string id);
    }
}
