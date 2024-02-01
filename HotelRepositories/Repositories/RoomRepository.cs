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
    public class RoomRepository : IRoom
    {
        private readonly HotelContext _hotelContext;
        public RoomRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        
        public async Task<Room> Add(Room room)
        {
            try
            {
                var GetHotel = await _hotelContext.Hotel.FirstOrDefaultAsync(t=> t.Id.Equals(room.HotelId));
                Console.WriteLine(_hotelContext.Rooms.Count());
                if(GetHotel != null)
                {
                    if (_hotelContext.Rooms.Count() < GetHotel.TotalRooms)
                    {
                        room.RoomRent = 1000;
                        if (room.RoomType == 0)
                        {
                            room.RoomRent = 1500;
                        }
                        var addRoom = await _hotelContext.AddAsync(room);
                        await _hotelContext.SaveChangesAsync();
                        return addRoom.Entity;
                    }
                }
                return null;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Room> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> Get()
        {
            try
            {
                return await _hotelContext.Rooms.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Room> GetById(int id)
        {
            try
            {
                if (_hotelContext.Rooms.Count() > 0)
                {
                    return await _hotelContext.Rooms.FirstOrDefaultAsync(t => t.ID == id);
                }
                return null;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Room> Update(Room room)
        {
            try
            {
                var result = await _hotelContext.Rooms.FirstOrDefaultAsync(t => t.ID == room.ID);
                if (result != null)
                {
                    result.RoomType = room.RoomType;
                    result.RoomRent = room.RoomRent;
                    await _hotelContext.SaveChangesAsync();
                    return result;
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
