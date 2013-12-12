using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        [Display(Name="Room")]
        public string RoomName { get; set; }
    }
}