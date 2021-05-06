using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goguma.game.Console
{
  class SelectSceneItem
  {
    public string Name { get; set; }
    public CTexts Texts { get; set; }
    public bool Enabled { get; set; }

    public SelectSceneItem(string name, CTexts texts, bool enabled = true)
    {
      Name = name;
      Texts = texts;
      Enabled = enabled;
    }
  }
}
