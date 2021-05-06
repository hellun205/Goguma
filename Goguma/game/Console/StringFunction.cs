using System;

namespace Goguma.game.Console
{
  static class StringFunction
  {
    static public bool IsInt(string text)
    {
      int n;
      bool result = Int32.TryParse(text, out n);
      return result;
    }

    static public string Splits(string strings, char char1, char? char2 = null)
    {
      if (char2 == null)
        char2 = char1;

      string stringA;

      stringA = strings.Split(char1)[1].Split((char)char2)[0];

      return stringA;
    }

  }
}
