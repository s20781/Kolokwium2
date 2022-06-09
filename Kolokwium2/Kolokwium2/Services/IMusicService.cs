using Kolokwium2.Models;
using Kolokwium2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public interface IMusicService
    {
        public Task<AlbumGet> GetAlbumByIdAsync(int id);
    }
}
