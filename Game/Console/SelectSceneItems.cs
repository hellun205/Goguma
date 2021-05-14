using System;
using System.Collections.Generic;
using System.ComponentModel;

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

    public void Add(SelectSceneItem item)
    {
      this.Items.Add(item);
    }
  }
}
