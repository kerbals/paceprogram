﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace paceproject.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Display(Name="Department")]
        public string DepartmentName { get; set; }
    }
}