using System;

namespace ProTaskManagers02.Models
{
    public class Collaborator
    {
        private string _name;
        private string _role;
        private string _email;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom du collaborateur ne peut pas être vide ou nul.");
                _name = value;
            }
        }

        public string Role
        {
            get { return _role; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le rôle du collaborateur ne peut pas être vide ou nul.");
                _role = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("L'email du collaborateur ne peut pas être vide ou nul.");
                _email = value;
            }
        }

        public int Id { get; internal set; }

        public Collaborator()
        {
            // Constructeur par défaut
        }

        public Collaborator(string name, string role, string email)
        {
            Name = name;
            Role = role;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name} ({Role}) - {Email}";
        }
    }
}
