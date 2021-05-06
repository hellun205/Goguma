﻿using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;

namespace Goguma.Game
{
  static class InGame
  {

    public static void Go()
    {
      
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

      CTexts questionCText2 = CTexts.Make("{TEST QUESTION2! Write Any Text!, cyan}");

      PrintText(ReadTextScean(questionCText2));

      Pause();

    }


  }
}
