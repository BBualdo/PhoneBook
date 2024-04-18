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
  private bool ShowContacts()
  {
    List<Contact>? contacts = ContactsController.GetAllContacts();

    if (contacts == null) return false;

    ConsoleEngine.ShowContactsTable(contacts);
    return true;
  }

  private void CreateContact()
  {
    string name = UserInput.GetContactName();
    if (name == "0") return;
    string? email = UserInput.GetEmail(name);
    if (email == "0") return;

    string phoneNumber = UserInput.GetPhoneNumber(name);
    if (phoneNumber == "0") return;

    List<Group>? groups = GroupsController.GetGroups();
    int? groupId = null;

    if (groups != null)
    {
      ConsoleEngine.ShowGroupsTable(groups);
      groupId = UserInput.OptionallyGetGroupId();
      if (groupId == 0) return;
    }

    Contact contact = new() { Name = name, Email = email, PhoneNumber = phoneNumber, GroupId = groupId };

    ContactsController.InsertContact(contact);
  }

  private void UpdateContact()
  {
    if (ShowContacts())
    {
      int contactId = UserInput.GetId("contact");
      if (contactId == 0) return;

      Contact? contact = ContactsController.GetContactById(contactId);
      if (contact == null) return;

      string name = UserInput.GetContactName(contact.Name);
      if (name == "0") return;
      string? email = UserInput.GetEmail(name);
      if (email == "0") return;
      string phoneNumber = UserInput.GetPhoneNumber(name);
      if (phoneNumber == "0") return;

      List<Group>? groups = GroupsController.GetGroups();
      int? groupId = null;

      if (groups != null)
      {
        ConsoleEngine.ShowGroupsTable(groups);
        groupId = UserInput.OptionallyGetGroupId();
        if (groupId == 0) return;
        if (groupId == null) groupId = contact.GroupId;
      }

      contact.Name = name;
      contact.Email = email;
      contact.PhoneNumber = phoneNumber;
      contact.GroupId = groupId;

      ContactsController.UpdateContact(contact);
    }
  }

  private void DeleteContact()
  {
    if (ShowContacts())
    {
      int contactId = UserInput.GetId("contact");
      if (contactId == 0) return;
      Contact? contact = ContactsController.GetContactById(contactId);
      if (contact == null) return;

      ContactsController.DeleteContact(contact);
    }
  }
  #endregion

  #region Group Methods

  private void DeleteGroup()
  {
    if (ShowGroups())
    {
      int groupId = UserInput.GetId("group");
      if (groupId == 0) return;
      Group? group = GroupsController.GetGroupById(groupId);
      if (group == null) return;

      GroupsController.DeleteGroup(group);
    }
  }

  private void UpdateGroup()
  {
    if (ShowGroups())
    {
      int groupId = UserInput.GetId("group");
      if (groupId == 0) return;
      Group? group = GroupsController.GetGroupById(groupId);
      if (group == null) return;

      string newName = UserInput.GetGroupName(group.Name);
      if (newName == "0") return;
      group.Name = newName;

      GroupsController.UpdateGroup(group);
    }
  }

  private void CreateGroup()
  {
    string groupName = UserInput.GetGroupName();
    if (groupName == "0") return;

    GroupsController.InsertGroup(groupName);
  }

  private bool ShowGroups()
  {
    List<Group>? groups = GroupsController.GetGroups();

    if (groups == null) return false;

    ConsoleEngine.ShowGroupsTable(groups);
    return true;
  }
  #endregion

  private void PressAnyKey()
  {
    AnsiConsole.Markup("\n[cyan1]Press any key to continue.[/]");
    Console.ReadKey();
  }
}