using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goguma.Game.Object.Interface
{
  interface IConsumeItem : IItem
  {
    void UseItem(IPlayer toPlayer);
  }
}
