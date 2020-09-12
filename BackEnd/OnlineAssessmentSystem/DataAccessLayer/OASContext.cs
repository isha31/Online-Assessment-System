using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OASContext: DbContext
    {
        public OASContext()
            : base("name=OASDatabase")
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }

        public DbSet<UserTest> UserTests { get; set; }




    }
}
