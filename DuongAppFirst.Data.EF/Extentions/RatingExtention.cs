using DuongAppFirst.Data.Entities;
using DuongAppFirst.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DuongAppFirst.Data.EF.Extentions
{
    public static class RatingExtention
    {
        public static IQueryable<Product> OrderProductByRating(this IQueryable<Product> products)
        {
            products.ToList().ForEach(x => {
                if(x.Ratings != null) x.TotalRate = x.GetRatingProduct();
            });
            return products.OrderByDescending(x => x.TotalRate);
        }
        public static int GetRatingProduct(this Product product)
        {
            List<int> lst = new List<int>();
            foreach(var item in product.Ratings)
            {
                lst.Add(item.Rate);
            }
            return (int)Math.Ceiling(lst.Average());
        }
    }
}
