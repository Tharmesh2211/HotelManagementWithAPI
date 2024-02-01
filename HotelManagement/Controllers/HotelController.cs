using HotelContracts.IService;
using HotelEntities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotel;
        private readonly IRoom _room;
        private readonly ICustomer _customer;
        private readonly ICheckOut _checkOut;

        public HotelController(IHotel hotel, IRoom room, ICustomer customer, ICheckOut checkOut)
        {
            _hotel = hotel;
            _room = room;
            _customer = customer;
            _checkOut = checkOut;
        }
        [HttpPost("Add Hotel")]
        public async Task<Hotel> PostHotel(Hotel hotel)
        {
            return await _hotel.Add(hotel);
        }
        [HttpGet("GetHotels")]
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _hotel.Get();
        }
        [HttpGet("GetHotelById")]
        public async Task<Hotel> GetHotelById(int id)
        {
            return await _hotel.GetById(id);

        }
        [HttpPut("UpdateHotel")]
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotel.Update(hotel);
        }

        //

        [HttpPost("AddCustomer")]
        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _customer.Add(customer);
            return customer;
        }
      
      //
        [HttpPost("AddRoom")]
        public async Task<Room> AddRoom(Room roomDetail)
        {
            await _room.Add(roomDetail);
            return roomDetail;
        }
        [HttpGet("GetRooms")]
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _room.Get();
        }
        
        [HttpPut("UpdateRoom")]
        public async Task<Room> UpdateRoomDetail(Room roomDetail)
        {
            var update = await _room.Update(roomDetail);
            return update;
        }

        [HttpPost("Customer_CheckOut")]
        public async Task<CheckOut> CheckOut(CheckOut checkOut)
        {
            return await _checkOut.Add(checkOut);
        }
    }
}
