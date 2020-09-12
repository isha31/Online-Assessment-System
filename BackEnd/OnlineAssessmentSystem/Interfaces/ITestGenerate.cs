using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITestGenerate
    {
        List<QuestionFuctionReturn> QuestionSubTopicSpecific(QuestionFunction type);

        bool GenerateUserTest(GenerateUserTestFunction type);
    }
}
