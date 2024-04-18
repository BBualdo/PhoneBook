using Spectre.Console;

namespace PhoneBook.BBualdo.Helpers;

public class GroupNameValidator
{
  public static bool IsValid(string groupName)
  {
    if (int.TryParse(groupName, out _))
    {
      AnsiConsole.Markup("[red]Name can't be numeric. [/]\n");
      return false;
    }

    return true;
  }
}
