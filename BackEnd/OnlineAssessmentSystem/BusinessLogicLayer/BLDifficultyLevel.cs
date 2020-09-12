using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BLDifficultyLevel : IDifficultyLevel
    {
        readonly DifficultyLevelOperations _level_object;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BLDifficultyLevel()
        {
            _level_object = new DifficultyLevelOperations();
        }

        public List<DifficultyLevel> GetAllDifficultyLevels()
        {
            List<DifficultyLevel> tests = new List<DifficultyLevel>();
            try
            {
                tests = _level_object.GetAllDifficultyLevels();
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
        public DifficultyLevel GetDifficultyLevelDetails(int id)
        {
            DifficultyLevel existingDifficultyLevel = new DifficultyLevel();
            try
            {
                existingDifficultyLevel = _level_object.GetDifficultyLevelDetails(id);

                if (existingDifficultyLevel != null)
                {
                    return existingDifficultyLevel;
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
            return existingDifficultyLevel;
        }

      
    }
}
