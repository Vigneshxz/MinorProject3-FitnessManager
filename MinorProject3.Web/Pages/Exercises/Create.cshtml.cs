
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;

namespace MinorProject3.Web.Pages.Exercises;

public class CreateModel : PageModel
{
    private readonly ExerciseRepository _exerciseRepo;

    public CreateModel(ExerciseRepository exerciseRepo)
    {
        _exerciseRepo = exerciseRepo;
    }

    [BindProperty]
    public Exercise Exercise { get; set; } = new();

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Exercise.ExerciseName) ||
            string.IsNullOrWhiteSpace(Exercise.MuscleGroup) ||
            string.IsNullOrWhiteSpace(Exercise.Equipment) ||
            string.IsNullOrWhiteSpace(Exercise.Difficulty))
        {
            ModelState.AddModelError("", "Please fill in all fields.");
            return Page();
        }

        _exerciseRepo.AddExercise(Exercise);

        return RedirectToPage("./Index");
    }
}
