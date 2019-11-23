using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FDServer
{
    public partial class BAZANOWContext : DbContext
    {
        public BAZANOWContext()
        {
        }

        public BAZANOWContext(DbContextOptions<BAZANOWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Аптеки> Аптеки { get; set; }
        public virtual DbSet<АссортиментТовара> АссортиментТовара { get; set; }
        public virtual DbSet<ВидыТранспорта> ВидыТранспорта { get; set; }
        public virtual DbSet<ЛекарстваИИхЗаменители> ЛекарстваИИхЗаменители { get; set; }
        public virtual DbSet<Лекарство> Лекарство { get; set; }
        public virtual DbSet<МаршрутыОстановки> МаршрутыОстановки { get; set; }
        public virtual DbSet<Объекты> Объекты { get; set; }
        public virtual DbSet<Остановки> Остановки { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<ПользователиОбъекты> ПользователиОбъекты { get; set; }
        public virtual DbSet<ТранспортныеМаршруты> ТранспортныеМаршруты { get; set; }
        public virtual DbSet<Улицы> Улицы { get; set; }
        public virtual DbSet<ФормыУпаковки> ФормыУпаковки { get; set; }
        public virtual DbSet<GetRoutes_Result> GetRoutes_Result { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:marakaserver.database.windows.net,1433;Initial Catalog=BAZANOW;Persist Security Info=False;User ID=dimadmin;Password=123456789SQL!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Аптеки>(entity =>
            {
                entity.HasKey(e => e.IdАптеки);

                entity.HasIndex(e => new { e.Название, e.IdУлицы, e.НомерДома })
                    .HasName("IX_Аптеки")
                    .IsUnique();

                entity.Property(e => e.IdАптеки).HasColumnName("id_аптеки");

                entity.Property(e => e.IdОстановки).HasColumnName("id_остановки");

                entity.Property(e => e.IdУлицы).HasColumnName("id_улицы");

                entity.Property(e => e.ВремяНачалаРаботы)
                    .IsRequired()
                    .HasColumnName("Время начала работы")
                    .HasMaxLength(5);

                entity.Property(e => e.ВремяОкончанияРаботы)
                    .IsRequired()
                    .HasColumnName("Время окончания работы")
                    .HasMaxLength(5);

                entity.Property(e => e.Название)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.НомерДома)
                    .IsRequired()
                    .HasColumnName("Номер дома")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Остановки)
                    .WithMany(p => p.Аптеки)
                    .HasForeignKey(d => d.IdОстановки)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Аптеки_Остановки");

                entity.HasOne(d => d.Улицы)
                    .WithMany(p => p.Аптеки)
                    .HasForeignKey(d => d.IdУлицы)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Аптеки_Улицы1");
            });

            modelBuilder.Entity<АссортиментТовара>(entity =>
            {
                entity.HasKey(e => new { e.IdЛекарство, e.IdАптеки, e.IdФормыУпаковки });

                entity.ToTable("Ассортимент товара");

                entity.HasIndex(e => new { e.IdФормыУпаковки, e.IdАптеки, e.IdЛекарство })
                    .HasName("IX_Ассортимент товара")
                    .IsUnique();

                entity.Property(e => e.IdЛекарство).HasColumnName("id_лекарство");

                entity.Property(e => e.IdАптеки).HasColumnName("id_аптеки");

                entity.Property(e => e.IdФормыУпаковки).HasColumnName("id_ФормыУпаковки");

                entity.Property(e => e.Количество)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Цена)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.IdАптекиNavigation)
                    .WithMany(p => p.АссортиментТовара)
                    .HasForeignKey(d => d.IdАптеки)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ассортимент товара_Аптеки");

                entity.HasOne(d => d.IdЛекарствоNavigation)
                    .WithMany(p => p.АссортиментТовара)
                    .HasForeignKey(d => d.IdЛекарство)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ассортимент товара_Лекарство");

                entity.HasOne(d => d.IdФормыУпаковкиNavigation)
                    .WithMany(p => p.АссортиментТовара)
                    .HasForeignKey(d => d.IdФормыУпаковки)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ассортимент товара_Формы упаковки");
            });

            modelBuilder.Entity<ВидыТранспорта>(entity =>
            {
                entity.HasKey(e => e.IdВидаТранспорта);

                entity.ToTable("Виды Транспорта");

                entity.HasIndex(e => e.ВидТранспорта)
                    .HasName("IX_Виды Транспорта")
                    .IsUnique();

                entity.Property(e => e.IdВидаТранспорта).HasColumnName("id_ВидаТранспорта");

                entity.Property(e => e.ВидТранспорта)
                    .IsRequired()
                    .HasColumnName("Вид транспорта")
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<ЛекарстваИИхЗаменители>(entity =>
            {
                entity.HasKey(e => new { e.IdЛекарство, e.IdЗаменителя });

                entity.ToTable("Лекарства и их заменители");

                entity.HasIndex(e => new { e.IdЛекарство, e.IdЗаменителя })
                    .HasName("IX_Лекарства и их заменители")
                    .IsUnique();

                entity.Property(e => e.IdЛекарство).HasColumnName("id_лекарство");

                entity.Property(e => e.IdЗаменителя).HasColumnName("id_заменителя");

                entity.HasOne(d => d.IdЗаменителяNavigation)
                    .WithMany(p => p.ЛекарстваИИхЗаменителиIdЗаменителяNavigation)
                    .HasForeignKey(d => d.IdЗаменителя)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Лекарства и их заменители_Лекарство1");

                entity.HasOne(d => d.IdЛекарствоNavigation)
                    .WithMany(p => p.ЛекарстваИИхЗаменителиIdЛекарствоNavigation)
                    .HasForeignKey(d => d.IdЛекарство)
                    .HasConstraintName("FK_Лекарства и их заменители_Лекарство");
            });

            modelBuilder.Entity<Лекарство>(entity =>
            {
                entity.HasKey(e => e.IdЛекарство);

                entity.HasIndex(e => e.НазваниеЛекарства)
                    .HasName("IX_Лекарство")
                    .IsUnique();

                entity.Property(e => e.IdЛекарство).HasColumnName("id_лекарство");

                entity.Property(e => e.НазваниеЛекарства)
                    .IsRequired()
                    .HasColumnName("Название лекарства")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<МаршрутыОстановки>(entity =>
            {
                entity.HasKey(e => new { e.IdМаршрута, e.IdОстановки });

                entity.Property(e => e.IdМаршрута).HasColumnName("id_маршрута");

                entity.Property(e => e.IdОстановки).HasColumnName("id_остановки");

                entity.HasOne(d => d.IdМаршрутаNavigation)
                    .WithMany(p => p.МаршрутыОстановки)
                    .HasForeignKey(d => d.IdМаршрута)
                    .HasConstraintName("FK_МаршрутыОстановки_Транспортные маршруты");

                entity.HasOne(d => d.IdОстановкиNavigation)
                    .WithMany(p => p.МаршрутыОстановки)
                    .HasForeignKey(d => d.IdОстановки)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_МаршрутыОстановки_Остановки");
            });

            modelBuilder.Entity<Объекты>(entity =>
            {
                entity.HasKey(e => e.IdОбъекта);

                entity.Property(e => e.IdОбъекта).HasColumnName("id_объекта");

                entity.Property(e => e.ИмяОбъекта).HasColumnName("Имя объекта");
            });

            modelBuilder.Entity<Остановки>(entity =>
            {
                entity.HasKey(e => e.IdОстановки);

                entity.HasIndex(e => new { e.IdУлицы, e.НазваниеОстановки })
                    .HasName("IX_Остановки")
                    .IsUnique();

                entity.Property(e => e.IdОстановки).HasColumnName("id_остановки");

                entity.Property(e => e.IdУлицы).HasColumnName("id_улицы");

                entity.Property(e => e.НазваниеОстановки)
                    .IsRequired()
                    .HasColumnName("Название остановки")
                    .HasMaxLength(55);

                entity.HasOne(d => d.IdУлицыNavigation)
                    .WithMany(p => p.Остановки)
                    .HasForeignKey(d => d.IdУлицы)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Остановки_Улицы");
            });

            modelBuilder.Entity<Пользователи>(entity =>
            {
                entity.HasKey(e => e.IdПользователя);

                entity.HasIndex(e => e.Login)
                    .HasName("IX_Пользователи")
                    .IsUnique();

                entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ПользователиОбъекты>(entity =>
            {
                entity.HasKey(e => new { e.IdПользователя, e.IdОбъекта });

                entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");

                entity.Property(e => e.IdОбъекта).HasColumnName("id_объекта");

                entity.HasOne(d => d.IdОбъектаNavigation)
                    .WithMany(p => p.ПользователиОбъекты)
                    .HasForeignKey(d => d.IdОбъекта)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ПользователиОбъекты_Объекты");

                entity.HasOne(d => d.IdПользователяNavigation)
                    .WithMany(p => p.ПользователиОбъекты)
                    .HasForeignKey(d => d.IdПользователя)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ПользователиОбъекты_Пользователи");
            });

            modelBuilder.Entity<ТранспортныеМаршруты>(entity =>
            {
                entity.HasKey(e => e.IdМаршрута);

                entity.ToTable("Транспортные маршруты");

                entity.HasIndex(e => new { e.НомерМаршрута, e.IdВидаТранспорта })
                    .HasName("IX_Транспортные маршруты")
                    .IsUnique();

                entity.Property(e => e.IdМаршрута).HasColumnName("id_маршрута");

                entity.Property(e => e.IdВидаТранспорта).HasColumnName("id_ВидаТранспорта");

                entity.Property(e => e.НомерМаршрута)
                    .IsRequired()
                    .HasColumnName("Номер маршрута")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdВидаТранспортаNavigation)
                    .WithMany(p => p.ТранспортныеМаршруты)
                    .HasForeignKey(d => d.IdВидаТранспорта)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Транспортные маршруты_Виды Транспорта");
            });

            modelBuilder.Entity<Улицы>(entity =>
            {
                entity.HasKey(e => e.IdУлицы);

                entity.HasIndex(e => e.НазваниеУлицы)
                    .HasName("IX_Улицы")
                    .IsUnique();

                entity.Property(e => e.IdУлицы).HasColumnName("id_улицы");

                entity.Property(e => e.НазваниеУлицы)
                    .IsRequired()
                    .HasColumnName("Название улицы")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ФормыУпаковки>(entity =>
            {
                entity.HasKey(e => e.IdФормыУпаковки);

                entity.ToTable("Формы упаковки");

                entity.HasIndex(e => e.НазваниеФормы)
                    .HasName("IX_Формы упаковки")
                    .IsUnique();

                entity.Property(e => e.IdФормыУпаковки).HasColumnName("id_ФормыУпаковки");

                entity.Property(e => e.НазваниеФормы)
                    .IsRequired()
                    .HasColumnName("Название формы")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<GetRoutes_Result>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Вид_транспорта).HasColumnName("Вид транспорта");
                entity.Property(e => e.Название_лекарства).HasColumnName("Название лекарства");
                entity.Property(e => e.Номер_дома).HasColumnName("Номер дома");
                entity.Property(e => e.Время_начала_работы).HasColumnName("Время начала работы");
                entity.Property(e => e.Время_окончания_работы).HasColumnName("Время окончания работы");
                entity.Property(e => e.Название_остановки).HasColumnName("Название остановки");
                entity.Property(e => e.Название_улицы).HasColumnName("Название улицы");
                entity.Property(e => e.Номер_маршрута).HasColumnName("Номер маршрута");
                entity.Property(e => e.Название_формы).HasColumnName("Название формы");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
