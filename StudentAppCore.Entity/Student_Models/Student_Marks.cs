﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StudentAppCore.Entity.Student_Models
{
    public partial class Student_Marks
    {
        public int Std_Id { get; set; }
        public int User_Id { get; set; }
        public string Roll_No { get; set; }
        public string Name { get; set; }
        public int OS { get; set; }
        public int DBMS { get; set; }
        public int JAVA { get; set; }
        public int PYTHON { get; set; }
        public int CS { get; set; }
        public int Total { get; set; }
        public decimal Average { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Create_Time_Stamp { get; set; }
        public DateTime Update_Time_Stamp { get; set; }

        public virtual User_Login User_ { get; set; }
    }
}