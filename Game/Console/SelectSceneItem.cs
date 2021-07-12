using System;

namespace Goguma.Game.Console
{
  [Serializable]
  public class SelectSceneItem
  {
    public CTexts Texts { get; set; }
    public bool Enabled { get; set; }

    public SelectSceneItem(CTexts texts, bool enabled = true)
    {
      Texts = texts;
      Enabled = enabled;
    }
  }
}
