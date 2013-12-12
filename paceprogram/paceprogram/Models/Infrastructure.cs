using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class Infrastructure
    {
        public int InfrastructureID { get; set; }
        [Display(Name = "Hardware Name")]
        public string InfrastructureName { get; set; }
        public virtual Room Room { get; set; }
        [ForeignKey("Room")]
        public virtual int RoomID { get; set; }
        public virtual Equipment Equipment { get; set; }
        [ForeignKey("Equipment")]
        public virtual int EquipmentID { get; set; }
        [Display(Name="Serial Number")]
        public string SerialNubmer { get; set; }
        [Display(Name="Inventory Tag")]
        public string InventoryTag { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public virtual int DepartmentID { get; set; }
        [Display(Name="Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name="Model")]
        public string Model { get; set; }
        public virtual Make Make { get; set; }
        [ForeignKey("Make")]
        public virtual int MakeID { get; set; }
        [Display(Name="Owner")]
        public string Owner { get; set; }
    }
}