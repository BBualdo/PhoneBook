using PhoneBookLibrary.Models;
using Spectre.Console;

namespace PhoneBookLibrary.Controllers;

public static class ContactsController
{
  public static List<Contact>? GetAllContacts()
  {
    using PhoneBookContext db = new PhoneBookContext();

    if (db.Contacts.ToList().Count == 0)
    {
      AnsiConsole.Markup("[red]Contacts list is empty.[/] Create one first. ");
      return null;
    }

    return [.. db.Contacts];
  }
}
