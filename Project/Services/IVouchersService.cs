using System;
using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public interface IVouchersService
    {
        IEnumerable<VoucherModel> GetAllVouchers();

        VoucherModel CreateVoucher(VoucherModel voucher);

        VoucherModel UpdateVoucher(int id, VoucherModel voucher);

        VoucherModel DeleteVoucher(int id);

        IEnumerable<VoucherModel> GetVouchersByBuyer(int buyerId);

        IEnumerable<VoucherModel> GetVouchersByOffer(int offerId);

        IEnumerable<VoucherModel> GetNonExpiredVouchers();
    }
}
