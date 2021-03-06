﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace MusicStore.Models
{
    public class ApplicationUser : IdentityUser { }

    public class MusicStoreContext : IdentityDbContext<ApplicationUser>
    {
        public MusicStoreContext()
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>().Key(a => a.AlbumId);
            builder.Entity<Artist>().Key(a => a.ArtistId);
            builder.Entity<Order>().Key(o => o.OrderId);
            builder.Entity<Genre>().Key(g => g.GenreId);
            builder.Entity<CartItem>().Key(c => c.CartItemId);
            builder.Entity<OrderDetail>().Key(o => o.OrderDetailId);

            // TODO: Remove this when we start using auto generated values
            builder.Entity<Artist>().Property(a => a.ArtistId).GenerateValuesOnAdd(generateValues: false);
            builder.Entity<Genre>().Property(g => g.GenreId).GenerateValuesOnAdd(generateValues: false);

            base.OnModelCreating(builder);
        }
    }

}