using Mardul.FitnessMobileApp.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mardul.FitnessMobileApp.Service
{
    [Headers("Content-Type: application/json")]
    public interface IFitnessWebApi
    {

        [Post("/api/account/login")]
        Task<ApiResponse<Token>> Login( User user);

        [Post("/api/account/register")]
        Task<ApiResponse<Token>> Register(User user);

        [Get("/api/workout")]
        Task<IEnumerable<Workout>> GetWorkouts([Header("Authorization")] string token);

        [Get("/api/exercise")]
        Task<IEnumerable<Exercise>> GetExercises([Header("Authorization")] string token);


    }
}
