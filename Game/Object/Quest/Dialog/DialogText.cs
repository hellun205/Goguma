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
    public CTexts Prefix { get; private set; }

    public DialogText(CTexts genText)
    {
      Texts = new List<CTexts>();
      PAns = new List<string>();
      GeneralText = genText;
      HasPrefix = false;
    }

    public DialogText(CTexts genText, CTexts prefix) : this(genText)
    {
      Prefix = prefix;
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
        resCT.Append(Prefix).Append("{ : }");
      resCT.Append(this[playerAnswer]);

      return resCT;
    }
  }
}