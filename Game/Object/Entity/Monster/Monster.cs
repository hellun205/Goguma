using Goguma.Game.Object.Entity.Monster.Monsters;

namespace Goguma.Game.Object.Entity.Monster
{
  public static partial class Monster
  {
    static public IMonster GetInstance(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TestMonster: return MTestMonster;

        case MonsterList.Slime: return MSlime;

        case MonsterList.Goblin: return MGoblin;

        case MonsterList.GoldGoblin: return MGoldGoblin;

        default: return null;
      }
    }

    static public IMonster GetNew(MonsterList monster)
    {
      switch (monster)
      {
        case MonsterList.TestMonster: return new MobTestMonster();

        case MonsterList.Slime: return new MobSlime();

        case MonsterList.Goblin: return new MobGoblin();

        case MonsterList.GoldGoblin: return new MobGoldGoblin();

        default: return null;
      }
    }
  }
}
