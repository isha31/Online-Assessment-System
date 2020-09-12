using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class OASCustomException:ApplicationException
    {
        public OASCustomException()
        {
        }

        public OASCustomException(string message) : base(message)
        {
        }

        public OASCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}
