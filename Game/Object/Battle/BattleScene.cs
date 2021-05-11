

using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Battle
{
  static class BattleScene
  {
    static public class PvE
    {
      static public class Meet
      {
        static public SelectScene Scean(IPlayer player, IMonster monster)
        {
          return new SelectScene(GetQText(player, monster), GetSSI());
        }
        static public CTexts GetQText(IPlayer player, IMonster monster)
        {
          return CTexts.Make($"{{「{monster.Name} [Lv. {monster.Level}]」,{Battle.LevelColor(player.Level, monster.Level)}}} {{(을)를 만났다! 무엇을 하시겠습니까?}}");
        }
        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{플레이어 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{몬스터 정보 보기}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{싸우기, {Colors.txtSuccess}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{도망 가기, {Colors.txtDanger}}}")));
          return resultSSI;
        }
      }
      static public CTexts Run()
      {
        return CTexts.Make($"{{\n싸움에서}} {{ 도망,{Colors.txtDanger}}} {{쳤습니다.\n}}");
      }
    }
  }
}