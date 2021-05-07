using System;
using Goguma.Game;
using Colorify;
using Goguma.Game.Console;
using Colorify.UI;

namespace Gogu_Remaster
{
  class Program
  {

    static void Main(string[] args)
    {
      ConsoleFunction.colorify = new Format(Theme.Dark);
      ConsoleFunction.colorify.ResetColor();
      ConsoleFunction.colorify.Clear();

      InGame.Go();
    }
  }
}
