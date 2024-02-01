using HotelEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelContracts.IService
{
    public interface IRoom
    {
        public Task<IEnumerable<Room>> Get();
        public Task<Room> GetById(int id);
        public Task<Room> Add(Room item);
        public Task<Room> Update(Room item);
        public Task<Room> Delete(int id);
    }
}
