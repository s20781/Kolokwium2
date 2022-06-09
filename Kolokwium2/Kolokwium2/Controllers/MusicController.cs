using Kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _service;

        public MusicController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> GetAlbumById(int id)
        {
            if (await _service.GetAlbumByIdAsync(id) is null)
                return NotFound("Nie znaleziono klienta o podanym id");
            return Ok(await _service.GetAlbumByIdAsync(id));
        }
    }
}
