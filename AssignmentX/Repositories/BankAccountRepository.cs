using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssignmentX.Models;
using Unity;
using System.Web.Http.ModelBinding;
using System.Data.Entity;

namespace AssignmentX.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        [Dependency]
        public BankAccountContext DbContext { get; set; }
        

        public void Add( BankAccount ba)
        {
            DbContext.BankAccounts.Add(ba);
            DbContext.SaveChanges();
        }

        public BankAccount Findid(int acc_id)
        {
            return DbContext.BankAccounts.Find(acc_id);
        }

        public BankAccount Find(int user_id)
        {
            throw new NotImplementedException();
        }

        public List<BankAccount> GetAll()
        {
           return DbContext.BankAccounts.ToList();
        }
        public void Create(BankAccount tempbnk)
        {
        
                DbContext.BankAccounts.Add(tempbnk);
                DbContext.SaveChanges();
                
            
        }

        public List<BankAccount> GetAllbyid(int id)
        {
            ///////////1st attempt////////////////////////////////////////
            //List<BankAccount> templist = new List<BankAccount>();
            //List<BankAccount> outputlist = new List<BankAccount>();
            //templist = DbContext.BankAccounts.ToList();

            //foreach (var trans in templist)
            //{
            //    if (trans.userid == id)
            //    {
            //        outputlist.Add(trans);
            //    }

            //}
            //return outputlist;

            var bankAccounts = from m in DbContext.BankAccounts
                         select m;

            //if (!int=(id))
            //{
                bankAccounts = bankAccounts.Where(s => s.userid.Equals(id));
            //}

            return (bankAccounts.ToList());

        }
        public void Remove(int acc_id)
        {
            BankAccount bankAccount = Findid(acc_id);
            DbContext.BankAccounts.Remove(bankAccount);
            DbContext.SaveChanges();
        }

        public void Update(BankAccount ba)
        {
            DbContext.Entry(ba).State = EntityState.Modified;
            DbContext.SaveChanges(); 
        }

        public void Armageddon()
        {
            DbContext.Dispose();
        }

        public bool ammountcheck(int acc_id,decimal amount, int type)
        {
            BankAccountContext DbContext1 = new BankAccountContext();
            BankAccount tempbankaccount = DbContext1.BankAccounts.Find(acc_id);
            if (type == 0)
            {
                if (tempbankaccount.balance > amount)
                {
                    tempbankaccount.balance -= amount;
                    DbContext1.Entry(tempbankaccount).State = EntityState.Modified;
                    DbContext1.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                tempbankaccount.balance += amount;
                DbContext1.Entry(tempbankaccount).State = EntityState.Modified;
                DbContext1.SaveChanges();
                return true;
            }
            

        }
    }
}