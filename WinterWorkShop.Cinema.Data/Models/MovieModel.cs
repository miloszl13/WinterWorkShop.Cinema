﻿namespace WinterWorkShop.Cinema.Data.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public double Rating { get; set; }
        public List<ProjectionModel> Projections { get; set; }
    }
}
