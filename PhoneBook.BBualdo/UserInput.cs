using PhoneBook.BBualdo.Helpers;
using Spectre.Console;

namespace PhoneBook.BBualdo;

public class UserInput
{
  public static string? GetGroupName(string name = "group of contacts")
  {
    string groupName = AnsiConsole.Ask<string>($"[mediumorchid1]Enter new name for a [cyan1]{name}[/][white] or type 0 to go back[/]: [/]");

    if (groupName == "0") return null;

    while (!GroupNameValidator.IsValid(groupName))
    {
      groupName = AnsiConsole.Ask<string>("[cyan1]Try again: [/]");
      if (groupName == "0") return null;
    }

    return groupName;
  }

  public static int? GetGroupId()
  {
    int groupId = AnsiConsole.Ask<int>("[mediumorchid1]Enter ID of group you want to interact with [white]or type 0 to go back[/]: [/]");

    if (groupId == 0) return null;

    return groupId;
  }
}
