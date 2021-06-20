using System;
using System.Collections.Generic;
using Goguma.Game.Console;
using Goguma.Game.Object.Quest.Dialog.Exceptions;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DialogText
  {
    public List<CTexts> Texts { get; protected set; }
    public List<string> PAns { get; protected set; }
    public CTexts GeneralText { get; protected set; }

    public DialogText(CTexts genText)
    {
      Texts = new List<CTexts>();
      PAns = new List<string>();
      GeneralText = genText;
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
  }
}