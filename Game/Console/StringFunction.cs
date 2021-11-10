using System;
using System.Text;
using Colorify;

namespace Goguma.Game.Console
{
  public static class StringFunction
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

    static public CTexts NumberColor(double number, string unit = "", string minusColor = Colors.txtDanger, string plusColor = Colors.txtInfo, string zeroColor = Colors.txtMuted)
    {
      CTexts resultCt = new CTexts();
      var resultColor = Colors.txtDefault;
      resultCt.texts.Add(new CText((/*(int)*/number).ToString()));

      if (number > 0)
      {
        resultColor = plusColor;
        resultCt.texts[0].Text = resultCt.texts[0].Text.Insert(0, "+");
      }
      else if (number == 0)
        resultColor = zeroColor;
      else if (number < 0)
        resultColor = minusColor;

      resultCt.texts[0].Color = resultColor;
      if (unit != "") resultCt.Add($" {unit}", resultColor);

      return resultCt;
    }

    static public string GetSep(int length, string txt = "")
    {
      var sb = new StringBuilder();

      if (txt == "")
      {
        for (var i = 0; i < length; i++) sb.Append("=");
      }
      else if (txt.Length % 2 == 0)
      {
        var l = (length - txt.Length) / 2 - 1;
        for (var i = 0; i < l; i++) sb.Append("=");
        sb.Append($" {txt} ");
        for (var i = 0; i < l; i++) sb.Append("=");
      }
      else
      {
        var l = (length - txt.Length - 1) / 2 - 1;
        for (var i = 0; i < l; i++) sb.Append("=");
        sb.Append($" {txt} ");
        for (var i = 0; i < l + 1; i++) sb.Append("=");
      }

      return sb.ToString();
    }

    static public string ColorByHp(double hp, double maxHp)
    {
      if (hp >= (maxHp * 0.6))
        return Colors.txtSuccess;
      else if (hp >= (maxHp * 0.3))
        return Colors.txtWarning;
      else
        return Colors.txtDanger;
    }

    static public string ColorByLevel(int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return Colors.txtDanger;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return Colors.txtWarning;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return Colors.txtSuccess;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return Colors.txtPrimary;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return Colors.txtPrimary;
      else
        return Colors.txtDefault;
    }

    static public double DamageByLevel(double damage, int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return damage * 0.3;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return damage * 0.5;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return damage * 1;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return damage * 1.5;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return damage * 3;
      else
        return damage;
    }

    static public int ExpByLevel(double exp, int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return (int)(exp * 0.2);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return (int)(exp * 0.8);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return (int)(exp * 1);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return (int)(exp * 0.8);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return (int)(exp * 0.2);
      else
        return (int)exp;
    }

    static public int GoldByLevel(double gold, int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return (int)(gold * 0.1);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return (int)(gold * 0.9);
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return (int)(gold * 1);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return (int)(gold * 0.9);
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return (int)(gold * 0.1);
      else
        return (int)gold;
    }

    static public CTexts GetPerStr(double inte, double maxinte, string filledColor = Colors.txtDefault, string emptiedColor = Colors.txtMuted, string chr = "|")
    {
      var resCt = new CTexts();
      var perc = (int)(inte / maxinte * 10);
      var fillSb = new StringBuilder();
      var emptySb = new StringBuilder();
      for (var i = 0; i < perc; i++)
        fillSb.Append(chr);
      for (var i = 0; i < 10 - perc; i++)
        emptySb.Append(chr);

      resCt.Add(fillSb.ToString(), filledColor);
      resCt.Add(emptySb.ToString(), emptiedColor);
      return resCt;
    }
  }
}
