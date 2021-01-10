/*
using Asp_ShopProject_AP.Controllers;
using Asp_ShopProject_AP.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace ShopProject.test
{
    public class ProductControllerTest
    {
        [Fact]
        public void GetProductByIdTest()
        {
            // Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns(new Product[] { 
                new Product {Id = 1, ProductName = "P1"},
                new Product {Id = 2, ProductName = "P2"},
                new Product {Id = 3, ProductName = "P3"},
            }.AsQueryable<Product>);
            var controller = new ProductController(productRepositoryMock.Object);
            // Act

            // Assert
        }
    }
}
*/