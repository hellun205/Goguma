using System.Collections.Generic;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Npc
{
  public struct Prefix
  {
    public List<string> Items { get; set; }
    public List<string> Colors { get; set; }

    public Prefix(string item, string color = Colorify.Colors.txtDefault)
    {
      Items = new() { item };
      Colors = new() { color };
    }

    public Prefix Add(string item, string color = Colorify.Colors.txtDefault)
    {
      Items.Add(item);
      Colors.Add(color);
      return this;
    }

    public Prefix RemoveAt(int index)
    {
      Items.RemoveAt(index);
      Colors.RemoveAt(index);
      return this;
    }

    public Prefix Remove(string item)
    {
      Colors.RemoveAt(Items.IndexOf(item));
      Items.Remove(item);
      return this;
    }

    public CTexts this[int index]
    {
      get => new CTexts().Append($"{{[ {Items[index]} ],{Colors[index]}}}");
    }

    public CTexts Display
    {
      get
      {
        var resCt = new CTexts();
        for (var i = 0; i < Items.Count; i++)
          resCt.Append(this[i]).Append("{ }");

        return resCt;
      }
    }
  }
}
