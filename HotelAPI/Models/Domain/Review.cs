﻿namespace HotelAPI.Models.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
