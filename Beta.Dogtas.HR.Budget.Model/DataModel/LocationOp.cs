using System.Collections.Generic;
using Beta.Dogtas.HR.Budget.Model.EnumTypes;

namespace Beta.Dogtas.HR.Budget.Model.DataModel
{
    using ObjectModel;
    public class LocationOp
    {
        public int ID { get; set; }                                                       
        public int Year { get; set; }
        public int Month { get; set; }
        public Location Location { get; set; }
        public Title Title { get; set; }
        public Collar Collar { get; set; }
        public List<CostAccount> Accounts { get; set; }
        public bool IsActive { get; set; }
    }
}