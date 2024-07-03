using System;
using System.ComponentModel.DataAnnotations;

namespace ProTaskManagers02.Models
{
    public class Project
    {
        private string _title;
        private string _description;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _status;

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre du projet est requis.")]
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le titre ne peut pas être vide.");
                _title = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Required(ErrorMessage = "La date de début du projet est requise.")]
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (value > EndDate)
                    throw new ArgumentException("La date de début ne peut pas être après la date de fin.");
                _startDate = value;
            }
        }

        [Required(ErrorMessage = "La date de fin du projet est requise.")]
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (value < StartDate)
                    throw new ArgumentException("La date de fin ne peut pas être avant la date de début.");
                _endDate = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
