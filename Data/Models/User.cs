namespace Data.Models
{
    public class User
    {
        // /^[a-zA-Z0-9]+$/
        public Guid Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public int Status { get; set; }
        public Guid IdRole { get; set; }

        public virtual Role Role { get; set; }


        public virtual Cart Cart { get; set; }



        public virtual ICollection<Bill> Bills { get; set; }

    }
}
