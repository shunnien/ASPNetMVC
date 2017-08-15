using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using ModelExt.Models;

namespace ModelExt.Utility
{
    /// <summary>
    /// Class ModelExtMethod.
    /// </summary>
    public static class ModelExtMethod
    {
        /// <summary>
        /// Totals the price.
        /// </summary>
        /// <param name="orderDetail">The order detail.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal TotalPrice(this Order_Details orderDetail)
        {
            decimal result = 0;
            result = orderDetail.UnitPrice * orderDetail.Quantity;
            return result;
        }

        /// <summary>
        /// Statics the function total price.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
        [DbFunction("NorthwindModel.Store", "fn_TotalPrice")]
        public static decimal? StaticFn_TotalPrice(this NorthwindEntities db,int orderId, int productId)
        {
            var parameters = new List<ObjectParameter>(2)
            {
                new ObjectParameter("OrderID", orderId),
                new ObjectParameter("ProductID", productId)
            };

            var lObjectContext = ((IObjectContextAdapter)db).ObjectContext;
            var output = lObjectContext.
                CreateQuery<decimal?>("NorthwindModel.Store.fn_TotalPrice(@OrderID, @ProductID)", parameters.ToArray())
                .Execute(MergeOption.NoTracking)
                .FirstOrDefault();
            return output;
        }

        /// <summary>
        /// Statics the function total product quan.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        [DbFunction("NorthwindModel.Store", "fn_TotalProductQuan")]
        public static int? StaticFn_TotalProductQuan(this NorthwindEntities db, int orderId)
        {
            var paramter = new ObjectParameter("OrderID", orderId);
            var lObjectContext = ((IObjectContextAdapter)db).ObjectContext;
            var output = lObjectContext.
                CreateQuery<int?>("NorthwindModel.Store.fn_TotalProductQuan(@OrderID)", paramter)
                .Execute(MergeOption.NoTracking)
                .FirstOrDefault();
            return output;
        }
    }
}