using System.Data.Entity;
using Beta.Dogtas.HR.Budget.Model.DataModel;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;


namespace Beta.Dogtas.HR.Budget.DataAccess;

public class EntityDataModel : DbContext
{
    /// <summary>
    ///     ObjectModels
    /// </summary>
    public virtual DbSet<CostAccount> CostAccounts { get; set; }

    public virtual DbSet<CostUnit> CostUnits { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Title> Titles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserLevel> UserLevels { get; set; }

    /// <summary>
    ///     DataModels
    /// </summary>
    public virtual DbSet<EmployeeOp> EmployeeOps { get; set; }

    public virtual DbSet<LocationOp> LocationOps { get; set; }
    public virtual DbSet<UnitOp> UnitOps { get; set; }
    public virtual DbSet<TitleOp> TitleOps { get; set; }
    public virtual DbSet<Salary> Salaries { get; set; }
    
    
}