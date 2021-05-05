using System;

namespace Goguma.game.Console
{
  class ColorText
  {
    public ConsoleColor ForegroundColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }
    public string Text { get; set; }


    public ColorText(ConsoleColor backgroundColor, ConsoleColor foregroundColor, string text)
    {
      BackgroundColor = backgroundColor;
      ForegroundColor = foregroundColor;
      Text = text;
    }
  }
}
