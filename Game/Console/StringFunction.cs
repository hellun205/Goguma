using System;
using Colorify;

namespace Goguma.Game.Console
{
  static class StringFunction
  {
    static public bool IsInt(string text)
    {
      var result = Int32.TryParse(text, out int n);
      return result;
    }

    static public string Splits(string strings, char char1, char? char2 = null)
    {
      if (char2 == null)
        char2 = char1;

      string stringA;

      try
      {
        stringA = strings.Split(char1)[1].Split((char)char2)[0];
      }
      catch
      {
        return "";
      }
      return stringA;
    }

    static public CText NumberColor(int number, string minusColor, string plusColor, string zeroColor = Colors.txtDefault)
    {
      CText resultCT = new CText();
      var resultColor = Colors.txtDefault;

      if (number > 0)
        resultColor = plusColor;
      else if (number == 0)
        resultColor = zeroColor;
      else if (number < 0)
        resultColor = minusColor;
      
      resultCT.Text = number.ToString();
      resultCT.Color = resultColor;

      return resultCT;
    }
  }
}
