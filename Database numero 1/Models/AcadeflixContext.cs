using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database_numero_1.Models
{
    public partial class AcadeflixContext : DbContext
    {
        public AcadeflixContext()
        {
        }

        public AcadeflixContext(DbContextOptions<AcadeflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentsCatalogue> ContentsCatalogues { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<EpActor> EpActors { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenreContent> GenreContents { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8VL7FJC;Initial Catalog=Acadeflix;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("ACTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SURNAME");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("CATALOGS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("CONTENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Dtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DTYPE");

                entity.Property(e => e.MovieId).HasColumnName("MOVIE_ID");

                entity.Property(e => e.Picture)
                    .HasMaxLength(50)
                    .HasColumnName("PICTURE");

                entity.Property(e => e.Release)
                    .HasColumnType("date")
                    .HasColumnName("RELEASE");

                entity.Property(e => e.SerieId).HasColumnName("SERIE_ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__CONTENTS__MOVIE___38996AB5");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.SerieId)
                    .HasConstraintName("FK__CONTENTS__SERIE___37A5467C");
            });

            modelBuilder.Entity<ContentsCatalogue>(entity =>
            {
                entity.ToTable("CONTENTS_CATALOGUE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatalogsId).HasColumnName("CATALOGS_ID");

                entity.Property(e => e.ContentsId).HasColumnName("CONTENTS_ID");

                entity.HasOne(d => d.Catalogs)
                    .WithMany(p => p.ContentsCatalogues)
                    .HasForeignKey(d => d.CatalogsId)
                    .HasConstraintName("FK__CONTENTS___CATAL__3C69FB99");

                entity.HasOne(d => d.Contents)
                    .WithMany(p => p.ContentsCatalogues)
                    .HasForeignKey(d => d.ContentsId)
                    .HasConstraintName("FK__CONTENTS___CONTE__3B75D760");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("DIRECTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("SURNAME");
            });

            modelBuilder.Entity<EpActor>(entity =>
            {
                entity.ToTable("EP_ACTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActorId).HasColumnName("ACTOR_ID");

                entity.Property(e => e.EpisodesId).HasColumnName("EPISODES_ID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.EpActors)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__EP_ACTOR__ACTOR___4AB81AF0");

                entity.HasOne(d => d.Episodes)
                    .WithMany(p => p.EpActors)
                    .HasForeignKey(d => d.EpisodesId)
                    .HasConstraintName("FK__EP_ACTOR__EPISOD__49C3F6B7");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.ToTable("EPISODES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DirectorId).HasColumnName("DIRECTOR_ID");

                entity.Property(e => e.Duration).HasColumnName("DURATION");

                entity.Property(e => e.NameEpisodes)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EPISODES");

                entity.Property(e => e.Release)
                    .HasColumnType("date")
                    .HasColumnName("RELEASE");

                entity.Property(e => e.SeasonId).HasColumnName("SEASON_ID");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__EPISODES__DIRECT__34C8D9D1");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.SeasonId)
                    .HasConstraintName("FK__EPISODES__SEASON__33D4B598");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("FAVORITES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContentsId).HasColumnName("CONTENTS_ID");

                entity.Property(e => e.UsersId).HasColumnName("USERS_ID");

                entity.HasOne(d => d.Contents)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.ContentsId)
                    .HasConstraintName("FK__FAVORITES__CONTE__4E88ABD4");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__FAVORITES__USERS__4D94879B");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("GENRE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<GenreContent>(entity =>
            {
                entity.ToTable("GENRE_CONTENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContentsId).HasColumnName("CONTENTS_ID");

                entity.Property(e => e.GenreId).HasColumnName("GENRE_ID");

                entity.HasOne(d => d.Contents)
                    .WithMany(p => p.GenreContents)
                    .HasForeignKey(d => d.ContentsId)
                    .HasConstraintName("FK__GENRE_CON__CONTE__5BE2A6F2");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenreContents)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__GENRE_CON__GENRE__5CD6CB2B");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("MOVIE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DirectorId).HasColumnName("DIRECTOR_ID");

                entity.Property(e => e.Duration).HasColumnName("DURATION");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__MOVIE__DIRECTOR___2E1BDC42");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.ToTable("MOVIE_ACTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActorId).HasColumnName("ACTOR_ID");

                entity.Property(e => e.MovieId).HasColumnName("MOVIE_ID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActors)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__MOVIE_ACT__ACTOR__46E78A0C");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActors)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MOVIE_ACT__MOVIE__45F365D3");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("SEASONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NSeasons).HasColumnName("N_SEASONS");

                entity.Property(e => e.Release)
                    .HasColumnType("date")
                    .HasColumnName("RELEASE");

                entity.Property(e => e.SerieId).HasColumnName("SERIE_ID");

                entity.Property(e => e.TotalEpisodes).HasColumnName("TOTAL_EPISODES");

                entity.HasOne(d => d.Serie)
                    .WithMany(p => p.Seasons)
                    .HasForeignKey(d => d.SerieId)
                    .HasConstraintName("FK__SEASONS__SERIE_I__30F848ED");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("SERIE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TotalEpisodes).HasColumnName("TOTAL_EPISODES");

                entity.Property(e => e.TotalSeason).HasColumnName("TOTAL_SEASON");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(100)
                    .HasColumnName("AVATAR");

                entity.Property(e => e.CatalogsId).HasColumnName("CATALOGS_ID");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Catalogs)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CatalogsId)
                    .HasConstraintName("FK__USERS__CATALOGS___3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
