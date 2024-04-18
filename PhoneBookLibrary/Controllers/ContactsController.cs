using PhoneBookLibrary.Models;
using Spectre.Console;

namespace PhoneBookLibrary.Controllers;

public static class ContactsController
{
  public static List<Contact>? GetAllContacts()
  {
    using PhoneBookContext db = new();

    if (db.Contacts.ToList().Count == 0)
    {
      AnsiConsole.Markup("[red]Contacts list is empty.[/] Create one first. ");
      return null;
    }

    return [.. db.Contacts];
  }

  public static void InsertContact(Contact contact)
  {
    using PhoneBookContext db = new();

    db.Add(contact);
    int stateChanges = db.SaveChanges();

    if (stateChanges == 0) AnsiConsole.Markup("[red]Contact adding failed. [/]");
    else AnsiConsole.Markup("[green]Contact added! [/]");
  }
}
