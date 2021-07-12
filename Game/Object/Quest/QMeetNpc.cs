using System;
using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public abstract class QMeetNpc : Quest
  {
    public virtual List<NpcList> MeetNpcs => new() { CompleteNpc.Type };
    public List<NpcList> MetNpcs { get; set; }
    public override QuestType Type => QuestType.MEET_NPC;

    protected QMeetNpc() : base()
    {
      MetNpcs = new();
    }

    public void OnMeetNpc(NpcList npc)
    {
      if (!MetNpcs.Contains(npc))
      {
        MetNpcs.Add(npc);
      }

      CheckAvailableComplete();
    }

    public override bool IsCompleted
    {
      get
      {
        foreach (var mNpc in MeetNpcs)
        {
          if (!MetNpcs.Contains(mNpc))
            return false;
        }
        return true;
      }
    }

    protected override CTexts InfoDetails()
    {
      var resCT = new CTexts();
      foreach (var np in MeetNpcs)
      {
        var npc = Npcs.Get(np);
        resCT.Append(npc.DisplayName).Append($"{{(을)를 만나기 }}{{{(MetNpcs.Contains(np) ? $"( 완료 ), {Colors.txtSuccess}" : "( 진행 중 )")}}}{{\n}}");
      }

      return resCT;
    }
  }
}