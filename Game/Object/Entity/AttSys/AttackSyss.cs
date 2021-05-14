using System.Collections.Generic;
using Goguma.Game.Object.Skill;
using System.Linq;
using System;

namespace Goguma.Game.Object.Entity.AttSys
{
  public class AttackSyss
  {
    public List<AttackSys> Items { get; set; }
    public AttackSyss()
    {
      Items = new List<AttackSys>();
    }
    public AttackSys this[int index]
    {
      get => Items[index];
      set => Items[index] = value;
    }
    public ISkill Get()
    {
      var skills = from it in Items
                   where it.Condition.Get()
                   select it.SkillToUse;
      var sList = skills.ToList<ISkill>();
      if (sList.Count == 0) return null;
      else return sList[new Random().Next(0, sList.Count)];
    }
  }
}