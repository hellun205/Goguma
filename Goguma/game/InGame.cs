using Goguma.game.Console;
using static Goguma.game.Console.ConsoleFunction;
using static System.ConsoleColor;
using static System.Console;

namespace Goguma.game
{
  static class InGame
  {

    public static void Go()
    {
      Test();
    }

    public static void Test()
    {
      CTexts questionCText = CTexts.Make("{TEST QUESTION!, cyan}");
      SelectSceneItems selectSceneItems = new SelectSceneItems();

      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{test1 Red, red}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{test2 Blue, blue}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make("{test3 Yellow, yellow}")));

      PrintText(SelectScene(questionCText, selectSceneItems).ToString());

      Pause();
    }


  }
}
