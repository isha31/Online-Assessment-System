using DataAccessLayer;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLReport:IReports
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        readonly ReportOperations _report_object;

        public BLReport()
        {
            _report_object = new ReportOperations();
        }

       
        public List<ReportMarks> GetTopicReport(string id)
            {
            List<ReportMarks> marks = new List<ReportMarks>();
            try
            {
                marks = _report_object.GetTopicReport(id);
                if (marks != null)
                {
                    return marks;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
              
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return marks;
        }

        public List<SubCategoryReportMarks> GetSubCategoryReport(string id)
        {
            List<SubCategoryReportMarks> marks = new List<SubCategoryReportMarks>();
            try
            {
                marks = _report_object.GetSubCategoryReport(id);
                if (marks != null)
                {
                    return marks;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return marks;
        }

        public List<CategoryReportMarks> GetCategoryReport(string id)
        {
            List<CategoryReportMarks> marks = new List<CategoryReportMarks>();
            try
            {
                marks = _report_object.GetCategoryReport(id);
                if (marks != null)
                {
                    return marks;
                }
                else
                {
                    throw new OASCustomException("Null data encountered.");
                }
            }
            catch (SqlException sqlex)
            {
                log.Error(sqlex);
            }
            catch (OASCustomException customex)
            {
                log.Error(customex.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return marks;
        }


        }
    }
