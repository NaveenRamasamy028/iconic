using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IconicBank1
{
    public partial class iconicbankingContext : DbContext
    {
        public iconicbankingContext()
        {
        }

        public iconicbankingContext(DbContextOptions<iconicbankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=deviconicbanking.database.windows.net;Database=iconicbanking;User Id=developer_account;Password=Welcome@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__transacti__Accou__6C190EBB");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__users__BE2ACD6EB0AE7AF9");

                entity.ToTable("users");

                entity.Property(e => e.AccountNumber).ValueGeneratedNever();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsccode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IFSCCode");

                entity.Property(e => e.LoggedIn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
