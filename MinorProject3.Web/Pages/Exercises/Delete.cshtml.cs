
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;
using MySqlConnector;

namespace MinorProject3.Web.Pages.Exercises;

public class DeleteModel : PageModel
{
    private readonly ExerciseRepository _exerciseRepo;

    public DeleteModel(ExerciseRepository exerciseRepo)
    {
        _exerciseRepo = exerciseRepo;
    }

    public Exercise Exercise { get; set; } = new();

    public string ErrorMessage { get; set; } = "";

    public IActionResult OnGet(int id)
    {
        var exercise = _exerciseRepo.GetExerciseById(id);

        if (exercise == null)
            return NotFound();

        Exercise = exercise;
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        try
        {
            if (!_exerciseRepo.DeleteExercise(id))
                return NotFound();

            return RedirectToPage("./Index");
        }
        catch (MySqlException ex) when (ex.Number == 1451)
        {
            ErrorMessage =
                "This exercise has related records and cannot be deleted.";

            var exercise = _exerciseRepo.GetExerciseById(id);

            if (exercise == null)
                return NotFound();

            Exercise = exercise;
            return Page();
        }
    }
}
