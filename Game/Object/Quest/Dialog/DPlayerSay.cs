using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DPlayerSay : Dialog
  {
    public List<string> PlayerSays { get; set; }
    public override DialogType Type => DialogType.PLAYER_SAY;

    public DPlayerSay(Npc.Npc npc, CTexts text, List<string> playerText) : base(npc, text)
    {
      PlayerSays = playerText;
    }

    public DPlayerSay(Npc.Npc npc, string text, List<string> playerText) : this(npc, CTexts.Make(text), playerText) { }

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