using DataAccessLayer;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace BusinessLogicLayer
{
    public class DofDE : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICategory, CategoryOperations>();
            Container.RegisterType<IDifficultyLevel, DifficultyLevelOperations>();
            Container.RegisterType<IQuestionBank, QuestionBankOperations>();
            Container.RegisterType<ISubCategory, SubCategoryOperations>();
            Container.RegisterType<ITest, TestOperations>();
            Container.RegisterType<ITopic, TopicOperations>();
            Container.RegisterType<IUser, UserOperations>();
            Container.RegisterType<IUserTest, UserTestOperations>();
            Container.RegisterType<IReports, ReportOperations>();
            Container.RegisterType<ITestGenerate, TestGenerateOperations>();
        }
    }
}
