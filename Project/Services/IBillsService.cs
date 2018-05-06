using System;
using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public interface IBillsService
    {
        IEnumerable<BillModel> GetAllBills();

        BillModel CreateBill(BillModel bill);

        BillModel UpdateBill(int id, BillModel bill);

        BillModel DeleteBill(int id);

        IEnumerable<BillModel> GetBillsByBuyer(int buyerId);

        IEnumerable<BillModel> GetBillsByCategory(int categoryId);

        IEnumerable<BillModel> GetBillsByDatePeriod(DateTime startDate, DateTime endDate);
    }
}
