using System.Collections.Generic;
using Goguma.Game.Object.Skill;
using System.Linq;
using System;

namespace Goguma.Game.Object.Entity.AttSys
{
  public class AttackSyss
  {
    private Player.Player mPlayer;
    private Monster.Monster mMonster;
    public List<ISkill> Skill { get; set; }
    public List<AttCondition> Condition { get; set; }
    public AttackSyss(Player.Player player, Monster.Monster monster)
    {
      Skill = new List<ISkill>();
      Condition = new List<AttCondition>();
      mPlayer = player;
      mMonster = monster;
    }
    public void Clear()
    {
      Skill.Clear();
      Condition.Clear();
    }
    public void Add(ISkill skill, AttCondition cond)
    {
      Skill.Add(skill);
      Condition.Add(cond);
      Condition[Condition.Count - 1].player = mPlayer;
      Condition[Condition.Count - 1].monster = mMonster;
    }
    public ISkill Get(out List<ISkill> slist)
    {
      var skills = from it in Condition
                   where it.Get()
                   select Skill[Condition.IndexOf(it)];
      var sList = skills.ToList<ISkill>();
      slist = sList;
      if (sList.Count == 0) return null;
      else return sList[new Random().Next(0, sList.Count)];
    }
  }
}