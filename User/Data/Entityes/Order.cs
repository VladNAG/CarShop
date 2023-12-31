﻿using System.ComponentModel.DataAnnotations.Schema;

namespace User.Data.Entityes
{
    public class Order
    {
        public int Id { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime? Created { get; set; }

        public int? IdUser { get; set; }

        [NotMapped]
        public List<int>? IdProducts { get; set; }
    }
}
