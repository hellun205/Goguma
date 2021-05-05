using System;

namespace Goguma.game.Console
{
  class ColorText
  {
    public ConsoleColor ForegroundColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public string Text { get; set; }


    public ColorText(string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
      BackgroundColor = backgroundColor;
      ForegroundColor = foregroundColor;
      Text = text;
    }
  }
}
