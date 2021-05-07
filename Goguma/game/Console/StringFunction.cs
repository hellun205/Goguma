using System;

namespace Goguma.Game.Console
{
  static class StringFunction
  {
    static public bool IsInt(string text)
    {
      bool result = Int32.TryParse(text, out int n);
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

  }
}
