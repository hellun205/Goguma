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

      ConsoleFunction.Colorify = new Format(Theme.Dark);
      ConsoleFunction.Colorify.ResetColor();
      ConsoleFunction.Colorify.Clear();

      InGame.Go();
    }

    static void OnProcessExit(object sender, EventArgs e)
    {
      if (InGame.player != null)
      {
        PlayerSave.SaveCurrentPlayer();
        ConsoleFunction.PrintText("고구마 저장 완료");
      }
    }
  }
}
