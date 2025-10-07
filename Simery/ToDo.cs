using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simery
{
    public class ToDo
    {

        public string CaseName;
        public DateTime? TimeOfCompleating;
        public string Description;

        

        public ToDo(string caseName, DateTime? timeOfCompleating, string description)
        {
            CaseName = caseName;
            TimeOfCompleating = timeOfCompleating;
            Description = description;
        }

    }
}
