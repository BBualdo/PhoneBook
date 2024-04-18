using PhoneBookLibrary.Models;
using Spectre.Console;

namespace PhoneBookLibrary.Controllers;

public class GroupsController
{
  public static List<Group>? GetGroups()
  {
    using PhoneBookContext db = new PhoneBookContext();

    if (db.Groups.ToList().Count == 0)
    {
      AnsiConsole.Markup("[red]Groups list is empty.[/] Create one first. ");
      return null;
    }

    return [.. db.Groups];
  }
}
