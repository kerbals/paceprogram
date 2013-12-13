using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace paceproject.Models
{
    public class Server
    {
        public int ServerID { get; set; }
        [Display(Name="Server")]
        public string ServerName { get; set; }
        [Display(Name="Information and Notes")]
        public string GeneralInformation { get; set; }
        [Display(Name="IP Address")]
        //[RegularExpression("/^([0-9]{1,3}).([0-9]{1,3}).([0-9]{1,3}).([0-9]{1,3});([0-9]‌​{1,5})$/",ErrorMessage="Please enter a valid an IP address.")]
        public string IPAddress { get; set; }
        [Display(Name="OS Installed")]
        public string OperatingSystem { get; set; }
        [Display(Name="Hardware Name")]
        public virtual Infrastructure Infrastructure { get; set; }
        [ForeignKey("Infrastructure")]
        public virtual int InfrastructureID { get; set; }
        [ForeignKey("Department")]
        public virtual int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool DomainBound { get; set; }
    }

    
}