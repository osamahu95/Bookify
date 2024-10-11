using Bookify.Domain.Navigations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Data.Data
{
    public class BookifyDbContext: DbContext
    {
        public BookifyDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to many relationship between User and Bookshop
            /*modelBuilder.Entity<User>()
                .HasMany(u => u.User_Bookshops)
                .WithOne(ub => ub.User)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<BookShop>()
                .HasOne<User_Bookshop>(bs => bs.User_Bookshop)
                .WithOne(ubs => ubs.BookShop)
                .HasForeignKey<User_Bookshop>(ubs => ubs.BookShopId);

            modelBuilder.Entity<User_Bookshop>()
                .HasOne<BookShop>(bs => bs.BookShop)
                .WithOne(bs => bs.User_Bookshop)
                .HasForeignKey<User_Bookshop>(ubs => ubs.BookShopId);

            // One to many relationship between User and Book
            modelBuilder.Entity<Book>()
                .HasOne<User_Book>(b => b.User_Book)
                .WithOne(ub => ub.Book)
                .HasForeignKey<User_Book>(ub => ub.BookId);

            modelBuilder.Entity<User_Book>()
                .HasOne<Book>(b => b.Book)
                .WithOne(b => b.User_Book)
                .HasForeignKey<User_Book>(ub => ub.BookId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.User_Books)
                .WithOne(ub => ub.User)
                .HasForeignKey(ub => ub.UserId);

            // One to many relationship between User and Author
            modelBuilder.Entity<User>()
                .HasMany(u => u.User_Authors)
                .WithOne(ua => ua.User)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<Author>()
                .HasOne<User_Author>(a => a.User_Author)
                .WithOne(ua => ua.Author)
                .HasForeignKey<User_Author>(ua => ua.AuthorId);

            modelBuilder.Entity<User_Author>()
                .HasOne<Author>(a => a.Author)
                .WithOne(a => a.User_Author)
                .HasForeignKey<User_Author>(ua => ua.AuthorId);

            // One to many relationship between Book and BookShop
            modelBuilder.Entity<Book>()
                .HasOne<Book_Bookshop>(b => b.Book_BookShop)
                .WithOne(bb => bb.Book)
                .HasForeignKey<Book_Bookshop>(bb => bb.BookId);

            modelBuilder.Entity<Book_Bookshop>()
                .HasOne<Book>(b => b.Book)
                .WithOne(b => b.Book_BookShop)
                .HasForeignKey<Book_Bookshop>(bb => bb.BookId);

            modelBuilder.Entity<BookShop>()
                .HasMany(b => b.Book_Bookshops)
                .WithOne(bb => bb.BookShop)
                .HasForeignKey(bb => bb.BookshopId);

            // One to many relationship between Author and Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Author_Books)
                .WithOne(ab => ab.Author)
                .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne<Author_Book>(ab => ab.Author_Book)
                .WithOne(ab => ab.Book)
                .HasForeignKey<Author_Book>(ab => ab.BookId);

            modelBuilder.Entity<Author_Book>()
                .HasOne<Book>(b => b.Book)
                .WithOne(b => b.Author_Book)
                .HasForeignKey<Author_Book>(ab => ab.BookId);

            // One to One RelationShip Book and Stock
            modelBuilder.Entity<Book>()
                .HasOne<Book_Stock>(bst => bst.Book_Stock)
                .WithOne(bst => bst.Book)
                .HasForeignKey<Book_Stock>(bst => bst.BookId);

            modelBuilder.Entity<Book_Stock>()
                .HasOne<Book>(b => b.Book)
                .WithOne(b => b.Book_Stock)
                .HasForeignKey<Book_Stock>(bst => bst.BookId);

            // Many to Many Relationsship of Book and Category
            modelBuilder.Entity<Book_Category>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.Book_Categories)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book_Category>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.Book_Categories)
                .HasForeignKey(c => c.CategoryId);*/                                                          

        }

        // models
        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BookShop> BookShop { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Stock> Stock { get; set; }

        // navigation models
        public DbSet<User_Book> User_Book { get; set; }
        public DbSet<User_Bookshop> User_BookShop { get; set; }
        public DbSet<User_Author> User_Author { get; set; }
        public DbSet<Book_Bookshop> Book_BookShop { get; set; }
        public DbSet<Author_Book> Author_Book { get; set; }
        public DbSet<Book_Category> Book_Category { get; set; }
        public DbSet<Book_Stock> Book_Stock { get; set; }
    }
}
