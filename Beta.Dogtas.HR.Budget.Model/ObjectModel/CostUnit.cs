namespace Beta.Dogtas.HR.Budget.Model.ObjectModel
{
    public class CostUnit
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public CostUnit ParentUnit { get; set; }
        public short? IsActive { get; set; }
    }
}
