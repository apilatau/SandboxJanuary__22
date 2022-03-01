namespace DataLayer.Models
{
    public class BookingType : BaseEntity
    {
        public string BookType { get; set; }

        //[IgnoreDataMember]
       // public ICollection<Reserve> Reserves { get; set; }
    }
}
