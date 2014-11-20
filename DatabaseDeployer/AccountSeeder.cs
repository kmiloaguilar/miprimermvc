using System;
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
            var account1 = new Account("camilo@me.com",encryptedPassword,"Camilo","Aguilar",new DateTime(1986,12,22),true,"user;admin" );
            var account2 = new Account("juan@me.com", encryptedPassword, "Juan", "Perez", new DateTime(1986, 6, 4), true, "user");
            _session.Save(account1);
            _session.Save(account2);
        }
    }
}