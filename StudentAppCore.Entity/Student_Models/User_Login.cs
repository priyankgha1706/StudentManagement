﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StudentAppCore.Entity.Student_Models
{
    public partial class User_Login
    {
        public User_Login()
        {
            Student_Marks = new HashSet<Student_Marks>();
        }

        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public bool Is_Admin { get; set; }
        public bool Is_Deleted { get; set; }
        public DateTime Create_Time_Stamp { get; set; }
        public DateTime Update_Time_Stamp { get; set; }

        public virtual ICollection<Student_Marks> Student_Marks { get; set; }
    }
}