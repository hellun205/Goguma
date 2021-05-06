using System.Collections.Generic;

namespace Goguma.game.Console
{
  class CTexts
  {
    public List<CText> Texts { get; set; }

    public CTexts()
    {
      Texts = new List<CText>();
    }

    public void Combine(CTexts cTexts)
    {
      for(int i = 0; i < cTexts.Texts.Count; i++)
      {
        Texts.Add(cTexts.Texts[i]);
      }
    }

  }
}
