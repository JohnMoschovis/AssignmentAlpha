using AssignmentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentX.Repositories
{
    public interface IBankAccountRepository
    {
        void Add(BankAccount ba);
        List<BankAccount> GetAll();


        BankAccount Findid(int acc_id);
        BankAccount Find(int user_id);
        void Create(BankAccount tempbnk);

        void Remove(int acc_id);

        void Update(BankAccount ba);

        void Armageddon();
        bool ammountcheck(int acc_id,decimal amount,int type);
        List<BankAccount> GetAllbyid(int id);
    }
}
