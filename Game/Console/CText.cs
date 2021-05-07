using System;

namespace Goguma.Game.Console
{
  class CText
  {
    public ConsoleColor ForegroundColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public string Text { get; set; }

    public CText(string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
      BackgroundColor = backgroundColor;
      ForegroundColor = foregroundColor;
      Text = text;
    }
  }
}
