using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;

namespace Beta.Dogtas.HR.Budget.Model.DataModel
{
    public class Salary
    {
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public CostUnit CostUnit { get; set; }
        public List<CostAccount> CostAccounts { get; set; }}
}
