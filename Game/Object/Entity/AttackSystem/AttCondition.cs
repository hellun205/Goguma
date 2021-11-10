using Goguma.Game.Object.Entity.Monster;
using Goguma.Game.Object.Skill;
using Goguma.Game.Object.Skill.Skills;

namespace Goguma.Game.Object.Entity.AttackSystem
{
  public class AttCondition
  {
    public ISkill Skill { get; private set; }
    private Player.Player _player = InGame.player;
    private IMonster _monster;
    public Cond cond1;
    public double cond2;
    public string cond;
    public int ACount { get; private set; }
    public int UseCount { get; private set; }
    public int Priority { get; private set; }

    public AttCondition(IMonster mob, ISkill skill, Cond c1, string c, double c2, int count = 1, int priority = 0)
    {
      _monster = mob;
      Skill = skill;
      cond1 = c1;
      cond = c;
      cond2 = c2;
      ACount = count;
      UseCount = 0;
      Priority = priority;
    }

    public AttCondition(IMonster mob, SkillList skill, Cond c1, string c, double c2, int count = 1, int priority = 0)
    : this(mob, PlayerSkills.GetNew(skill), c1, c, c2, count, priority) { }

    public AttCondition(IMonster mob, MSkillList skill, Cond c1, string c, double c2, int count = 1, int priority = 0)
    : this(mob, MonsterSkills.GetNew(skill), c1, c, c2, count, priority) { }

    public double GetValue(Cond cond)
    {
      switch (cond)
      {
        case Cond.MonsterHp: return _monster.Hp;

        case Cond.PlayerHp: return _player.Hp;

        case Cond.MonsterMaxHp: return _monster.MaxHp;

        case Cond.PlayerMaxHp: return _player.MaxHp;

        case Cond.PlayerHpPer: return _player.Hp / _player.MaxHp;

        case Cond.MonsterHpPer: return _monster.Hp / _monster.MaxHp;

        default: return 0;

      }
    }

    public bool Get()
    {
      var c = GetValue(cond1);

      switch (cond)
      {
        case "==": return (c == cond2);

        case "!=": return (c != cond2);

        case "<=": return (c <= cond2);

        case ">=": return (c >= cond2);

        case ">": return (c > cond2);

        case "<": return (c < cond2);

        default: return false;
      }
    }

    public bool Use()
    {
      var c = (ACount > UseCount);
      if (c)
      {
        UseCount += 1;
      }

      return c;
    }
  }
}