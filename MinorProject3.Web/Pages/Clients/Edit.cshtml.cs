
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;

namespace MinorProject3.Web.Pages.Clients;

public class EditModel : PageModel
{
    private readonly ClientRepository _clientRepo;

    public EditModel(ClientRepository clientRepo)
    {
        _clientRepo = clientRepo;
    }

    [BindProperty]
    public Client Client { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var existingClient = _clientRepo.GetClientById(id);

        if (existingClient == null)
            return NotFound();

        Client = existingClient;
        return Page();
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Client.FirstName) ||
            string.IsNullOrWhiteSpace(Client.LastName) ||
            string.IsNullOrWhiteSpace(Client.Email))
        {
            ModelState.AddModelError("", "Please fill in all required fields.");
            return Page();
        }

        _clientRepo.UpdateClient(Client);

        return RedirectToPage("./Index");
    }
}
