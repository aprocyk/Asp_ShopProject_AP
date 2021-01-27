using Asp_ShopProject_AP.Controllers;
using Asp_ShopProject_AP.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Asp_ShopProject_AP.test
{
    public class ProductControllerTest
    {
        [Fact]
        public void GetProductByIdTest()
        {
            //Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns(new Product[] {
                new Product {Id = 1, ProductName = "P1"},
                new Product {Id = 2, ProductName = "P2"},
                new Product {Id = 3, ProductName = "P3"},
            }.AsQueryable<Product>());

            var controller = new ProductController(productRepositoryMock.Object);

            //Act
            var result = controller.GetById(1);
            Product product = result.ViewData.Model as Product;

            //Assert
            Assert.Equal("P1", product.ProductName);
        }
        [Theory]
        [InlineData(1,"P1")]
        [InlineData(2, "P2")]
        public void GetProductsByIdTest(int id, string expectedName)
        {
            //Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns( new Product[] { 
                new Product {Id = 1, ProductName = "P1"},
                new Product {Id = 2, ProductName = "P2"},
                new Product {Id = 3, ProductName = "P3"}
            }.AsQueryable<Product>());

            var controller = new ProductController(productRepositoryMock.Object);

            //Act
            var result = controller.GetById(id);
            Product product = result.ViewData.Model as Product;

            //Assert
            Assert.Equal(expectedName, product.ProductName);
        }
        [Fact]
        public void GetAllProducts()
        {
            //Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns(new Product[]
            {
                new Product {Id = 1, ProductName = "P1"},
                new Product {Id = 2, ProductName = "P2"},
                new Product {Id = 3, ProductName = "P3"},
                new Product {Id = 4, ProductName = "P4"},
                new Product {Id = 5, ProductName = "P5"},
                new Product {Id = 6, ProductName = "P6"},
            }.AsQueryable<Product>());
            var controller = new ProductController(productRepositoryMock.Object);
            //Act
            Product[] result = GetViewModel<IEnumerable<Product>>(controller.ListAll()).ToArray();

            //Assert
            Assert.Equal(6, result.Length);
            Assert.True(result[0].ProductName == "P1");
            Assert.True(result[result.Length-1].ProductName == "P6");
        }
        [Fact]
        public void GetCategoryProducts()
        {
            //Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns(new Product[]
            {
                new Product {Id = 1, ProductName = "P1", Category="C1"},
                new Product {Id = 2, ProductName = "P2", Category="C2"},
                new Product {Id = 3, ProductName = "P3", Category="C3"},
                new Product {Id = 4, ProductName = "P4", Category="C2"},
                new Product {Id = 5, ProductName = "P5", Category="C2"},
                new Product {Id = 6, ProductName = "P6", Category="C3"},
            }.AsQueryable<Product>());
            var controller = new ProductController(productRepositoryMock.Object);
            //Act
            Product[] result = GetViewModel<IEnumerable<Product>>(controller.List("C2")).ToArray();

            //Assert
            Assert.Equal(3, result.Length);
            Assert.True(result[0].ProductName == "P2" && result[1].Category == "C2");
            Assert.True(result[1].ProductName == "P4" && result[1].Category == "C2");
            Assert.True(result[2].ProductName == "P5" && result[1].Category == "C2");
        }




        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
