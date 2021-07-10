namespace Goguma.Game.Object.Entity.AttSys
{
  public class AttCondition
  {
    public Player.Player player;
    public Monster.Mob monster;
    public Cond cond1;
    public double cond2;
    public string cond;
    public AttCondition(Cond c1, string c, in double c2)
    {
      cond1 = c1;
      cond = c;
      cond2 = c2;
    }
    public double GetValue(Cond cond)
    {
      switch (cond)
      {
        case Cond.MonsterHp:
          return monster.Hp;
        case Cond.PlayerHp:
          return player.Hp;
        case Cond.MonsterMaxHp:
          return monster.MaxHp;
        case Cond.PlayerMaxHp:
          return player.MaxHp;
        case Cond.PlayerHpPer:
          return player.Hp / player.MaxHp;
        case Cond.MonsterHpPer:
          return monster.Hp / monster.MaxHp;
        default:
          return 0;
      }
    }
    public bool Get()
    {
      var c = GetValue(cond1);

      switch (cond)
      {
        case "==":
          return (c == cond2);
        case "!=":
          return (c != cond2);
        case "<=":
          return (c <= cond2);
        case ">=":
          return (c >= cond2);
        case ">":
          return (c > cond2);
        case "<":
          return (c < cond2);
        default:
          return false;
      }
    }
  }
}