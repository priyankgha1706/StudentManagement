using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAppCore.Core.Models
{
    public class StudentMarks
    {
        public int StdId { get; set; }
        public int UserId { get; set; }
        public string RollNo { get; set; }
        public string Name { get; set; }
        public int OS { get; set; }
        public int DBMS { get; set; }
        public int JAVA { get; set; }
        public int PYTHON { get; set; }
        public int CS { get; set; }
        public int Total { get; set; }
        public decimal Average { get; set; }
    }
}
