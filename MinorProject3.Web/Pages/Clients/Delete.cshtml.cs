
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinorProject3.Data;
using MySqlConnector;

namespace MinorProject3.Web.Pages.Clients;

public class DeleteModel : PageModel
{
    private readonly ClientRepository _clientRepo;

    public DeleteModel(ClientRepository clientRepo)
    {
        _clientRepo = clientRepo;
    }

    public Client Client { get; set; } = new();

    public string ErrorMessage { get; set; } = "";

    public IActionResult OnGet(int id)
    {
        var client = _clientRepo.GetClientById(id);

        if (client == null)
            return NotFound();

        Client = client;

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        try
        {
            if (!_clientRepo.DeleteClient(id))
                return NotFound();

            return RedirectToPage("./Index");
        }
        catch (MySqlException ex) when (ex.Number == 1451)
        {
            ErrorMessage =
                "This client has related records. " +
                "Remove or reassign their training plans first.";

            var client = _clientRepo.GetClientById(id);

            if (client == null)
                return NotFound();

            Client = client;

            return Page();
        }
    }
}
