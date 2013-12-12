using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class Make
    {
        public int MakeID { get; set; }
        [Display(Name="Make")]
        public string MakeName { get; set; }
    }
}