using Microsoft.AspNetCore.Mvc;
using Moq;
using ShopBridge.Controllers;
using ShopBridge.Models;
using ShopBridge.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridgeUnitTest
{
    public class ProductControllerTest
    {
        private Mock<IProductRepository> repositoryStub = new Mock<IProductRepository>();

  
        [Fact]
        public async Task GetProductsAync_WithExistingItem_ReturnsExpectedItems()
        {
            var productDTO = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "OnePlus",
                    Description = "OnePlus Nord CE 5G (Charcoal Ink, 8GB RAM, 128GB Storage)",
                    Price = 24999.00m,
                    Quantity = 3,
                    CategoryId = 1,
                    PhotoPath = "images/oneplus.png",
                    Category = new Category()
                    {
                        CategoryId = 1,
                        CategoryName = "Mobiles"
                    }
                },
                
                new Product()
                {
                     ProductId = 2,
                    ProductName = "OnePlus",
                    Description = "OnePlus 9R 5G (Lake Blue, 8GB RAM, 128GB Storage)",
                    Price = 39999.00m,
                    Quantity = 5,
                    CategoryId = 1,
                    PhotoPath = "images/oneplus9R.png",
                    Category = new Category()
                    {
                        CategoryId = 1,
                        CategoryName = "Mobiles"
                    }
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Acer Nitro",
                    Description = "Acer Nitro 5 Intel Core i5-11th Generation 144 Hz Refresh Rate 15.6-inch (39.62 cms) Gaming Laptop (8GB Ram/512 GB SSD/Win10/GTX 1650 Graphics/Obsidian Black/2.2 Kgs), AN515-56 + Xbox Game Pass for PC",
                    Price = 72994.00m,
                    Quantity = 3,
                    CategoryId = 2,
                    PhotoPath = "images/Acer.png",
                    Category = new Category()
                    {
                        CategoryId = 2,
                        CategoryName = "Laptops"
                    }
                },
                new Product()
                {
                    ProductId = 4,
                    ProductName = "Apple MacBook Pro",
                    Description = "2020 Apple MacBook Pro (13.3-inch/33.78 cm, 8GB RAM, 256GB SSD, 1.4GHz Quad-core 8th-Generation Intel Core i5 Processor, Two Thunderbolt 3 Ports) - Space Grey",
                    Price = 99990.00m,
                    Quantity = 10,
                    CategoryId = 2,
                    PhotoPath = "images/Apple.png",
                    Category = new Category()
                    {
                        CategoryId = 2,
                        CategoryName = "Laptops"
                    }
                },
                new Product()
                {
                    ProductId = 5,
                    ProductName = "Casio",
                    Description = "Casio CT-S200 Casiotone 61-Key Portable Keyboard (Red)",
                    Price = 7595.00m,
                    Quantity = 7,
                    CategoryId = 5,
                    PhotoPath = "images/Casio.png",
                    Category = new Category()
                    {
                        CategoryId = 5,
                        CategoryName = "Music Instruments"
                    }
                },
                new Product()
                {
                    ProductId = 6,
                    ProductName = "Guitar",
                    Description = "Ashton D10C 39-inch Cutaway Acoustic Guitar",
                    Price = 7595.00m,
                    Quantity = 2,
                    CategoryId = 5,
                    PhotoPath = "images/Guitar.png",
                    Category = new Category()
                    {
                        CategoryId = 5,
                        CategoryName = "Music Instruments"
                    }
                },
                new Product()
                {
                    ProductId = 7,
                    ProductName = "Samsung Smart TV",
                    Description = "Samsung 138 cm (55 inches) Crystal 4K Pro Series Ultra HD Smart LED TV UA55AUE70AKLXL (Black) (2021 Model)",
                    Price = 54999.00m,
                    Quantity = 2,
                    CategoryId = 3,
                    PhotoPath = "images/TV.png",
                    Category = new Category()
                    {
                        CategoryId = 3,
                        CategoryName = "TV"
                    }
                },
                new Product()
                {
                    ProductId = 8,
                    ProductName = "Sony Microless Camera",
                    Description = "Sony Alpha ILCE-6400M 24.2MP Mirrorless Digital SLR Camera (Black) with 18-135mm Power Zoom Lens (APS-C Sensor, Real-Time Eye Auto Focus, 4K Vlogging Camera, Tiltable LCD) - Black",
                    Price = 102499.00m,
                    Quantity = 5,
                    CategoryId = 4,
                    PhotoPath = "images/SonyCamera.png",
                    Category = new Category()
                    {
                        CategoryId = 4,
                        CategoryName = "Cameras"
                    }
                },
                new Product()
                {
                    ProductId = 9,
                    ProductName = "Canon Camera",
                    Description = "Canon EOS 200D II 24.1MP Digital SLR Camera + EF-S 18-55mm is STM Lens + EF-S 55-250mm is STM Lens (Black)",
                    Price = 62220.00m,
                    Quantity = 3,
                    CategoryId = 4,
                    PhotoPath = "images/Canon.png",
                    Category = new Category()
                    {
                        CategoryId = 4,
                        CategoryName = "Cameras"
                    }

                },
                new Product()
                {
                    ProductId = 10,
                    ProductName = "Casio AT",
                    Description = "Casio AT-S200 Casiotone 61-Key Portable Keyboard (Red)",
                    Price = 17595.00m,
                    Quantity = 5,
                    CategoryId = 5,
                    PhotoPath = "images/CasioAT.png",
                    Category = new Category()
                    {
                        CategoryId = 5,
                        CategoryName = "Music Instruments"
                    }
                }
                
            };

            repositoryStub.Setup(p => p.GetProducts()).ReturnsAsync(productDTO);
            ProductsController productsController = new ProductsController(repositoryStub.Object);
            var result = await productsController.GetProducts(0,10);
            
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProductsAync_WithExistingItem_ReturnsExpectedItemsById()
        {
            var expectedResponse = new Product()
            {
                ProductId = 1,
                ProductName = "OnePlus7T",
                Description = "OnePlus Nord CE 5G (Charcoal Ink, 8GB RAM, 128GB Storage)",
                Price = 24999.00m,
                Quantity = 3,
                CategoryId = 1,
                PhotoPath = "images/oneplus.png",
                Category = new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Mobiles"
                }
            };
            repositoryStub.Setup(p => p.GetProduct(1)).ReturnsAsync(expectedResponse);
            ProductsController productsController = new ProductsController(repositoryStub.Object);
            var actualResponse = await productsController.GetProduct(1);

            Assert.Equal(expectedResponse.ProductId, actualResponse.Value.ProductId);
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateTheProduct()
        {
            var expectedResponse = new Product()
            {
                ProductId = 1,
                ProductName = "OnePlus7T",
                Description = "OnePlus Nord CE 5G (Charcoal Ink, 8GB RAM, 128GB Storage)",
                Price = 24999.00m,
                Quantity = 3,
                CategoryId = 1,
                PhotoPath = "images/oneplus.png",
                Category = new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Mobiles"
                }
            };

            repositoryStub.Setup(p => p.GetProduct(1)).ReturnsAsync(expectedResponse);
            ProductsController productsController = new ProductsController(repositoryStub.Object);
            var actualResponse = await productsController.UpdateProduct(1, expectedResponse);

            Assert.Equal(expectedResponse.ProductName, actualResponse.Value.ProductName);
            Assert.Equal(expectedResponse.ProductId, actualResponse.Value.ProductId);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldDeleteTheProduct()
        {
            var expectedResponse = new Product()
            {
                ProductId = 10,
                ProductName = "Casio AT",
                Description = "Casio AT-S200 Casiotone 61-Key Portable Keyboard (Red)",
                Price = 17595.00m,
                Quantity = 5,
                CategoryId = 5,
                PhotoPath = "images/CasioAT.png",
                Category = new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Music Instruments"
                }
            };

            repositoryStub.Setup(p => p.GetProduct(10)).ReturnsAsync(expectedResponse);
            ProductsController productsController = new ProductsController(repositoryStub.Object);
            var result = await productsController.DeleteProduct(10);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddProductAsync_ShouldAddNewProduct()
        {
            var itemToCreate = new Product()
            {
                ProductId = 10,
                ProductName = "Casio AT",
                Description = "Casio AT-S200 Casiotone 61-Key Portable Keyboard (Red)",
                Price = 17595.00m,
                Quantity = 5,
                CategoryId = 5,
                PhotoPath = "images/CasioAT.png",
                Category = new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Music Instruments"
                }
            };

            //mock.Setup(p => p.GetProduct(10)).ReturnsAsync(itemToCreate);
            ProductsController productsController = new ProductsController(repositoryStub.Object);

            var result = await productsController.CreateProduct(itemToCreate);
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
