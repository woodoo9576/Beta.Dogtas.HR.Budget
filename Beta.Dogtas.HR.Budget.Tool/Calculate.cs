using System;
using System.Linq;
using System.Linq.Expressions;
using Beta.Dogtas.HR.Budget.DataAccess;
using Beta.Dogtas.HR.Budget.Model.DataModel;
using Beta.Dogtas.HR.Budget.Model.EnumTypes;
using Beta.Dogtas.HR.Budget.Model.ObjectModel;

namespace Beta.Dogtas.HR.Budget.Tool
{
    class Calculate
    {
        readonly EntityDataModel _context = new EntityDataModel();

        public void Salary(Employee emp, int year, int month)
        {
            var salary = new Salary { Employee = emp, Year = year, Month = month, CostUnit = emp.Unit };
            var employeeOp = _context.EmployeeOps.FirstOrDefault(p => p.Employee == emp);
            var unitOp = _context.UnitOps.FirstOrDefault(p => p.Unit == emp.Unit);
            var locationOp = _context.LocationOps.FirstOrDefault(p => p.Location == emp.Unit.Location);

            var costAccounts = _context.CostAccounts.ToList();


            // Öncelikle costAccount listesindeki her üye için kontrol sağlayacağız
            foreach (var costAccount in costAccounts)
            {
                
                //birinci sırada çalışan hesabında tanım varmı
                if (employeeOp == null)
                {
                    //çalışan hesabı boş bir üst seviye unite için hesabı kontrol edelim
                    if (unitOp == null)
                    {
                        //ünite hesabıda boş o halde bölge için hesabı kontrol edelim
                        if (locationOp == null)
                        {
                            //bölge hesaplarıda boş görünmekte o halde masraf hesabını boş olarak maaş hesaplarına ekleyelim
                            salary.CostAccounts.Add(costAccount);
                        }
                        else
                        {
                            //bölge hesabı boş değil o zaman yaka durumunuda kontrol edelim
                            var lacc = locationOp.Accounts.FirstOrDefault(
                                l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == Collar.All));
                            if (lacc != null)
                            {
                                salary.CostAccounts.Add(lacc);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        var lacc = unitOp.Accounts.FirstOrDefault(
                            l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == Collar.All));
                        if (lacc!=null)
                        {
                            salary.CostAccounts.Add(lacc);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                { //çalışan hesabında bu hesaba ait giriş var maaş hesabına ekleyelim
                    var lacc = employeeOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID);
                    //TODO:şimdi bu aşamada masraf hesabının dolu olup olmadıına bakmam gerekiyor
                    //TODO:ayrıca katsayı tipinin ne olduğuna bakıp hesabıda yapmam lazım

                    //hesap var tamam kontrol zamanı
                    if (lacc != null && lacc.Amount != null)
                    {
                        if (lacc.FactorType == FactorType.Ratio)
                        {
                            lacc.Amount = lacc.Amount * (
                                          employeeOp.Accounts.FirstOrDefault(l => l.ID == lacc.ToFactorAccount.ID ).Amount ?? 0);
                        }
                        salary.CostAccounts.Add(lacc);
                    }

                }

                //Eğer çalışan hesabında kayıt edilmiş bir masraf hesabı tanımı mevcutsa onu ilgili ay için maaş hesabına atıyoruz
                //if (employeeOp != null)
                //{
                //    var accc =
                //        employeeOp.Accounts.FirstOrDefault(
                //            l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == null));
                //    if (accc != null)
                //    {
                //        salary.CostAccounts.Add(accc);
                //    }
                //    else
                //    {
                //        if (unitOp != null)
                //        {
                //            accc = unitOp.Accounts.FirstOrDefault(
                //            l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == null));
                //            if (accc != null)
                //            {
                //                salary.CostAccounts.Add(accc);
                //            }
                //            else
                //            {
                //                if (locationOp != null)
                //                {
                //                    accc = locationOp.Accounts.FirstOrDefault(
                //                        l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == null));
                //                    salary.CostAccounts.Add(accc ?? costAccount);
                //                }
                //            }
                //        }
                //    }

                //}


                //if (employeeOp == null)
                //{
                //    if (unitOp == null)
                //    {
                //        if (locationOp == null)
                //        {
                //            salary.CostAccounts.Add(costAccount);
                //        }
                //        else
                //        {
                //            salary.CostAccounts.Add(
                //                locationOp.Accounts.DefaultIfEmpty(costAccount).FirstOrDefault(
                //                    l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == null)));

                //        }
                //    }
                //    else
                //    {
                //        salary.CostAccounts.Add(
                //            unitOp.Accounts.DefaultIfEmpty()
                //                .FirstOrDefault(
                //                    l => l.ID == costAccount.ID && (l.Collar == emp.Collar || l.Collar == null)));
                //    }
                //}

                //if (employeeOp == null) continue;
                //var eopAccount = employeeOp.Accounts.FirstOrDefault(p => p.ID == costAccount.ID && (p.Collar == emp.Collar || p.Collar == Collar.All));


                //if (unitOp == null) continue;
                //var uOpAccount = unitOp.Accounts.FirstOrDefault(p => p.ID == costAccount.ID && (p.Collar == emp.Collar || p.Collar == Collar.All));

                ////TODO: locationop a collar parametresi eklenmesi gerekiyor title başlığı ünvan için kullanılmaya başlanacak
                //if (locationOp == null) continue;
                //var lOpAccount = locationOp.Accounts.FirstOrDefault(p => p.ID == costAccount.ID && (p.Collar == emp.Collar || p.Collar == Collar.All));

                //CostAccount cacc = eopAccount ?? (uOpAccount ?? (lOpAccount ?? costAccount));
                // aşağıdaki if bloğunun yerine ternary yazdım performansa göre gerekirse tekrar if bloğunu çalıştırırım


                //salary.CostAccounts.Add(eopAccount ?? (uOpAccount ?? (lOpAccount ?? costAccount)));

                //salary.CostAccounts.Add(cacc);

                //if (eopAccount != null)
                //{
                //    salary.CostAccounts.Add(eopAccount);
                //}
                //else if (uOpAccount != null)
                //{
                //    salary.CostAccounts.Add(uOpAccount);
                //}
                //else if (lOpAccount != null)
                //{
                //    salary.CostAccounts.Add(lOpAccount);
                //}
                //else
                //{
                //    salary.CostAccounts.Add(costAccount);
                //}
            }

            _context.Salaries.Add(salary);
            _context.SaveChanges();
        }

    }



    //class BaseOptions
    //{
    //    readonly EntityDataModel _context = new EntityDataModel();

    //    public BaseOptions(EntityDataModel context)
    //    {
    //        _context = context;
    //    }

    //    void Add(Employee emp, int year)
    //    {
    //        Salary salary = new Salary();
    //        salary.Employee = emp;
    //        salary.CostUnit = emp.Unit;
    //        salary.Month = 00;
    //        salary.Year = year;
    //    }

    //    Salary Read(Employee emp, int year)
    //    {
    //        Salary sal = _context.Salaries.First(l => l.Employee == emp && l.Year == year && l.Month == 00);
    //        return sal;
    //    }

    //    void Update(Employee emp, int year)
    //    {
    //        //_context.Salaries.FirstOrDefault(l => l.Employee == emp);
    //        //_context.Salaries.Attach(salary);
    //    }

    //    void Dalete(Employee emp, int year)
    //    {
    //        _context.Salaries.Remove();
    //    }
    //}
}
/*
         public Salary CalcSalary(Employee emp, int year, int month)
        {
            //TODO:yapılması gereken yüzde hesapları için
            //hesap nesnesini değiştirmemiz gerekiyor ve burdada üzerinde durulması lazım 
            var sal = new Salary { Employee = emp, Year = year, Month = month, CostUnit = emp.Unit };

            var employeeOp = _context.EmployeeOps.FirstOrDefault(p => p.Employee == emp);
            var employeeBaseAccounts = _context.EmployeeOps.Where(l => l.Year == year && l.Month == 00 && l.Employee == emp);

            var unitOp = _context.UnitOps.FirstOrDefault(p => p.Unit == emp.Unit);

            var locationOp = _context.LocationOps.FirstOrDefault(p => p.Location == emp.Unit.Location);
            //Bütün Masraf hesabı listesini alıyorum
            var costAccounts = _context.CostAccounts.ToList();

            foreach (var costAccount in costAccounts)
            {
                //Masraf Listesindeki her bir üye için önce kişi kartına sonra unite kartına sonrada bölge kartına bakıp bu sırayla hangisi ondeyse onu ekleyeceğiz
                CostAccount acc;
                //Kişi kartında bu hesap için girilmiş bir değer varmı?
                if (employeeOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID) != null)
                {
                    //Varmış bunu ekle
                    acc = employeeOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID);
                }
                //Kişi kartında o hesap için veri yok o halde unit kartına bak o hesap için değer varmı
                else if (unitOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID && (l.Title == emp.Title || l.Title == null)) != null)
                {
                    //evet varmış o halde burdakini ekle
                    acc = unitOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID && (l.Title == emp.Title || l.Title == null));
                }
                //Unite Kartında da bu hesap için bir değer yok o zaman bölge kartına bak
                else if (locationOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID) != null)
                {
                    //varmış madem bunu ekliyoruz
                    acc = locationOp.Accounts.FirstOrDefault(l => l.ID == costAccount.ID);
                }
                //hiçbir kartta bu veri hesap için bir değer mevcut değil o zaman sıfır liralık bir hesap oluşturuyoruz
                else
                {
                    acc = new CostAccount
                    {
                        ID = costAccount.ID,
                        Code = costAccount.Code,
                        Name = costAccount.Name,
                        FactorType = FactorType.Amount,
                        Amount = null,
                        IsActive = true
                    };
                }
                //oluşturulan hesap nesnesini maaş nesnesine ekliyoruz
                sal.CostAccounts.Add(acc);
                //ok
            }
            //nesneyi ilet ben kaydetmeyeceğim belki bir gridde gosterip toplu olarak kaydetmek felan isteriz
            return sal;
            _context.Salaries.Add(sal);
            _context.SaveChanges();
        }

        public void InputBaseSalary(
            Employee emp,
            int year,
            CostAccount account)
        {
            var eop = new EmployeeOp
            {
                Employee = emp,
                Month = 00,
                Year = year,
                Unit = emp.Unit
            };

            eop
                .Accounts
                .Add(account);
            _context
                .EmployeeOps
                .Add(eop);
            _context
                .SaveChanges();
        }

        public void AddBaseOps(Employee emp, int year, CostAccount acc, int amount)
        {
            var salary = new Salary { Employee = emp, CostUnit = emp.Unit, Month = 00, Year = year };

            salary.CostAccounts.Add(acc);
            _context.Salaries.Add(salary);
            _context.SaveChanges();

        }

        public void BaseOpQuery(Employee emp, int year)
        {
            List<CostAccount> costAccounts =
            _context.Salaries.FirstOrDefault(l => l.Employee == emp && l.Year == year && l.Month == 00).CostAccounts;

        }

 */