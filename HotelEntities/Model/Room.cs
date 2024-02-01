using HotelEntities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntities.Model
{
    public class Room
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public RoomType RoomType { get; set; }
        public double RoomRent {  get; set; }
        public bool IsBooked {  get; set; }
        public int HotelId {  get; set; }
        public Hotel Hotel { get; set; }
        public bool IsDeleted {  get; set; }

    }
}
