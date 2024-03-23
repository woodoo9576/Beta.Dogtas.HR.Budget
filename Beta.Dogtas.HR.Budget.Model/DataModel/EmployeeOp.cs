using System.Collections.Generic;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;

namespace Beta.Dogtas.HR.Budget.Model.DataModel;

public class EmployeeOp
{
    public int ID { get; set; }
    public int? Year { get; set; }
    public int? Month { get; set; }
    public Employee Employee { get; set; }
    public CostUnit Unit { get; set; }
    public List<CostAccount> Accounts { get; set; }
    public bool IsActive { get; set; }
}