using System.Collections.Generic;
using Goguma.Game.Object.Skill;
using System.Linq;
using System;

namespace Goguma.Game.Object.Entity.AttackSystem
{
  public class AttackSyss
  {
    public List<AttCondition> Items { get; set; }

    public AttackSyss()
    {
      Items = new();
    }

    public AttCondition this[int index] => Items[index];

    public void Add(ISkill skill, AttCondition cond)
    {
      Items.Add(cond);
    }

    // public ISkill Get(out List<ISkill> slist)
    // {
    //   var skills = from it in Items
    //                where it.Get()
    //                select Skill[Items.IndexOf(it)];
    //   var sList = skills.ToList<ISkill>();
    //   slist = sList;
    //   if (sList.Count == 0) return null;
    //   else return sList[new Random().Next(0, sList.Count)];
    // }

    public ISkill Exe()
    {
      var items = (from it in Items
                   where it.Get()
                   orderby it.Priority
                   select it).ToList();

      if (items.Count > 0 && items[^1].Priority >= 0)
        for (var i = 0; i <= items[^1].Priority; i++)
        {
          var prItems = (from it in items
                         where it.Priority == i
                         select it).OrderBy(a => Guid.NewGuid()).ToList();

          for (var j = 0; j < prItems.Count; j++)
          {
            if (prItems[j].Use())
            {
              return prItems[j].Skill;
            }
          }

        }
      return null;
    }
  }
}