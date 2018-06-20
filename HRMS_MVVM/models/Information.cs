using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS_MVVM.common;

namespace HRMS_MVVM.models
{
    class Information:NotificationParent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public string Birthday { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Marriage { get; set; } 
        public string Education { get; set; }
        public string Politic { get; set; }
        public string Card { get; set; }
        public string Begin { get; set; }
        public string Seniority { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string Business { get; set; }
        public string Salary { get; set; }
        public string Account { get; set; }
        public string Branch { get; set; }
        public string Mobile { get; set; }
        public string School { get; set; }
        public string Graduation { get; set; }
        public string Contract { get; set; }
        public string Major { get; set; }
        public string Address { get; set; }
    }
}
