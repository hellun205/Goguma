using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public abstract class QKillEntity : Quest
  {
    public List<Entitys> Entitys { get; set; }

    public override QuestType Type => QuestType.KILL_ENTITY;

    protected QKillEntity() : base()
    {
      Entitys = new List<Entitys>();
    }

    public void OnKillEntity(MonsterList entity)
    {
      for (var i = 0; i < Entitys.Count; i++)
        if (Entitys[i].Mob == entity)
        {
          Entitys[i].Kill();
          // return;
        }
      // throw new EntityNotInEntityList();
      CheckAvailableComplete();
    }

    public override bool IsCompleted
    {
      get
      {
        foreach (var entity in Entitys)
          if (entity.Count != entity.KilledCount) return false;
        return true;
      }
    }

    protected override CTexts InfoDetails()
    {
      var resCT = new CTexts();
      foreach (var entity in Entitys)
      {
        var ent = Monster.GetInstance(entity.Mob);
        resCT.Append($"{{{ent.Name},{Colors.txtInfo}}}{{ {entity.Count} 마리 처치 - }}{{( {entity.KilledCount} / {entity.Count} )\n,{(entity.KilledCount >= entity.Count ? Colors.txtSuccess : Colors.txtDefault)}}}");
      }

      return resCT;
    }
  }
}