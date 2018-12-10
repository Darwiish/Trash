using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashVersionOne.Models;
using TrashVersionOne.Models.ViewModel;

namespace TrashVersionOne.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }


        public DbSet<ProductDetails> ProductDetails { get; set; }

        public DbSet<TrashVersionOne.Models.ViewModel.ProductDetailViewModel> ProductDetailViewModel { get; set; }


    }
}
