using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Quest.Exceptions;

namespace Goguma.Game.Object.Quest
{
  abstract class QKillEntity : Quest
  {
    public abstract List<Entitys> Entitys { get; protected set; }

    public QKillEntity() : base()
    {
      // Entitys = new List<Entitys>();
    }

    public void OnKillEntity(MonsterList entity)
    {
      foreach (var item in Entitys)
        if (item.Mob == entity)
        {
          Entitys[Entitys.IndexOf(item)].Kill();
          return;
        }
      throw new EntityNotInEntityList();
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
        var ent = Monsters.Get(entity.Mob);
        var index = Entitys.IndexOf(entity);
        resCT.Append(ent.Name)
        .Append($"{{ {Entitys[index].Count} 마리 처치 - ( {Entitys[index].KilledCount} / {Entitys[index].Count} )\n,{(Entitys[index].KilledCount >= Entitys[index].Count ? Colors.txtSuccess : Colors.txtDefault)}}}");
      }
      return resCT;
    }
  }
}