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

    public DPlayerSay(NpcList npc, DialogText text, List<string> playerText) : base(npc, text)
    {
      PlayerSays = playerText;
    }

    public DPlayerSay(NpcList npc, CTexts text, List<string> playerText) : base(npc, new DialogText(text))
    {
      PlayerSays = playerText;
    }
    public override string Show(string playerAns)
    {
      var ssi = new SelectSceneItems();
      foreach (var str in PlayerSays)
        ssi.Add($"{{{str}}}");

      var ss = new SelectScene(NpcText(playerAns), ssi, true, CTexts.Make($"{{대화 종료, {Colors.txtMuted}}}"));
      isCancelled = ss.isCancelled;

      return ss.getString;
    }
  }
}