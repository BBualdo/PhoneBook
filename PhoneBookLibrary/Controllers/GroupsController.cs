using PhoneBookLibrary.Models;
using Spectre.Console;

namespace PhoneBookLibrary.Controllers;

public class GroupsController
{
  public static List<Group>? GetGroups()
  {
    using PhoneBookContext db = new();

    if (db.Groups.ToList().Count == 0)
    {
      AnsiConsole.Markup("[red]Groups list is empty.[/] Create one first. ");
      return null;
    }

    return [.. db.Groups];
  }

  public static void InsertGroup(string groupName)
  {
    Group group = new() { Name = groupName };

    using PhoneBookContext db = new();
    db.Add(group);
    int stateChanges = db.SaveChanges();

    if (stateChanges == 0) AnsiConsole.Markup("[red]Group adding failed. [/]");
    else AnsiConsole.Markup("[green]Group added! [/]");
  }
}
