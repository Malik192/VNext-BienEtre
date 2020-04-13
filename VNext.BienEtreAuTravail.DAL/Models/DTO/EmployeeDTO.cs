using System;
using System.ComponentModel.DataAnnotations;

namespace VNext.BienEtreAuTravail.DAL.Models.DTO
{
    public class EmployeeDTO
    {
       [Key]
        public int IdEmployee { get ; set; }
        public string Pseudo { get; set; }
        public DateTime Created_at { get; set; }
        public int IdDepartement { get; set; }

    }
}
