using System;
using System.Collections.Generic;

namespace Goguma.Game.Console
{
  [Serializable]
  public class SelectSceneItems
  {
    public List<SelectSceneItem> Items { get; set; }

    public SelectSceneItems()
    {
      Items = new List<SelectSceneItem>();
    }

    public SelectSceneItems Add(SelectSceneItem item)
    {
      this.Items.Add(item);
      return this;
    }

    public SelectSceneItems Add(CTexts texts, bool isEnabled = true)
    {
      this.Add(new SelectSceneItem(texts, isEnabled));
      return this;
    }

    public SelectSceneItems Add(string text, bool isEnabled = true)
    {
      this.Add(CTexts.Make(text), isEnabled);
      return this;
    }
  }
}
