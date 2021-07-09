using System;
using System.Collections.Generic;
using Colorify;
using Colorify.UI;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest.Dialog.Exceptions;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DialogText
  {
    public List<CTexts> Texts { get; set; }
    public List<string> PAns { get; set; }
    public CTexts GeneralText { get; set; }
    public bool HasPrefix { get; private set; }
    public string Name { get; private set; }
    public string[] Prefix { get; private set; }
    public string NameColor { get; private set; }
    public string[] PrefixColor { get; private set; }

    public DialogText(CTexts genText)
    {
      Texts = new List<CTexts>();
      PAns = new List<string>();
      GeneralText = genText;
      HasPrefix = false;
    }

    public DialogText(CTexts genText, string[] prefix, string name, string[] prefixColor, string nameColor = Colors.txtDefault) : this(genText)
    {
      Name = name;
      Prefix = prefix;
      PrefixColor = prefixColor;
      NameColor = nameColor;
      HasPrefix = true;
    }

    public CTexts this[string playerAnswer]
    {
      get
      {
        if (PAns.Count != 0 && playerAnswer != String.Empty)
          foreach (var item in PAns)
          {
            if (item == playerAnswer)
              return Texts[PAns.IndexOf(item)];
          }
        return GeneralText;
      }
      set
      {
        if (PAns.Count != 0)
          foreach (var item in PAns)
          {
            if (item == playerAnswer)
              Texts[PAns.IndexOf(item)] = value;
          }
        else GeneralText = value;
      }
    }

    public string this[CTexts text]
    {
      get
      {
        if (Texts.Count != 0 && text != CTexts.Empty)
          foreach (var item in Texts)
          {
            if (item == text)
              return PAns[Texts.IndexOf(item)];
          }
        return String.Empty;
      }
      set
      {
        if (Texts.Count != 0)
          foreach (var item in Texts)
          {
            if (item == text)
              PAns[Texts.IndexOf(text)] = value;
          }
        else throw new NotExistTextException();
      }
    }

    public DialogText Add(string playerAns, CTexts text)
    {
      if (PAns.Contains(playerAns)) throw new AlreadyExistDialogTextException();
      PAns.Add(playerAns);
      Texts.Add(text);
      return this;
    }

    public CTexts DisplayText(string playerAnswer)
    {
      // return (HasPrefix ? CTexts.Make($"{{[ {Prefix} ] ,{PrefixColor}}}{{{Name},{NameColor}}}{{ : }}").Combine(this[playerAnswer]) : this[playerAnswer]);
      var resCT = new CTexts();
      if (HasPrefix)
        for (var i = 0; i < Prefix.Length; i++)
          resCT.Append($"{{[ {Prefix[i]} ],{PrefixColor[i]}}}");
      resCT.Append($"{{ {Name},{NameColor}}}{{ : }}")
      .Append(this[playerAnswer]);

      return resCT;
    }
  }
}