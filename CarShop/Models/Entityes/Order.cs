using System.ComponentModel.DataAnnotations;

namespace CarShop.Models.Entityes
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "The LastName must be from 3 to 20 characters")]
        public string? LastName { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "The FirstName must be from 3 to 20 characters")]
        public string? FirstName { get; set; }

        [StringLength(15, MinimumLength = 10, ErrorMessage = "The Phone must be from 3 to 20 characters")]
        public string? Phone { get; set; }

        [StringLength(30, MinimumLength = 7, ErrorMessage = "The name Email be @gmail.com")]
        public string? Email { get; set; }

        public DateTime? Created { get; set; }

        public int? IdUser { get; set; }

        public List<int>? IdProducts { get; set; }
    }
}
