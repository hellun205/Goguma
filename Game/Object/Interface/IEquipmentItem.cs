using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goguma.Game.Object.Interface
{
  interface IEquipmentItem : IItem
  {
    Enum.EquipmentType EquipmentType { get; set; }
    int IncreaseAttDmg { get; set; }
    int IncreaseDefPer { get; set; }
    int IncreaseMaxHp { get; set; }
    int IncreaseMaxEp { get; set; }

  }
}
