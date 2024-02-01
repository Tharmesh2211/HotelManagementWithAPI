using HotelEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelContracts.IService
{
    public interface ICheckOut
    {
        public Task<CheckOut> Add(CheckOut checkOut);
        public Task<IEnumerable<CheckOut>> GetCheckOuts();
    }
}
