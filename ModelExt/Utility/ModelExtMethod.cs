using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelExt.Models;

namespace ModelExt.Utility
{
    public static class ModelExtMethod
    {
        public static decimal TotalPrice(this Order_Details orderDetail)
        {
            decimal result = 0;
            result = orderDetail.UnitPrice * orderDetail.Quantity;
            return result;
        }
    }
}