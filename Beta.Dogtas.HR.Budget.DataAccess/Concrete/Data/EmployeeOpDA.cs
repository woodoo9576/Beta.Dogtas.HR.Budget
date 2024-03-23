using Beta.Dogtas.HR.Budget.DataAccess.Abstract.Data;
using Beta.Dogtas.HR.Budget.Model.DataModel;
using Beta.Dogtas.HR.Budget.Repository.EFRepositories;

namespace Beta.Dogtas.HR.Budget.DataAccess.Concrete.Data
{
    public class EmployeeOpDA : EFRepository<EmployeeOp, EntityDataModel>, IEmployeeOpDA
    {
    }
}