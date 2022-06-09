using Kolokwium2.Models;
using Kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class MusicService : IMusicService
    {

        private readonly MusicDbContext _repository;
        public MusicService(MusicDbContext repository)
        {
            _repository = repository;
        }


        public async Task<AlbumGet> GetAlbumByIdAsync(int id)
        {
            return await _repository.Albums
                .Where(e=>e.IdAlbum == id)
                .Include(e => e.Tracks)
                .Select(e => new AlbumGet
                
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    IdMusicLabel = e.IdMusicLabel,
                    Tracks = e.Tracks.Select(e=>new Track
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration,
                        IdMusicAlbum = e.IdMusicAlbum
                    })
                }).FirstOrDefaultAsync();

        }
    }
}
