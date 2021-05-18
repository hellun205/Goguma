using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace Goguma.Game.Console
{
  [Serializable]
  class SelectSceneItems
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

    public SelectSceneItems Add(CTexts texts)
    {
      this.Add(new SelectSceneItem(texts));
      return this;
    }

    public SelectSceneItems Add(string text)
    {
      this.Add(CTexts.Make(text));
      return this;
    }
  }
}
