using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Table("bills")]
    public class BillModel
    {
        public int ID { get; set; }

        [Column("payment_made")]
        public bool PaymentMade { get; set; }

        [Column("payment_canceled")]
        public bool PaymentCanceled { get; set; }

        [NotMapped] // koristi se samo pri dodavanju ili promeni racuna
        public int? OfferID { get; set; }

        [NotMapped] // koristi se samo pri dodavanju ili promeni racuna
        public int? BuyerID { get; set; }

        [Column("offer_id")]
        public virtual OfferModel Offer { get; set; }

        [Column("buyer_id")]
        public virtual UserModel Buyer { get; set; }

        [Column("created_at")]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public BillModel() { }
    }
}