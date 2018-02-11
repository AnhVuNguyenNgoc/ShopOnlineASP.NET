using ShopOnline.Model.Models;
using System.Data.Entity;

namespace ShopOnline.Data
{
    public class ShopOnlineDbContext : DbContext
    {
        public ShopOnlineDbContext(): base("ShopOnlineConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            //bảng cha tự động include bảng con
        }

        /*
         In DbContext We could define DBSET from Model
         * and
         * and
         * and &&
         * override OnModelCreating
         */

        //create new table in migration 
        //->>>>>>>>>>...create new dbset



        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        //public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }
        //public DbSet<ProductTag> ProductTags { set; get; }
        //public DbSet<Slide> Slides { set; get; }
        //public DbSet<SupportOnline> SupportOnlines { set; get; }
        //public DbSet<SystemConfig> SystemConfigs { set; get; }

        public DbSet<Tag> Tags { set; get; }

        //public DbSet<VisitorStatistic> VisitorStatistics { set; get; }


        //Why we need override in here 

        //If we dont use it ? What happen ?  **********
        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
