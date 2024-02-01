using HotelEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelContracts.IService
{
    public interface IHotel
    {
        public Task<IEnumerable<Hotel>> Get();
        public Task<Hotel> GetById(int id);
        public Task<Hotel>  Add(Hotel item);
        public Task<Hotel> Update(Hotel item);
    }
}
