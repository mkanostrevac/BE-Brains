using System;
using System.Collections.Generic;
using System.Linq;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class VouchersService : IVouchersService
    {
        private IUnitOfWork db;

        public VouchersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<VoucherModel> GetAllVouchers()
        {
            return db.VouchersRepository.Get();
        }

        public VoucherModel CreateVoucher(VoucherModel voucher)
        {
            voucher.IsUsed = false;
            voucher.ExpirationDate = (DateTime.UtcNow.AddDays(7));

            db.VouchersRepository.Insert(voucher);
            db.Save();

            return voucher;
        }

        public VoucherModel UpdateVoucher(int id, VoucherModel voucher)
        {
            VoucherModel updateVoucher = db.VouchersRepository.GetByID(id);

            if (updateVoucher != null)
            {
                updateVoucher.ExpirationDate = voucher.ExpirationDate;
                updateVoucher.IsUsed = voucher.IsUsed;
                updateVoucher.Offer = voucher.Offer;
                updateVoucher.Buyer = voucher.Buyer;

                db.VouchersRepository.Update(updateVoucher);
                db.Save();
            }

            return updateVoucher;
        }

        public VoucherModel DeleteVoucher(int id)
        {
            VoucherModel voucher = db.VouchersRepository.GetByID(id);

            if (voucher != null)
            {
                db.VouchersRepository.Delete(voucher);
                db.Save();
            }

            return voucher;
        }

        public IEnumerable<VoucherModel> GetVouchersByBuyer(int buyerId)
        {
            return db.VouchersRepository.Get(x => x.Buyer.ID == buyerId);
        }

        public IEnumerable<VoucherModel> GetVouchersByOffer(int offerId)
        {
            return db.VouchersRepository.Get(x => x.Offer.ID == offerId);
        }

        public IEnumerable<VoucherModel> GetNonExpiredVouchers()
        {
            return db.VouchersRepository.Get(x => x.ExpirationDate < DateTime.UtcNow);
        }
    }
}