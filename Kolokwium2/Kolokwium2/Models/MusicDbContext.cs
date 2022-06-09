using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName);
                e.Property(e => e.LastName);
                e.Property(e => e.NickName);



                e.ToTable("Musician");
            });

            modelBuilder.Entity<Musican_Track>(e =>
            {
                e.HasKey(e => new { e.IdTrack, e.IdMusican });
                e.HasOne(e => e.Track)
                .WithMany(e => e.Musican_Tracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Musician)
                .WithMany(e => e.Musican_Tracks)
                .HasForeignKey(e => e.IdMusican)
                .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("Musician_Track");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.HasOne(e => e.Album)
               .WithMany(e => e.Tracks)
               .HasForeignKey(e => e.IdMusicAlbum)
               .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("Track");
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.HasOne(e => e.MusicLabel)
              .WithMany(e => e.Albums)
              .HasForeignKey(e => e.IdMusicLabel)
              .OnDelete(DeleteBehavior.ClientCascade);

                e.ToTable("Album");

            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.ToTable("MusicLabel");
            });
        }
    }
}
