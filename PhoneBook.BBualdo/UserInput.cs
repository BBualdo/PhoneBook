using PhoneBook.BBualdo.Helpers;
using Spectre.Console;

namespace PhoneBook.BBualdo;

public class UserInput
{
  public static string GetGroupName(string name = "group of contacts")
  {
    string groupName = AnsiConsole.Ask<string>($"[mediumorchid1]Enter new name for a [cyan1]{name}[/]: [/]");

    while (!GroupNameValidator.IsValid(groupName))
    {
      groupName = AnsiConsole.Ask<string>("[cyan1]Try again: [/]");
    }

    return groupName;
  }

  public static int GetGroupId()
  {
    int groupId = AnsiConsole.Ask<int>("[mediumorchid1]Enter ID of group you want to interact with: [/]");

    return groupId;
  }
}
