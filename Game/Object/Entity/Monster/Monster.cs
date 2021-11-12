using Goguma.Game.Object.Entity.Monster.Monsters;

namespace Goguma.Game.Object.Entity.Monster
{
  public static partial class Monster
  {
    static public IMonster GetInstance(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TEST_MONSTER: return MTestMonster;

        case MonsterList.SLIME: return MSlime;

        case MonsterList.GOBLIN: return MGoblin;

        case MonsterList.GOLD_GOBLIN: return MGoldGoblin;

        default: return null;
      }
    }

    static public IMonster GetNew(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TEST_MONSTER: return new MobTestMonster();

        case MonsterList.SLIME: return new MobSlime();

        case MonsterList.GOBLIN: return new MobGoblin();

        case MonsterList.GOLD_GOBLIN: return new MobGoldGoblin();

        default: return null;
      }
    }
  }
}
