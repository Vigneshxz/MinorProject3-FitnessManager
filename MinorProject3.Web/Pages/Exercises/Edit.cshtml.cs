
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;

namespace MinorProject3.Web.Pages.Exercises;

public class EditModel : PageModel
{
    private readonly ExerciseRepository _exerciseRepo;

    public EditModel(ExerciseRepository exerciseRepo)
    {
        _exerciseRepo = exerciseRepo;
    }

    [BindProperty]
    public Exercise Exercise { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var exercise = _exerciseRepo.GetExerciseById(id);

        if (exercise == null)
            return NotFound();

        Exercise = exercise;
        return Page();
    }

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

        _exerciseRepo.UpdateExercise(Exercise);

        return RedirectToPage("./Index");
    }
}
