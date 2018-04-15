using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    public interface IMuscleGroupService
    {
        Task<IEnumerable<MuscleGroup>> GetAll();
    }
}