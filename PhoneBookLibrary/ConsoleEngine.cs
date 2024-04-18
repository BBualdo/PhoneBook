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

  public static void ShowTitle()
  {
    Rule rule = new Rule("Phone Book").RoundedBorder().Centered();
    rule.Style = new Style(Color.MediumOrchid1);

    AnsiConsole.Write(rule);
  }
}