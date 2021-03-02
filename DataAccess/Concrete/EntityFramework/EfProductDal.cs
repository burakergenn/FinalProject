using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //var result = context.Products.Join(context.Categories,
                //     p => p.CategoryId, c => c.CategoryId, (p, c) => new { Product = p, Category = c })
                //    .Select(t => new ProductDetailDto
                //    {
                //        ProductId = t.Product.ProductId,
                //        ProductName = t.Product.ProductName,
                //        CategoryName = t.Category.CategoryName,
                //        UnitsInStock = t.Product.UnitsInStock
                //    }); ;


                //Derste bu şekilde yaptık ama üstteki gibi bir alternatifte var***expressions

                var result = from p in context.Products
                             join c in context.Categories
                            on p.CategoryId equals c.CategoryId
                            select new ProductDetailDto {ProductId = p.ProductId,ProductName=p.ProductName,CategoryName=c.CategoryName,
                                UnitsInStock=p.UnitsInStock };

                return result.ToList();
            }
        }
    }
}

