
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;

namespace MinorProject3.Web.Pages.Trainers;

public class EditModel : PageModel
{
    private readonly TrainerRepository _trainerRepo;

    public EditModel(TrainerRepository trainerRepo)
    {
        _trainerRepo = trainerRepo;
    }

    [BindProperty]
    public Trainer Trainer { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var trainer = _trainerRepo.GetTrainerById(id);

        if (trainer == null)
            return NotFound();

        Trainer = trainer;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Trainer.FirstName) ||
            string.IsNullOrWhiteSpace(Trainer.LastName) ||
            string.IsNullOrWhiteSpace(Trainer.Email) ||
            string.IsNullOrWhiteSpace(Trainer.Specialty))
        {
            ModelState.AddModelError("", "Please fill in all fields.");
            return Page();
        }

        _trainerRepo.UpdateTrainer(Trainer);

        return RedirectToPage("./Index");
    }
}
