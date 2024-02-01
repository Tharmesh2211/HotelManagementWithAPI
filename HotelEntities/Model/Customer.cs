namespace HotelEntities.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckIn { get; set; }
        public string CheckOut { get; set; }
        public double TotalRent { get; set; }
        public int RoomId {  get; set; }
        public Room Room { get; set; }
        public bool isVacated {  get; set; } = false;
    }
}
