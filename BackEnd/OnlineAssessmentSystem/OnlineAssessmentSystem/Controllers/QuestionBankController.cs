using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace OnlineAssessmentSystem.Controllers
{
    public class QuestionBankController : ApiController
    {
        [HttpPost]      
        public IHttpActionResult PostQuestionBank()
        {
            string excelFile = null;
            var httpRequest = HttpContext.Current.Request;
            string filePath = string.Empty;
           // var postedFile = httpRequest.Files["Excel"];
            var postedFile = httpRequest.Files[0];
            try
            {
                if (ModelState.IsValid)
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
                                TopicID = Convert.ToInt32(row["TopicID"])

                            });
                        }
                        ctx.SaveChanges();
                        return Ok();

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(FileNotFoundException)
            {
                return BadRequest(ModelState);
            }

        }
    }
}
