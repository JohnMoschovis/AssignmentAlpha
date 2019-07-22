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
   
    public class BankAccountsController : Controller
    {
        //private BankAccountContext db = new BankAccountContext();
        private IBankAccountRepository bankAccountRepository;
        public int id2;

        public BankAccountsController(IBankAccountRepository bankAccountRepository)
        {
            this.bankAccountRepository = bankAccountRepository;
        }
        // GET: BankAccounts
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(bankAccountRepository.GetAll());
            }
            else
            {
                if (id.HasValue)
                    id2 = id.Value;
                List<BankAccount> bankAccount = bankAccountRepository.GetAllbyid(id2);
                return View(bankAccount);
            }
        }




        // GET: BankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id.HasValue)
                id2 = id.Value;
            BankAccount bankAccount = bankAccountRepository.Findid(id2); //
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "acc_id,userid,iban,balance")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                bankAccountRepository.Create(bankAccount);
                //db.BankAccounts.Add(bankAccount);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id.HasValue)
                id2 = id.Value;
            BankAccount bankAccount = bankAccountRepository.Findid(id2);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "acc_id,userid,iban,balance")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                bankAccountRepository.Update(bankAccount);
                return RedirectToAction("Index");
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id.HasValue)
                id2 = id.Value;
            BankAccount bankAccount = bankAccountRepository.Findid(id2);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bankAccountRepository.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bankAccountRepository.Armageddon();
            }
            base.Dispose(disposing);
        }
    }
}
