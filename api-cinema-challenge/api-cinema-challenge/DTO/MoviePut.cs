﻿namespace api_cinema_challenge.DTO
{
    public class MoviePut
    {
        public string? Title { get; set; }
        public string? Rating { get; set; }
        public string? Description { get; set; }
        public int RuntimeMins { get; set; }
    }
}
