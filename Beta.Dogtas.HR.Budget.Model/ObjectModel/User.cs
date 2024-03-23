using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beta.Dogtas.HR.Budget.Model.ObjectModel
{
    public class User
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public UserLevel UserLevel { get; set; }
        public string PassWord { get; set; }
        public string PassWordSalt { get; set; }
    }
}
