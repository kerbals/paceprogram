using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        [Display(Name="Equipment Type")]
        public string EquipmentCategory { get; set; }
    }
}