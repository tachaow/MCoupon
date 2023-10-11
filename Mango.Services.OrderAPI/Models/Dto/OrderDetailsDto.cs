﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.OrderAPI.Models.Dto
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
        public string Productname { get; set; }
        public double Price { get; set; }
    }
}
