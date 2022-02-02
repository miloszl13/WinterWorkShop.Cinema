using WinterWorkShop.Cinema.Data.Models;

namespace WinterWorkShop.Cinema.Data
{
    public class Database
    {
        public List<MovieModel> GetAllMoviesResponses = new List<MovieModel>
        {
            new MovieModel { Id = 1, Name = "Spiderman 1",Genre="Action",Duration=97,Rating=8.5},
            new MovieModel { Id = 2, Name = "Spiderman 2",Genre="Action",Duration=105,Rating=9.0},
            new MovieModel { Id = 3, Name ="Superman",Genre="Action",Duration=93,Rating=8.3 }
        };
        
        public List<ProjectionModel> Projections = new List<ProjectionModel>()
        {
            new ProjectionModel{ ProjectionId=1,Date=DateTime.Now,AuditoriumName="MediumAuditorium",MovieID=2},
            new ProjectionModel{ ProjectionId=2,Date= Convert.ToDateTime("02/03/2022"),AuditoriumName="SmallAuditorium",MovieID=1},
            new ProjectionModel{ ProjectionId=3,Date= Convert.ToDateTime("02/05/2022"),AuditoriumName="SmallAuditorium",MovieID=1},
            new ProjectionModel{ ProjectionId=4,Date= Convert.ToDateTime("02/06/2022"),AuditoriumName="MediumAuditorium",MovieID=2},
        };
    }
}
