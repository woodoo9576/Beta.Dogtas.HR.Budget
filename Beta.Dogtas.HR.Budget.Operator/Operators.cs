using System.Collections.Generic;
using Beta.Dogtas.HR.Budget.DataAccess.Concrete.Data;
using Beta.Dogtas.HR.Budget.Model.DataModel;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;

namespace Beta.Dogtas.HR.Budget.Operator
{
    public class Operators
    {
        public void CreateSalary(int year, int month, Employee emp, CostUnit unit, List<CostAccount> accounts)
        {
            var salary = new EmployeeOp {Year = year, Month = month, Employee = emp, Unit = unit, Accounts = accounts};
            var op = new EmployeeOpDA();
            op.Create(salary);
        }

        public void CreateAccount(CostAccount acoount)
        {
            
        }
    }
}
