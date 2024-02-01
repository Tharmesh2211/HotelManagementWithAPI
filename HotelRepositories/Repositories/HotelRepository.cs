using HotelContracts.IService;
using HotelEntities.Data;
using HotelEntities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepositories.Repositories
{
    public class HotelRepository : IHotel
    {
        private readonly HotelContext _context;
        public HotelRepository(HotelContext context)
        {
            _context = context;
        }
        public async Task<Hotel> Add(Hotel hotel)
        {
            try
            {
                hotel.RoomAvailability = hotel.TotalRooms;
                var addUser = await _context.AddAsync(hotel);
                await _context.SaveChangesAsync();
                return addUser.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Hotel>> Get()
        {
            try
            {
                if (_context.Hotel.Count() > 0)
                {
                    return await _context.Hotel.ToListAsync();
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Hotel> GetById(int id)
        {
            try
            {
                if (_context.Hotel.Count() > 0)
                {
                    return await _context.Hotel.FirstOrDefaultAsync(t => t.Id == id);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            try
            {
                if (_context.Hotel.Count() > 0)
                {
                    var result = await _context.Hotel.FirstOrDefaultAsync(t => t.Id == hotel.Id);
                    if (result != null)
                    {
                        result.TotalRooms = hotel.TotalRooms;
                        await _context.SaveChangesAsync();
                        return result;
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
    }
}
