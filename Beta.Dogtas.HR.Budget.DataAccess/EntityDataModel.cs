using System.Data.Entity;
using Beta.Dogtas.HR.Budget.Model.DataModel;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;


namespace Beta.Dogtas.HR.Budget.DataAccess;

public class EntityDataModel() : DbContext("name=EntityDataModel")
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
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CostAccount>().ToTable("CostAccount").HasKey(k=>k.ID);
        modelBuilder.Entity<CostUnit>().ToTable("CostUnit");
        modelBuilder.Entity<Employee>().ToTable("Employee");
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<Title>().ToTable("Title");
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<UserLevel>().ToTable("UserLevel");

        modelBuilder.Entity<EmployeeOp>().ToTable("EmployeeOp");
        modelBuilder.Entity<LocationOp>().ToTable("LocationOp");
        modelBuilder.Entity<UnitOp>().ToTable("UnitOp");
        modelBuilder.Entity<TitleOp>().ToTable("TitleOp");
        modelBuilder.Entity<Salary>().ToTable("Salary");
    }
}