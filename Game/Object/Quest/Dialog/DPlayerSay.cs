using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Npc;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DPlayerSay : Dialog
  {
    public List<string> PlayerSays { get; set; }
    public override DialogType Type => DialogType.PLAYER_SAY;

    public DPlayerSay(NpcList npc, CTexts text, List<string> playerText) : base(npc, new DialogText(text, Npcs.Get(npc).DisplayName))
    {
      PlayerSays = playerText;
    }
    public override string Show(string playerAns)
    {
      var ssi = new SelectSceneItems();
      foreach (var str in PlayerSays)
        ssi.Add($"{{{str}}}");

      var ss = new SelectScene(Text.DisplayText(playerAns), ssi, true, CTexts.Make($"{{대화 종료, {Colors.txtMuted}}}"));
      isCancelled = ss.isCancelled;

      return ss.getString;
    }
  }
}