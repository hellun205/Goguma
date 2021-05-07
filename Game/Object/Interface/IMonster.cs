﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goguma.Game.Object.Interface
{
  interface IMonster
  {
    int Hp { get; set; }  
    int MaxHp { get; set; }

    int AttDmg { get; set; }
    int DefPer { get; set; }

    object Skill { get; set; }

    int GivingGold { get; set; }
    int GivingExp { get; set; }
    List<IItem> DroppingItems { get; set; }

    void AttackPlayer(IPlayer player);

    void UseSkill();

  }
}