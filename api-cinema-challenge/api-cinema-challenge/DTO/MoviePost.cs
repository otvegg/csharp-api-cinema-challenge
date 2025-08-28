﻿namespace api_cinema_challenge.DTO
{
    public class MoviePost
    {
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public int RuntimeMins { get; set; }

        public ICollection<ScreeningPost> Screenings { get; set; } = new List<ScreeningPost>();
    }
}
