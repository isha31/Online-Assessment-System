using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IQuestionBank
    {
        List<QuestionBank> GetAllQuestionBanks();
        QuestionBank GetQuestionBankDetails(int id);
        int CreateQuestionBank(int id);
        int UpdateQuestionBank(QuestionBank questionBank);
        int DeleteQuestionBank(int id);

    }
}
