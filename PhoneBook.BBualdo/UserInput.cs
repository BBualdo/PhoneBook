using PhoneBook.BBualdo.Helpers;
using Spectre.Console;

namespace PhoneBook.BBualdo;

public class UserInput
{
  public static string GetGroupName()
  {
    string groupName = AnsiConsole.Ask<string>("[mediumorchid1]Enter name for a group of contacts: [/]");

    while (!GroupNameValidator.IsValid(groupName))
    {
      groupName = AnsiConsole.Ask<string>("[cyan1]Try again: [/]");
    }

    return groupName;
  }
}
