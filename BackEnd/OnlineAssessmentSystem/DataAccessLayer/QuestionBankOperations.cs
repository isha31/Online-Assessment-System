using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer
{
    public class QuestionBankOperations: IQuestionBank
    {
        readonly OASContext ctx = new OASContext();
        string exceptionMessage;
        public List<QuestionBank> GetAllQuestionBanks()
        {
            List<QuestionBank> questionbanks = new List<QuestionBank>();
            
            try
            {
                questionbanks = ctx.QuestionBanks.ToList();
                return questionbanks;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return questionbanks;
        }
        public QuestionBank GetQuestionBankDetails(int id)
        {
            QuestionBank existingQuestionBank = new QuestionBank();
           
            try
            {
                existingQuestionBank = ctx.QuestionBanks.FirstOrDefault(questionbank => questionbank.QuestionBankID == id);
                return existingQuestionBank;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return existingQuestionBank;
        }

        public int CreateQuestionBank(int id)
        {
            int result = 0;
            string excelFile = null;
            var httpRequest = HttpContext.Current.Request;
            string filePath = string.Empty;
            
            var postedFile = httpRequest.Files[0];

            try
            {
                if (postedFile != null)
                {
                    string path = HttpContext.Current.Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    excelFile = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                    excelFile = excelFile + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                    filePath = path + excelFile;

                    postedFile.SaveAs(filePath);
                    string extension = Path.GetExtension(postedFile.FileName);
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                        default:
                            break;

                    }

                    DataTable dt = new DataTable();
                    conString = string.Format(conString, filePath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();
                            }
                        }
                    }

                    //Insert records to database table.
                    OASContext ctx = new OASContext();
                    foreach (DataRow row in dt.Rows)
                    {
                        ctx.QuestionBanks.Add(new QuestionBank
                        {
                            QuestionBankID = Convert.ToInt32(row["QuestionBankID"]),
                            Question = Convert.ToString(row["Question"]),
                            Option1 = Convert.ToString(row["Option1"]),
                            Option2 = Convert.ToString(row["Option2"]),
                            Option3 = Convert.ToString(row["Option3"]),
                            Option4 = Convert.ToString(row["Option4"]),
                            Answer = Convert.ToString(row["Answer"]),
                            Marks = Convert.ToInt32(row["Marks"]),
                            DifficultyLevelID = Convert.ToInt32(row["DifficultyLevelID"]),
                            //TopicID = Convert.ToInt32(row["TopicID"])
                            TopicID=id

                        });
                    }
                    result=ctx.SaveChanges();
                    
                }
                else
                {
                    return result;
                }
               
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }
        public int UpdateQuestionBank(QuestionBank questionBank)
        {
            int result = 0;
            
            try
            {

                QuestionBank existingQuestionBank = ctx.QuestionBanks.FirstOrDefault(questionbanks => questionbanks.QuestionBankID == questionbanks.QuestionBankID);
                if (existingQuestionBank != null)
                {
                    existingQuestionBank.Question = questionBank.Question;
                    existingQuestionBank.Option1 = questionBank.Option1;
                    existingQuestionBank.Option2 = questionBank.Option2;
                    existingQuestionBank.Option3 = questionBank.Option3;
                    existingQuestionBank.Option4 = questionBank.Option4;
                    existingQuestionBank.Answer = questionBank.Answer;
                    existingQuestionBank.DifficultyLevelID = questionBank.DifficultyLevelID;
                    existingQuestionBank.TopicID = questionBank.TopicID;
                    existingQuestionBank.Marks = questionBank.Marks;

                    result = ctx.SaveChanges();
                }
                return result;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }
        public int DeleteQuestionBank(int id)
        {
            int result = 0;
          
            try
            {

                var existingQuestionBank = ctx.QuestionBanks.FirstOrDefault(questionbanks => questionbanks.QuestionBankID == id);
                if (existingQuestionBank != null)
                {
                    ctx.QuestionBanks.Remove(existingQuestionBank);
                    result = ctx.SaveChanges();
                }
                return result;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return result;
        }


        public List<AdminQuestionBank> GetAllAdminQuestionBanks()
        {
            List<AdminQuestionBank> questionbanks = new List<AdminQuestionBank>();

            try
            {
                var questions = from qb in ctx.QuestionBanks join diff in ctx.DifficultyLevels on qb.DifficultyLevelID equals diff.DifficultyLevelID join top in ctx.Topics on qb.TopicID equals top.TopicID
                                select new { Qid = qb.QuestionBankID,Question=qb.Question, option1 = qb.Option1, option2 = qb.Option2, option3 = qb.Option3, option4 = qb.Option4, ans = qb.Answer, Marks = qb.Marks,Difflevel=diff.DifficultyLevelName,topic=top.TopicName};
                foreach (var adminqb in questions)
                {

                    questionbanks.Add(new AdminQuestionBank()
                    {
                        QuestionBankID=adminqb.Qid,
                        Question = adminqb.Question,
                        Option1 = adminqb.option1,
                        Option2 = adminqb.option2,
                        Option3 = adminqb.option3,
                        Option4 = adminqb.option4,
                        Answer = adminqb.ans,
                        Marks = adminqb.Marks,
                        DifficultyLevel = adminqb.Difflevel,
                        Topic = adminqb.topic
                    });
                }

                return questionbanks;
            }
            catch (SqlException sqlex)
            {
                exceptionMessage = sqlex.Message;
            }
            catch (OASCustomException customex)
            {
                exceptionMessage = customex.Message;
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            return questionbanks;
        }
    }

}

