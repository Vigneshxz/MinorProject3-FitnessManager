
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;
using MySqlConnector;

namespace MinorProject3.Web.Pages.Trainers;

public class DeleteModel : PageModel
{
    private readonly TrainerRepository _trainerRepo;

    public DeleteModel(TrainerRepository trainerRepo)
    {
        _trainerRepo = trainerRepo;
    }

    public Trainer Trainer { get; set; } = new();

    public string ErrorMessage { get; set; } = "";

    public IActionResult OnGet(int id)
    {
        var trainer = _trainerRepo.GetTrainerById(id);

        if (trainer == null)
            return NotFound();

        Trainer = trainer;
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        try
        {
            if (!_trainerRepo.DeleteTrainer(id))
                return NotFound();

            return RedirectToPage("./Index");
        }
        catch (MySqlException ex) when (ex.Number == 1451)
        {
            ErrorMessage =
                "This trainer has assigned training plans. " +
                "Remove or reassign those plans first.";

            var trainer = _trainerRepo.GetTrainerById(id);

            if (trainer == null)
                return NotFound();

            Trainer = trainer;
            return Page();
        }
    }
}
