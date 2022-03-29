using System.ComponentModel.DataAnnotations;

namespace NRGi_aspirant_opgave.Models
{
    public class ConditionReport
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int NumberOfBuildings { get; set; }

        public int NumberOfDamages { get; set; }

        private readonly DateTime dateOfCreation = DateTime.Now;

        public DateTime DateOfCreation
        {
            get
            {
                return dateOfCreation;
            }
            private set
            {
                _ = dateOfCreation;
            }
        }

        //public DateTime DateOfCreation { get; private set; }

        private DateTime dateOfModification = DateTime.Now;

        public DateTime DateOfModification
        {
            get
            {
                return dateOfModification;
            }
            set
            {
                _ = dateOfModification;
            }
        }

    }
}
