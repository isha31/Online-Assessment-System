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
    public class BLQuestionBank: IQuestionBank
    {
        readonly QuestionBankOperations _questionbank_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BLQuestionBank()
        {
            _questionbank_object = new QuestionBankOperations();
        }
        public List<QuestionBank> GetAllQuestionBanks()
        {
            List<QuestionBank> questionbanks = new List<QuestionBank>();
            try
            {
                questionbanks = _questionbank_object.GetAllQuestionBanks();
                if (questionbanks != null)
                {
                    return questionbanks;
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
            return questionbanks;
        }
        public QuestionBank GetQuestionBankDetails(int id)
        {
            QuestionBank existingQuestionBank = new QuestionBank();
            try
            {
                existingQuestionBank = _questionbank_object.GetQuestionBankDetails(id);
                if (existingQuestionBank != null)
                {
                    return existingQuestionBank;
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
            return existingQuestionBank;
        }
        public int CreateQuestionBank(int id)
        {
            int result = 0;
            try
            {
                result = _questionbank_object.CreateQuestionBank(id);
                if (result >0)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
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
            return result;
        }
        public int UpdateQuestionBank(QuestionBank questionBank)
        {
            int result = 0;
            try
            {
                result = _questionbank_object.UpdateQuestionBank(questionBank);
              
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
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
            return result;
        }
        public int DeleteQuestionBank(int id)
        {
            int result = 0;
            try
            {
                result = _questionbank_object.DeleteQuestionBank(id);
            
                if (result>0)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Operation failed.");
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
            return result;
        }

        public List<AdminQuestionBank> GetAllAdminQuestionBanks()
        {
            List<AdminQuestionBank> questionbanks = new List<AdminQuestionBank>();
            try
            {
                questionbanks = _questionbank_object.GetAllAdminQuestionBanks();
                if (questionbanks!=null)
                {
                    return questionbanks;
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
            return questionbanks;
        }

    }
}
