using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITest
    {
        List<Test> GetAllTests();
        Test GetTestDetails(int id);
        int CreateTest(Test test);
        int UpdateTest(Test test);
        int DeleteTest(int id);

    }
}
