using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Table("vouchers")]
    public class VoucherModel
    {
        public int ID { get; set; }

        [Column("expire_at")]
        public DateTime ExpirationDate { get; set; }

        [Column("is_used")]
        public bool IsUsed { get; set; }

        [NotMapped] // koristi se samo pri dodavanju ili promeni vaucera
        public int? OfferID { get; set; }

        [NotMapped] // koristi se samo pri dodavanju ili promeni vaucera
        public int? BuyerID { get; set; }

        [Column("offer_id")]
        public virtual OfferModel Offer { get; set; }

        [Column("buyer_id")]
        public virtual UserModel Buyer { get; set; }

        public VoucherModel() { }
    }
}