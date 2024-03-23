using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beta.Dogtas.HR.Budget.Model.EnumTypes;

namespace Beta.Dogtas.HR.Budget.Model.ObjectModel
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? IdNumber { get; set; }
        public int? SNumber { get; set; }
        public CostUnit Unit { get; set; }
        //TODO: title property si bundan sonra ünvan için kullanılacak yerinede Collar kullanacağım.
        public Title Title { get; set; }
        public Collar Collar { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public short? IsActive { get; set; }
    }
}
