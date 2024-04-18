using PhoneBookLibrary;
using PhoneBookLibrary.Controllers;
using PhoneBookLibrary.Models;
using Spectre.Console;

namespace PhoneBook.BBualdo;

internal class AppEngine
{
  public bool IsRunning;

  public AppEngine()
  {
    IsRunning = true;
  }

  internal void MainMenu()
  {
    AnsiConsole.Clear();
    ConsoleEngine.ShowTitle();

    List<string> choices = [
      "Manage Contacts",
      "Manage Groups",
      "Quit"
    ];

    string choice = ConsoleEngine.GetChoiceOption("What would you like to do?", choices);

    switch (choice)
    {
      case "Manage Contacts":
        ContactsMenu();
        break;
      case "Manage Groups":
        GroupsMenu();
        break;
      case "Quit":
        AnsiConsole.Markup("[cyan1]Goodbye![/]\n");
        IsRunning = false;
        break;
    }
  }

  internal void ContactsMenu()
  {
    AnsiConsole.Clear();
    ConsoleEngine.ShowTitle();

    List<string> choices = [
      "Back",
      "Show Contacts",
      "Create Contact",
      "Update Contact",
      "Delete Contact"
      ];

    string choice = ConsoleEngine.GetChoiceOption("", choices);

    switch (choice)
    {
      case "Back":
        return;
      case "Show Contacts":
        break;
      case "Create Contact":
        break;
      case "Update Contact":
        break;
      case "Delete Contact":
        break;
    }
  }

  internal void GroupsMenu()
  {
    AnsiConsole.Clear();
    ConsoleEngine.ShowTitle();

    List<string> choices = [
      "Back",
      "Show Groups",
      "Create Group",
      "Update Group",
      "Delete Group"
      ];

    string choice = ConsoleEngine.GetChoiceOption("", choices);

    switch (choice)
    {
      case "Back":
        return;
      case "Show Groups":
        ShowGroups();
        break;
      case "Create Group":
        break;
      case "Update Group":
        break;
      case "Delete Group":
        break;
    }
  }

  private void ShowGroups()
  {
    List<Group>? groups = GroupsController.GetGroups();

    if (groups == null) { PressAnyKey(); return; }

    ConsoleEngine.ShowGroupsTable(groups);

    PressAnyKey();
  }

  private void PressAnyKey()
  {
    AnsiConsole.Markup("\n[cyan1]Press any key to continue.[/]");
    Console.ReadKey();
  }
}