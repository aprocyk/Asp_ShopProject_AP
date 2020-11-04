using Asp_ShopProject_AP.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        ProductName = "Kajak",
                        ProductDescription = "Łódka przeznaczona dla jednej osoby",
                        Category = "Sporty wodne",
                        Price = 275
                    },
                    new Product
                    {
                        ProductName = "Kamizelka ratunkowa",
                        ProductDescription = "Chroni i dodaje uroku",
                        Category = "Sporty wodne",
                        Price = 48.95m
                    },
                    new Product
                    {
                        ProductName = "Piłka",
                        ProductDescription = "Zatwierdzone przez FIFA rozmiar i waga",
                        Category = "Piłka nożna",
                        Price = 19.50m
                    },
                    new Product
                    {
                        ProductName = "Flagi narożne",
                        ProductDescription = "Nadadzą twojemu boisku profesjonalny wygląd",
                        Category = "Piłka nożna",
                        Price = 34.95m
                    },
                    new Product
                    {
                        ProductName = "Stadiom",
                        ProductDescription = "Składany stadion na 35 000 osób",
                        Category = "Piłka nożna",
                        Price = 79500
                    },
                    new Product
                    {
                        ProductName = "Czapka",
                        ProductDescription = "Zwiększa efektywność mózgu o 75%",
                        Category = "Szachy",
                        Price = 16
                    },
                    new Product
                    {
                        ProductName = "Niestabilne krzesło",
                        ProductDescription = "Zmniejsza szanse przeciwnika",
                        Category = "Szachy",
                        Price = 29.95m
                    },
                    new Product
                    {
                        ProductName = "Ludzka szachownica",
                        ProductDescription = "Przyjemna gra dla całej rodziny!",
                        Category = "Szachy",
                        Price = 75
                    },
                    new Product
                    {
                        ProductName = "Błyszczący król",
                        ProductDescription = "Figura pokryta złotem i wysadzana diamentami",
                        Category = "Szachy",
                        Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
