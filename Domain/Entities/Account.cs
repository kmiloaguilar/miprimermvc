using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Account : IEntity
    {
        private readonly IEnumerable<Clasificado> _clasificados = new List<Clasificado>(); 
        public Account()
        {
            Archived = false;
            DateOfBirth = DateTime.Today;

        }

        public Account(string email, string encryptedPassword, string firstName, string lastName, DateTime dateOfBirth,
            bool termsAndConditionAccepted, string roles)
        {
            Archived = false;
            Email = email;
            EncryptedPassword = encryptedPassword;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TermsAndConditionsAccepted = termsAndConditionAccepted;
            Roles = roles;
        }

        public virtual string Email { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual DateTime DateOfBirth { get; protected set; }
        public virtual bool TermsAndConditionsAccepted { get; protected set; }
        public virtual string EncryptedPassword { get; protected set; }
        public virtual long Id { get; set; }
        public virtual IEnumerable<Clasificado> Clasificados { get { return _clasificados; } }

        public virtual void AddClasificado(Clasificado clasificado)
        {
            ((IList<Clasificado>)_clasificados).Add(clasificado);
        }

        public virtual void RemoveClasificado(Clasificado clasificado)
        {
            if (((IList<Clasificado>)_clasificados).Contains(clasificado))
            {
                ((IList<Clasificado>) _clasificados).Remove(clasificado);
            }
        }

        public virtual bool Archived { get; protected set; }

        public virtual string Roles { get; protected set; }

        public virtual void Archive()
        {
            Archived = true;
        }

        public virtual void Activate()
        {
            Archived = false;
        }

        public virtual void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public virtual void ChangeEncryptedPassword(string newEncryptedPassword)
        {
            EncryptedPassword = newEncryptedPassword;
        }

        public virtual void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public virtual void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        public virtual void ChangeDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public virtual void ChangeTermsAndConditionAccepted(bool termsAndConditionAccepted)
        {
            TermsAndConditionsAccepted = termsAndConditionAccepted;
        }

        public virtual void ChangeRoles(string roles)
        {
            Roles = roles;
        }
    }
}