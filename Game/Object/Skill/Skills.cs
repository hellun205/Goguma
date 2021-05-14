using Goguma.Game.Console;

namespace Goguma.Game.Object.Skill
{
  static class Skills
  {
    static public ISkill GetPlayerSkill(SkillList skill)
    {
      ISkill resultSkill;
      switch (skill)
      {
        case SkillList.TestSkill1:
          resultSkill = new AttackSkill()
          {
            Name = "테스트 스킬1",
            Text = CTexts.Make("{테스테스트!}"),
            Type = SkillType.AttackSkill,
            useEp = 2,
            Damage = 5,
            IgnoreDef = 0
          };
          break;
        case SkillList.TestSkill2:
          resultSkill = new AttackSkill()
          {
            Name = "테스트 스킬2",
            Text = CTexts.Make("{테스테스테스트!}"),
            Type = SkillType.AttackSkill,
            useEp = 4,
            Damage = 7,
            IgnoreDef = 0
          };
          break;
        case SkillList.TestBuffSkill1:
          resultSkill = new BuffSkill()
          {
            Name = "테스트 버프 스킬1",
            Text = CTexts.Make("{테스트 버프 !!!!!!!}"),
            Type = SkillType.BuffSkill,
            useEp = 10,
            buff = new Buff()
            {
              MaxHp = 20,
              MaxEp = 0,
              AttDmg = 5,
              DefPer = 0.4,
              turn = 5
            }
          };
          break;
        default:
          return null;
      }
      return resultSkill;
    }
    static public ISkill GetMonsterSkill(MSkillList skill)
    {
      ISkill resultSkill;
      switch (skill)
      {
        case MSkillList.TestMonster_TestPunch:
          resultSkill = new AttackSkill()
          {
            Name = "테스트 펀치",
            Text = CTexts.Make("{테스 펀치!}"),
            Type = SkillType.AttackSkill,
            Damage = 1,
            IgnoreDef = 1
          };
          break;
        case MSkillList.TestMonster_TestFireBall:
          resultSkill = new AttackSkill()
          {
            Name = "파이어 볼",
            Text = CTexts.Make("{파이아  뽈 !}}"),
            Type = SkillType.AttackSkill,
            Damage = 3,
            IgnoreDef = 0
          };
          break;
        case MSkillList.TestMonster_TestAttackSkill:
          resultSkill = new AttackSkill()
          {
            Name = "그냥 공격",
            Text = CTexts.Make("{으아아앙락ㅇ}}"),
            Type = SkillType.AttackSkill,
            Damage = 2,
            IgnoreDef = 0
          };
          break;
        case MSkillList.TestMonster_DefensivePosture:
          resultSkill = new BuffSkill()
          {
            Name = "방어태세",
            Text = CTexts.Make("{방어태세!}"),
            Type = SkillType.BuffSkill,
            buff = new Buff()
            {
              MaxHp = 0,
              MaxEp = 0,
              AttDmg = -10,
              DefPer = 50,
              turn = 3
            }
          };
          break;
        default:
          return null;
      }
      return resultSkill;
    }
  }
}