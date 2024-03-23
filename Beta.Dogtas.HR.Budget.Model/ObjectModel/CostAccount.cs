using Beta.Dogtas.HR.Budget.Model.DataModel;
using Beta.Dogtas.HR.Budget.Model.EnumTypes;

namespace Beta.Dogtas.HR.Budget.Model.ObjectModel
{
    public class CostAccount
    {
        private Collar? _collar;
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public FactorType FactorType { get; set; }
        public double? Amount { get; set; }

        public CostAccount ToFactorAccount { get; set; }

        public Collar? Collar
        {
            get { return _collar ?? EnumTypes.Collar.All; }
            set
            {
                _collar = _collar == null ? EnumTypes.Collar.All : value;
            }
        }
        public bool IsActive { get; set; }
    }
}
