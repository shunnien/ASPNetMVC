using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ModelExt.Models
{
    /// <summary>
    /// Class NorthwindEntities.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public partial class NorthwindEntities
    {
        /// <summary>
        /// Functions the total price.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns>System.Nullable&lt;System.Decimal&gt;.</returns>
        [DbFunction("NorthwindModel.Store", "fn_TotalPrice")]
        public decimal? Fn_TotalPrice(int orderId, int productId)
        {
            var parameters = new List<ObjectParameter>(2)
            {
                new ObjectParameter("OrderID", orderId),
                new ObjectParameter("ProductID", productId)
            };

            var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;
            var output = lObjectContext.
                CreateQuery<decimal?>("NorthwindModel.Store.fn_TotalPrice(@OrderID, @ProductID)", parameters.ToArray())
                .Execute(MergeOption.NoTracking)
                .FirstOrDefault();
            return output;
        }

        /// <summary>
        /// Functions the total product quan.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        [DbFunction("NorthwindModel.Store", "fn_TotalProductQuan")]
        public int? Fn_TotalProductQuan(int orderId)
        {
            var paramter = new ObjectParameter("OrderID", orderId);
            var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;
            var output = lObjectContext.
                CreateQuery<int?>("NorthwindModel.Store.fn_TotalProductQuan(@OrderID)", paramter)
                .Execute(MergeOption.NoTracking)
                .FirstOrDefault();
            return output;
        }
    }
}