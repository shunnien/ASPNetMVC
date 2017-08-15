using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ModelExt.Models
{
    //public static class DataBaseFunctions
    public partial class NorthwindEntities
    {
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

        [DbFunction("NorthwindModel.Store", "fn_TotalProductQuan")]
        public int? Fn_TotalProductQuan(int orderId)
        {
            var paramter = new ObjectParameter("OrderID", orderId);
            //var output = ((IObjectContextAdapter)db).ObjectContext.CreateQuery<int>("DFDBModel.Store.Function_20140606(@param1, @param2)", parameters.ToArray()
            var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;
            var output = lObjectContext.
                CreateQuery<int?>("NorthwindModel.Store.fn_TotalProductQuan(@OrderID)", paramter)
                .Execute(MergeOption.NoTracking)
                .FirstOrDefault();
            return output;
            //throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}