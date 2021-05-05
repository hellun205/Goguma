using Goguma.game.Console;
using static Goguma.game.Console.ConsoleFunction;
using static System.ConsoleColor;
using static System.Console;

namespace Goguma.game
{
  static class InGame
  {
    public static void TestConsole()
    {

      CTexts cTexts = new CTexts();

      cTexts.Texts.Add(new ColorText("당신은 "));
      cTexts.Texts.Add(new ColorText("김민재", Blue));
      cTexts.Texts.Add(new ColorText("입니다.\n "));

      PrintText(cTexts);
      Read();

      cTexts.Texts.Clear();

      cTexts.Texts.Add(new ColorText("역겹네요", Red));

      PrintText(cTexts);

      Read();
      Read();

    }

    public static void Go()
    {

    }
  }
}
