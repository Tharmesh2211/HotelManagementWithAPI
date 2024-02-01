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
    public class CheckOutRepository : ICheckOut
    {
        private readonly HotelContext _context;
        public CheckOutRepository(HotelContext hotelContext)
        {
            _context = hotelContext;
        }

        public async Task<CheckOut> Add(CheckOut checkOut)
        {
            try
            {
                if(checkOut != null)
                {
                    checkOut.Status = "CheckedOut Successfully";
                    var GetCustomer = await _context.Customer.FirstOrDefaultAsync(t => t.Id.Equals(checkOut.CustomerId));
                    if (GetCustomer!=null)
                    {
                        var GetRoom = await _context.Rooms.FirstOrDefaultAsync(t => t.ID.Equals(GetCustomer.RoomId));
                        if (GetCustomer != null && GetRoom != null)
                        {
                            GetCustomer.isVacated = false;
                            GetRoom.IsBooked = true;

                            var GetHotel = await _context.Hotel.FirstOrDefaultAsync(t => t.Id.Equals(GetRoom.HotelId));
                            if (GetHotel!=null)
                            {
                                GetHotel.RoomAvailability++;
                                var addcheckOut = await _context.AddAsync(checkOut);
                                await _context.SaveChangesAsync();
                                return addcheckOut.Entity;
                            }
                           
                        }
                    }
                   
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Task<IEnumerable<CheckOut>> GetCheckOuts()
        {
            throw new NotImplementedException();
        }
    }
}
