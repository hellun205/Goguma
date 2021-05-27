using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest.Dialog.Exception;

namespace Goguma.Game.Object.Quest.Dialog
{
  class DialogText
  {
    public List<CTexts> Texts { get; protected set; }
    public List<string> PAns { get; protected set; }
    public CTexts GenText { get; protected set; }

    public DialogText(CTexts genText)
    {
      Texts = new List<CTexts>();
      PAns = new List<string>();
      GenText = genText;
    }

    public DialogText Add(string playerAns, CTexts text)
    {
      if (PAns.Contains(playerAns)) throw new AlreadyExistDialogText();
      PAns.Add(playerAns);
      Texts.Add(text);
      return this;
    }

    public CTexts Get(string playerAns)
    {
      foreach (var item in PAns)
      {
        if (item == playerAns)
          return Texts[PAns.IndexOf(item)];
      }
      return Get();
    }

    public CTexts Get()
    {
      return GenText;
    }
  }
}