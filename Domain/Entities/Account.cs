namespace Domain.Entities
{
    public class Account : IEntity
    {
        public Account()
        {
            Archived = false;
        }

        public Account(string email, string encryptedPassword)
        {
            Archived = false;
            Email = email;
            EncryptedPassword = encryptedPassword;
        }

        public virtual string Email { get; protected set; }
        public virtual string EncryptedPassword { get; protected set; }
        public virtual long Id { get; set; }
        public virtual bool Archived { get; protected set; }

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
    }
}