namespace MovieManagement.Database.Context;

public partial class MovieManagementDbContext : DbContext
{

    public MovieManagementDbContext()
    {
    }

    public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options)
        : base(options)
    {
    }
    public  DbSet<MovieEntity> Movies { get; set; } = default!;

    public  DbSet<MovieListEntity> MovieLists { get; set; } = default!;

    public  DbSet<MovieListMovie> MovieListMovies { get; set; } = default!;
    public  DbSet<RatingEntity> Ratings { get; set; } = default!;
    public  DbSet<UserEntity> Users { get; set; } = default!;
    public  DbSet<GenreEntity> Genres { get; set; } = default!;
    public  DbSet<MovieGenreEntity> MovieGenres { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieEntity>(entity => {
            entity.ToTable("Movie");
            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movie_id");
            entity.HasKey(m => m.MovieId);
            entity.Property(e => e.Title)
                .HasColumnName("title");
            entity.Property(e => e.PosterUrl)
                .HasColumnName("poster_url");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("datetime2")
                .HasColumnName("release_date");
        });

        modelBuilder.Entity<MovieListEntity>(entity =>
        {
            entity.ToTable("MovieList");

            entity.Property(e => e.MovieListId)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasMaxLength(36)
                .HasColumnName("movielist_id");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("user_id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();
            
            entity.HasKey(m => m.MovieListId);

            entity.HasOne(d => d.UserEntity).WithMany(p => p.MovieLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_user_id_movielist");
        });

        modelBuilder.Entity<MovieListMovie>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MovieList_Movie");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.MovieListId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasMaxLength(36)
                .HasColumnName("movielist_id");

            entity.HasOne(d => d.MovieEntity).WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK_movie_id_movielist");

            entity.HasOne(d => d.MovieList).WithMany()
                .HasForeignKey(d => d.MovieListId)
                .HasConstraintName("FK_movielist_id_movie");
        });

        modelBuilder.Entity<RatingEntity>(entity =>
        {
            entity.ToTable("Rating");

            entity.Property(e => e.RatingId)
                .HasMaxLength(36)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasColumnName("rating_id");
            entity.Property(e => e.DateTime)
                .IsRequired()
                .HasColumnType("datetime2");
            entity.Property(e => e.Rating)
                .IsRequired()
                .HasColumnType("decimal(18, 5)")
                .HasColumnName("rating");
            entity.Property(e => e.Review).HasColumnName("review");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("user_id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();
            entity.Property(e => e.MovieId)
                .HasColumnName("movie_id")
                .HasColumnType("int")
                .IsRequired();
            entity.HasKey(r => r.RatingId);
            entity.HasOne(d => d.UserEntity).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_user_id");
            entity.HasOne(d => d.MovieEntity).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK_movie_id");
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("user_id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.HasKey(u => u.UserId);
        });
        
        modelBuilder.Entity<GenreEntity>(entity =>
        {
            entity.ToTable("Genre");
            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnName("genre_id");
            entity.HasKey(m => m.GenreId);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
        });
        
        modelBuilder.Entity<MovieGenreEntity>(entity =>
        {
            entity.ToTable("MovieGenre");
            entity.HasKey(e => new { e.GenreId, e.MovieId });
            entity.HasOne(e => e.GenreEntity)
                .WithMany()
                .HasForeignKey(e => e.GenreId);
            entity.HasOne(e => e.MovieEntity)
                .WithMany()
                .HasForeignKey(e => e.MovieId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
