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
    public class BLTestGenerate: ITestGenerate
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        readonly TestGenerateOperations _testgenerate_object;
        public BLTestGenerate()
        {
            _testgenerate_object = new TestGenerateOperations();
        }
        public List<QuestionFuctionReturn> QuestionSubTopicSpecific( QuestionFunction type)
        {
            List<QuestionFuctionReturn> tests = new List<QuestionFuctionReturn>();
            try
            {
                tests = _testgenerate_object.QuestionSubTopicSpecific(type);
                if (tests != null)
                {
                    return tests;
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
            return tests;
        }

        public bool GenerateUserTest( GenerateUserTestFunction type)
        {
            bool result = false;
            try
            {
                result = _testgenerate_object.GenerateUserTest(type);
                if (result !=false)
                {
                    return result;
                }
                else
                {
                    throw new OASCustomException("Test failed to generate.");
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
    }
}
