using AssignmentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AssignmentX.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        [Dependency]
        public TransactionsContext DbContext { get; set; }
        public void Add(Transactions tr)
        {
            bool tempa = false;


            BankAccountRepository temp1 = new BankAccountRepository();
            if(tr.type == bid_type.Debit) {
                 tempa = temp1.ammountcheck(tr.user_id, tr.amount, 0); //0 for debit
            }
            else {
                 tempa = temp1.ammountcheck(tr.user_id, tr.amount, 1);//1 for credit
            }
            if (tempa == true)
            {

                DbContext.Transactions.Add(tr);
                DbContext.SaveChanges();
            }

            //BankAccount tempbankaccount = new BankAccount();
            //tempbankaccount =  DbContext1.BankAccounts.Find(tr.account_id);


            
        }

        public void Armageddon()
        {
            DbContext.Dispose();
        }

        public void Create(Transactions tr)
        {
            throw new NotImplementedException();
        }

        public Transactions Find(int user_id)
        {
            throw new NotImplementedException();
        }

        public Transactions Findid(int acc_id)
        {
            return DbContext.Transactions.Find(acc_id);
        }

        public List<Transactions> GetAll()
        {
            if (DbContext.Transactions.ToList().Count > 0)
            {
                return DbContext.Transactions.ToList();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<Transactions> GetAllbyid(int id)
        {
            var trs = from m in DbContext.Transactions
                               select m;

            trs = trs.Where(s => s.user_id.Equals(id));
            

            return (trs.ToList());
        }

        public void Remove(int tr_id)
        {
         //   BankAccount bankAccount = Findid(tr_id);
            Transactions transaction = Findid(tr_id);
            DbContext.Transactions.Remove(transaction);
            DbContext.SaveChanges();
        }

        public void Update(Transactions tr)
        {
            throw new NotImplementedException();
        }
    }
}