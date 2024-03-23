using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beta.Dogtas.HR.Budget.Model.ObjectModel
{
    public class Title
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short? IsActive { get; set; }
    }
}
