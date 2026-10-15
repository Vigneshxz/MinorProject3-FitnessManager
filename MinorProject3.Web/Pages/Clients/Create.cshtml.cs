
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;

namespace MinorProject3.Web.Pages.Clients;

public class CreateModel : PageModel
{
    private readonly ClientRepository _clientRepo;

    public CreateModel(ClientRepository clientRepo)
    {
        _clientRepo = clientRepo;
    }

    [BindProperty]
    public Client Client { get; set; } = new();

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Client.FirstName) ||
            string.IsNullOrWhiteSpace(Client.LastName) ||
            string.IsNullOrWhiteSpace(Client.Email))
        {
            ModelState.AddModelError(
                "",
                "Please fill in all required fields."
            );

            return Page();
        }

        _clientRepo.AddClient(Client);

        return RedirectToPage("./Index");
    }
}
