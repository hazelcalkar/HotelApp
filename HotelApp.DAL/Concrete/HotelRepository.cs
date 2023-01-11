using HotelApp.DAL.Abstract;
using HotelApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.DAL.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        HotelDbContext db = new HotelDbContext();
        public Hotel CreateHotel(Hotel hotel)
        {
            db.Hotels.Add(hotel);
            db.SaveChanges();
            return hotel;
        }

        public void DeleteHotel(int id)
        {
            var deletedHotel = GetHotelById(id);
            db.Hotels.Remove(deletedHotel);
            db.SaveChanges();
        }

        public List<Hotel> GetAllHotels()
        {
            return db.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            return db.Hotels.Find(id);
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            var updateHotel = GetHotelById(hotel.Id);
            db.Entry(updateHotel).CurrentValues.SetValues(hotel);
            db.SaveChanges();
            return hotel;
        }
    }
}
