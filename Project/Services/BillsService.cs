using System;
using System.Collections.Generic;
using System.Linq;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class BillsService : IBillsService
    {
        private IUnitOfWork db;

        public BillsService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<BillModel> GetAllBills()
        {
            return db.BillsRepository.Get();
        }

        public BillModel CreateBill(BillModel bill)
        {
            bill.PaymentMade = false;
            bill.PaymentCanceled = false;

            db.BillsRepository.Insert(bill);
            db.Save();

            return bill;
        }

        public BillModel UpdateBill(int id, BillModel bill)
        {
            BillModel updatedBill = db.BillsRepository.GetByID(id);

            if (updatedBill != null)
            {
                updatedBill.PaymentMade = bill.PaymentMade;
                updatedBill.PaymentCanceled = bill.PaymentCanceled;
                updatedBill.Offer = bill.Offer;
                updatedBill.Buyer = bill.Buyer;

                db.BillsRepository.Update(updatedBill);
                db.Save();
            }

            return updatedBill;
        }

        public BillModel DeleteBill(int id)
        {
            BillModel bill = db.BillsRepository.GetByID(id);

            if (bill != null)
            {
                db.BillsRepository.Delete(bill);
                db.Save();
            }

            return bill;
        }

        public IEnumerable<BillModel> GetBillsByBuyer(int buyerId)
        {
            return db.BillsRepository.Get(x => x.Buyer.ID == buyerId);
        }

        public IEnumerable<BillModel> GetBillsByCategory(int categoryId)
        {
            return db.BillsRepository.Get(x => x.Offer.Category.ID == categoryId);
        }

        public IEnumerable<BillModel> GetBillsByDatePeriod(DateTime startDate, DateTime endDate)
        {
            return db.BillsRepository.Get(x => (x.Created >= startDate && x.Created <= endDate));
        }
    }
}