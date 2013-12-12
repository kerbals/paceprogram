using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceInformation { get; set; }
        public string ServiceIPAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LicenseKey { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public virtual int DepartmentID { get; set; }
        public DateTime InstallDate { get; set; }
        public virtual Server Server { get; set; }
        [ForeignKey("Server")]
        public virtual int ServerID { get; set; }
    }
}