using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Entity.Monster;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;

namespace Goguma.Game.Object.Battle
{
  class Battle
  {
    static public void PvE(IPlayer player, IMonster monster)
    {
      while (true)
      {
        var scene = BattleScene.PvE.Meet.Scean(player, monster);
        switch (scene.GetString)
        {
          case "플레이어 정보 보기":
            player.PrintAbout();
            break;
          case "몬스터 정보 보기":
            monster.PrintAbout();
            break;
          case "싸우기":
            PvEStart(player, monster);
            break;
          case "도망 가기":
            PrintText(BattleScene.PvE.Run());
            return;
        }
      }
    }
    static private void PvEStart(IPlayer player, IMonster monster)
    {
      // TO DO
    }
    static public string ColorByLevel(int playerLevel, int monsterLevel)
    {
      if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return Colors.txtDanger;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return Colors.txtWarning;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return Colors.txtSuccess;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return Colors.txtPrimary;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return Colors.txtPrimary;
      else
        return Colors.txtDefault;
    }
    static public double DamageByLevel(double damage, int playerLevel, int monsterLevel)
    {
      if (playerLevel == monsterLevel) return damage;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel > 10)
        return damage * 0.3;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 10)
        return damage * 0.5;
      else if (playerLevel < monsterLevel && monsterLevel - playerLevel <= 5 || playerLevel > monsterLevel && playerLevel - monsterLevel <= 5 || playerLevel == monsterLevel)
        return damage * 1;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel <= 10)
        return damage * 1.5;
      else if (playerLevel > monsterLevel && playerLevel - monsterLevel > 10)
        return damage * 3;
      else
        return damage;
    }
  }
}