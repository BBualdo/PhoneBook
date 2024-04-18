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
        ShowContacts();
        PressAnyKey();
        break;
      case "Create Contact":
        CreateContact();
        PressAnyKey();
        break;
      case "Update Contact":
        UpdateContact();
        PressAnyKey();
        break;
      case "Delete Contact":
        DeleteContact();
        PressAnyKey();
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
        PressAnyKey();
        break;
      case "Create Group":
        CreateGroup();
        PressAnyKey();
        break;
      case "Update Group":
        UpdateGroup();
        PressAnyKey();
        break;
      case "Delete Group":
        DeleteGroup();
        PressAnyKey();
        break;
    }
  }

  #region Contact Methods
  private void ShowContacts()
  {
    List<Contact>? contacts = ContactsController.GetAllContacts();

    if (contacts == null) return;

    ConsoleEngine.ShowContactsTable(contacts);
  }

  private void CreateContact()
  {

  }

  private void UpdateContact()
  {
  }

  private void DeleteContact() { }
  #endregion

  #region Group Methods

  private void DeleteGroup()
  {
    ShowGroups();
    int? groupId = UserInput.GetGroupId();
    if (groupId == null) return;
    Group? group = GroupsController.GetGroupById((int)groupId);
    if (group == null) return;

    GroupsController.DeleteGroup(group);
  }

  private void UpdateGroup()
  {
    ShowGroups();
    int? groupId = UserInput.GetGroupId();
    if (groupId == null) return;
    Group? group = GroupsController.GetGroupById((int)groupId);
    if (group == null) return;

    string? newName = UserInput.GetGroupName(group.Name);
    if (newName == null) return;
    group.Name = newName;

    GroupsController.UpdateGroup(group);
  }

  private void CreateGroup()
  {
    string? groupName = UserInput.GetGroupName();
    if (groupName == null) return;

    GroupsController.InsertGroup(groupName);
  }

  private void ShowGroups()
  {
    List<Group>? groups = GroupsController.GetGroups();

    if (groups == null) return;

    ConsoleEngine.ShowGroupsTable(groups);
  }
  #endregion

  private void PressAnyKey()
  {
    AnsiConsole.Markup("\n[cyan1]Press any key to continue.[/]");
    Console.ReadKey();
  }
}