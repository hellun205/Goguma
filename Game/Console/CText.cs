using System;
using Colorify;

namespace Goguma.Game.Console
{
  [Serializable]
  class CText
  {
    public string Color { get; set; }
    public string Text { get; set; }

    public CText()
    {
      Text = "";
      Color = Colors.txtDefault;
    }
    public CText(string text, string color = Colors.txtDefault)
    {
      Color = color;
      Text = text;
    }
  }
}