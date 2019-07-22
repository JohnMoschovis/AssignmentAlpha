using AssignmentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentX.Repositories
{
    public interface ITransactionsRepository
    {
        void Add(Transactions tr);
        List<Transactions> GetAll();
        List<Transactions> GetAllbyid(int id);


        Transactions Findid(int acc_id);
        Transactions Find(int user_id);
        void Create(Transactions tr);

        void Remove(int acc_id);

        void Update(Transactions tr);

        void Armageddon();
        
    }
}
