using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelExt.Models
{
    [MetadataType(typeof(Order_DetailsMetadata))]
    public partial class Order_Details
    {
        public class Order_DetailsMetadata
        {
            [DisplayName("單價")]
            public decimal UnitPrice { get; set; }
            [DisplayName("數量")]
            public short Quantity { get; set; }
            [DisplayName("折扣")]
            public float Discount { get; set; }
        }
    }
}