
using Goguma.Game.Object.Entity.Monster;

namespace Goguma.Game.Object.Quest
{
  public struct Entitys
  {
    public MonsterList Mob { get; private set; }
    public int Count { get; private set; }
    public int KilledCount { get; private set; }

    public Entitys(MonsterList mob, int count = 1)
    {
      Mob = mob;
      Count = count;
      KilledCount = 0;
    }
    public void Kill()
    {
      KilledCount += 1;
    }
  }
}