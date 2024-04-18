using PhoneBookLibrary.Models;
using Spectre.Console;

namespace PhoneBookLibrary;

public static class ConsoleEngine
{
  public static string GetChoiceOption(string title, List<string> choices)
  {
    SelectionPrompt<string> prompt = new SelectionPrompt<string>()
                                    .Title(title)
                                    .AddChoices(choices);

    prompt.HighlightStyle = new Style(Color.Cyan1);

    string choice = AnsiConsole.Prompt(prompt);

    return choice;
  }

  public static void ShowGroupsTable(List<Group> groups)
  {
    Table table = new Table().Title("Contact Groups");
    table.AddColumn(new TableColumn("[mediumorchid1]ID[/]"));
    table.AddColumn(new TableColumn("[mediumorchid1]Name[/]"));
    table.AddColumn(new TableColumn("[mediumorchid1]Contacts[/]"));

    foreach (Group group in groups)
    {
      table.AddRow(group.GroupId.ToString(), group.Name);

      foreach (Contact contact in group.Contacts)
      {
        table.AddRow(contact.Name);
      }
    }

    AnsiConsole.Write(table);
  }

  public static void ShowTitle()
  {
    Rule rule = new Rule("Phone Book").RoundedBorder().Centered();
    rule.Style = new Style(Color.MediumOrchid1);

    AnsiConsole.Write(rule);
  }
}