using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public enum OfferStatuses { WAIT_FOR_APPROVING, APPROVED, DECLINED, EXPIRED };

    [Table("offers")]
    public class OfferModel
    {
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime Created { get; set; }

        [Column("expires_at")]
        public DateTime Expires { get; set; }

        [Column("regular_price")]
        public double RegularPrice { get; set; }

        [Column("action_price")]
        public double ActionPrice { get; set; }

        [Column("image_path")]
        public string ImagePath { get; set; }

        [Column("available_offers")]
        public int AvailableOffers { get; set; }

        [Column("bought_offers")]
        public int BoughtOffers { get; set; }

        [Column("status")]
        public OfferStatuses Status { get; set; }
    }
}