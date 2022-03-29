using System.ComponentModel.DataAnnotations;

namespace NRGi_aspirant_opgave.Models
{
    public class Property
    {
        public int Id { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        [StringLength(4)]
        public int PostalCode { get; set; }

        public List<ConditionReport>? ConditionReports { get; set; }
    }
}
