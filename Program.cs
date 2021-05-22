using System;
using Goguma.Game;
using Colorify;
using Goguma.Game.Console;
using Colorify.UI;
using Goguma.Game.Object.Entity.Player;

namespace Goguma
{
  class Program
  {
    static void Main(string[] args)
    {
      AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

      ConsoleFunction.colorify = new Format(Theme.Dark);
      ConsoleFunction.colorify.ResetColor();
      ConsoleFunction.colorify.Clear();

      InGame.Go();
    }

    static void OnProcessExit(object sender, EventArgs e)
    {
      if (InGame.player != null)
      {
        PlayerSave.SaveCurrentPlayer();
        ConsoleFunction.PrintText("저장되었습니다.");
      }
    }
  }
}
