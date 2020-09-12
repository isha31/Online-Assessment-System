using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DifficultyLevelOperations : IDifficultyLevel
    {
        readonly OASContext ctx = new OASContext();
        string exceptionMessage;
        public List<DifficultyLevel> GetAllDifficultyLevels()
        {
            List<DifficultyLevel> categories = new List<DifficultyLevel>();
            try
            {
                categories = ctx.DifficultyLevels.ToList();
                return categories;
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
            return categories;
        }

        public DifficultyLevel GetDifficultyLevelDetails(int id)
        {
            DifficultyLevel existingDifficultyLevel = new DifficultyLevel();
            try
            {
                existingDifficultyLevel = ctx.DifficultyLevels.FirstOrDefault(category => category.DifficultyLevelID == id);
                return existingDifficultyLevel;
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
            return existingDifficultyLevel;
        }
    }
}
