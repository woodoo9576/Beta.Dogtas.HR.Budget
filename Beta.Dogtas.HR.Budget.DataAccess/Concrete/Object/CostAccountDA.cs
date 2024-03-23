﻿using Beta.Dogtas.HR.Budget.DataAccess.Abstract.Object;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;
using Beta.Dogtas.HR.Budget.Repository.EFRepositories;

namespace Beta.Dogtas.HR.Budget.DataAccess.Concrete.Object
{
    public class CostAccountDA : EFRepository<CostAccount, EntityDataModel>, ICostAccountDA
    {
    }
}