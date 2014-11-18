using Domain.Entities;
using Domain.Services;
using DomainDrivenDatabaseDeployer;
using NHibernate;

namespace DatabaseDeployer
{
    public class AccountSeeder : IDataSeeder
    {
        readonly ISession _session;

        public AccountSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            IPasswordEncryptor passwordEncryptor = new HashPasswordEncryptor();
            var encryptedPassword = passwordEncryptor.Encrypt("password");
            var account1 = new Account("test@test.com",encryptedPassword);
            _session.Save(account1);
        }
    }
}