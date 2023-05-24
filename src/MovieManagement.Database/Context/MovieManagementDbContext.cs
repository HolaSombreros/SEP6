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

    public  DbSet<MovieListMovieEntity> MovieListMovies { get; set; } = default!;
    public  DbSet<RatingEntity> Ratings { get; set; } = default!;
    public  DbSet<UserEntity> Users { get; set; } = default!;
    public  DbSet<ActorEntity> Actors { get; set; } = default!;
    public  DbSet<MovieActorEntity> MovieActors { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ActorEntity>(entity => {
            entity.ToTable("Actor");
            entity.HasKey(a => a.ActorId);
            entity.Property(a => a.ActorId).ValueGeneratedNever().HasColumnType("int").HasColumnName("actor_id");
            entity.Property(a => a.Birthdate).HasColumnType("datetime2").HasColumnName("birthdate");
            entity.Property(a => a.Gender).ValueGeneratedNever().HasColumnType("int").HasColumnName("gender");
            entity.Property(a => a.Name).HasMaxLength(250).HasColumnName("name");
        });

        modelBuilder.Entity<MovieActorEntity>(entity => {
            entity.ToTable("MovieActor");
            entity.HasKey(a => new {a.ActorId, a.MovieId});
            entity.Property(a => a.ActorId).ValueGeneratedNever().HasColumnType("int").HasColumnName("actor_id");
            entity.Property(a => a.MovieId).ValueGeneratedNever().HasColumnType("int").HasColumnName("movie_id");
            entity.Property(a => a.MovieOrder).ValueGeneratedNever().HasColumnType("int").HasColumnName("movie_order");

            entity.HasOne(a => a.ActorEntity).WithMany().HasForeignKey(a => a.ActorId).HasConstraintName("fk_movieactor_actor_id");
            entity.HasOne(a => a.MovieEntity).WithMany().HasForeignKey(a => a.MovieId).HasConstraintName("fk_movieactor_movie_id");
        });

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
                .HasConstraintName("FK_user_id_movielist").OnDelete(DeleteBehavior.ClientCascade);
        });

        modelBuilder.Entity<MovieListMovieEntity>(entity =>
        {
            entity
                .HasKey(m => new {m.MovieListId, m.MovieId});

            entity.ToTable("MovieList_Movie");

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
                .HasConstraintName("FK_movielist_id_movie").OnDelete(DeleteBehavior.Cascade);
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
                .HasConstraintName("FK_user_id").OnDelete(DeleteBehavior.Cascade);
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
        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
