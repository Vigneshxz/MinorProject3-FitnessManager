
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;

namespace MinorProject3.Web.Pages;

public class AdminModel : PageModel
{
    private readonly ClientRepository _clientRepo;
    private readonly TrainerRepository _trainerRepo;
    private readonly ExerciseRepository _exerciseRepo;

    public int TotalClients { get; set; }
    public int TotalTrainers { get; set; }
    public int TotalExercises { get; set; }

    public AdminModel(
        ClientRepository clientRepo,
        TrainerRepository trainerRepo,
        ExerciseRepository exerciseRepo)
    {
        _clientRepo = clientRepo;
        _trainerRepo = trainerRepo;
        _exerciseRepo = exerciseRepo;
    }

    public void OnGet()
    {
        TotalClients = _clientRepo.GetAllClients().Count;
        TotalTrainers = _trainerRepo.GetAllTrainers().Count;
        TotalExercises = _exerciseRepo.GetAllExercises().Count;
    }
}
