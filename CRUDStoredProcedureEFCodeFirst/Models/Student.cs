
using System.ComponentModel.DataAnnotations;

namespace CRUDStoredProcedureEFCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string saddress { get; set; }
        public string mobileno { get; set; }
        public string city { get; set; }
        public decimal fees { get; set; }
    }
}
