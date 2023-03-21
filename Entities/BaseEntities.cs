using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseEntities
    {
        public List<T> DataTblToList<T>(DataTable dt)
        {
            List <T>retVal=new List<T>();
            return retVal;
        }
    }
}
