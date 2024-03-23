using System.Collections.Generic;

namespace Beta.Dogtas.HR.Budget.Model.DataModel
{
    using ObjectModel;
    public class UnitOp
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public CostUnit Unit { get; set; }
        public List<CostAccount> Accounts { get; set; }
        public bool IsActive { get; set; }
    }
}
