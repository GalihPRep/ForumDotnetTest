using AccountApp.Models.Entities;
using AccountApp.Models.Requests;
using Project000.Helper;
using Project000.Models;

namespace Project000.Services
{
    public class AccountService
    {
        private readonly AccountRepository _db;

        public AccountService(AccountContext context){_db = new AccountRepository(context);}
        public List<Account> FindAll() {return _db.FindAll();}
        public Account FindByUsername(string username){return _db.FindByUsername(username);}

        public void Save(AccountDto account){_db.Save(account);}
        public void Update(AccountDto account, string username) { _db.Update(account, username);}
        public void Delete(string username) { _db.Delete(username);}
    }
}
