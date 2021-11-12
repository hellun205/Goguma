using System.Collections.Generic;
using System.Linq;
using Colorify;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Quest.Dialog
{
  public class DPlayerSays : Dialog
  {
    public List<string> PlayerSays { get; set; }
    public override DialogType Type => DialogType.PLAYER_SAYS;

    public DPlayerSays(CTexts text, string[] playerText) : base(InGame.player.DisplayName, text)
    {
      PlayerSays = playerText.ToList();
    }

    public DPlayerSays(string text, string[] playerText) : this(CTexts.Make(text), playerText) { }

    public override string Show(string playerAns = "")
    {
      var ssi = new SelectSceneItems();
      foreach (var str in PlayerSays)
        ssi.Add($"{{{str}}}");

      var ss = new SelectScene(Text.DisplayText(playerAns), ssi, true, CTexts.Make($"{{대화 종료, {Colors.txtMuted}}}"));
      IsCancelled = ss.isCancelled;

      return ss.getString;
    }
  }
}