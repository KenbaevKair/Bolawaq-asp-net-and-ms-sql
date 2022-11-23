using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bolawaq.data;

public partial class BolawaqContext : DbContext
{
    public BolawaqContext()
    {
    }

    public BolawaqContext(DbContextOptions<BolawaqContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public async Task<List<Booking>> GetAll()
    {
        var bookings = new List<Booking>();
        var allbookings = await Bookings.ToListAsync();
        if (allbookings.Any())
        {
            foreach (var book in allbookings)
            {
                bookings.Add(new Booking()
                {
                    Id = book.Id,
                    Иин = book.Иин,
                    Цель = book.Цель,
                    Дата = book.Дата,
                    Время = book.Время,
                    Email = book.Email
                });
            }
        }
        return bookings;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Bolawaq;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("Admins");

            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3213E83F506D6BBD");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.Время).HasPrecision(0);
            entity.Property(e => e.Дата).HasColumnType("date");
            entity.Property(e => e.Иин)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("ИИН");
            entity.Property(e => e.Цель).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
