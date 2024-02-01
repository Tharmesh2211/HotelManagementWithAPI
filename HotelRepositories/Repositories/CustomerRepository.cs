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
    public class CustomerRepository : ICustomer
    {
        private readonly HotelContext _context;
        public CustomerRepository(HotelContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer customer)
        {

            try
            {
                int GetRoomId = customer.RoomId;
                int GetAvailableRooms = 0;

                var GetRoom = await _context.Rooms.FirstOrDefaultAsync(t => t.ID.Equals(GetRoomId));

                if (GetRoom != null && GetRoom.IsBooked == true)
                {
                    int GetHotelId = GetRoom.HotelId;

                    var GetHotelDetail = await _context.Hotel.FirstOrDefaultAsync(t => t.Id.Equals(GetHotelId));

                    if (GetHotelDetail != null)
                    {
                        DateTime checkin = DateTime.Now;
                        string changeformat = checkin.ToString("yyyy-MM-dd");
                       
                        DateTime checkout = DateTime.Parse(customer.CheckOut);

                        TimeSpan timeSpan = checkout.Date - checkin.Date;  

                        int days = timeSpan.Days;

                        customer.TotalRent = days * GetRoom.RoomRent;
                        var addCustomer = await _context.AddAsync(customer);
                        await _context.SaveChangesAsync();

                        GetHotelDetail.RoomAvailability--;
                        await _context.SaveChangesAsync();


                        GetRoom.IsBooked = false;
                        await _context.SaveChangesAsync();
                        return addCustomer.Entity;
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            try
            {
                return await _context.Customer.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                return await _context.Customer.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch
            {
                throw;
            }
        }
    }
}
