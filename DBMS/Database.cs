using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public class Database
    {
            public string Name { get; set; }
            public List<Table> Tables { get; set; } = new List<Table>();

            public Database(string name)
            {
                Name = name;
            }

    }
}
