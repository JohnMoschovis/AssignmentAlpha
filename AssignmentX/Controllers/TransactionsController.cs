using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentX.Models;
using AssignmentX.Repositories;

namespace AssignmentX.Controllers
{
    
    public class TransactionsController : Controller
    {
        //  private TransactionsContext db = new TransactionsContext();
        private ITransactionsRepository transactionRepository;
        public int id2;

        public TransactionsController(ITransactionsRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        // GET: Transactions
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(transactionRepository.GetAll());
             }
            else
            {
                if (id.HasValue)
                    id2 = id.Value;
                List<Transactions> tr = transactionRepository.GetAllbyid(id2);
                return View(tr);
            }
}

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id.HasValue)
                id2 = id.Value;
            Transactions transactions = transactionRepository.Findid(id2);//.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tid,account_id,amount,type")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                transactionRepository.Add(transactions);
        //        db.Transactions.Add(transactions);
           //     db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id.HasValue)
                id2 = id.Value;
            Transactions transactions = transactionRepository.Findid(id2);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tid,account_id,amount,type")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
           
                return RedirectToAction("Index");
            }
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id.HasValue)
                id2 = id.Value;
            Transactions transactions = transactionRepository.Findid(id2);
//                db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transactionRepository.Remove(id);
         //   Transactions transactions = db.Transactions.Find(id);
        //    db.Transactions.Remove(transactions);
         //   db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                transactionRepository.Armageddon();
            }
            base.Dispose(disposing);
        }
    }
}
