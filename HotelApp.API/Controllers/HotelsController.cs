using HotelApp.BL.Abstract;
using HotelApp.BL.Concrete;
using HotelApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelsController()
        {
            _hotelService = new HotelManager();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();//404
        }

        [HttpPost]
        public IActionResult Post(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createdHotel = _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel);
            }
            return BadRequest(ModelState);//400+validasyon
        }
    }

  
}
