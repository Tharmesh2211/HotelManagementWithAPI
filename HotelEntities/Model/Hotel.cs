using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntities.Model
{
    public class Hotel
    {
        public int Id { get; set; } 
        public string HotelName {  get; set; }
        public int TotalRooms { get; set; }
        public int RoomAvailability { get; set; }
    }
}
