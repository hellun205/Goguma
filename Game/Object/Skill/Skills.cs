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
            Damage = 1,
            IgnoreDef = 1
          };
          break;
        case MSkillList.TestMonster_TestFireBall:
          resultSkill = new AttackSkill()
          {
            Name = "파이어 볼",
            Text = CTexts.Make("{파이아  뽈 !}}"),
            Damage = 3,
            IgnoreDef = 0
          };
          break;
        case MSkillList.TestMonster_TestAttackSkill:
          resultSkill = new AttackSkill()
          {
            Name = "그냥 공격",
            Text = CTexts.Make("{으아아앙락ㅇ}}"),
            Damage = 2,
            IgnoreDef = 0
          };
          break;
        case MSkillList.TestMonster_DefensivePosture:
          resultSkill = new BuffSkill()
          {
            Name = "방어태세",
            Text = CTexts.Make("{방어태세!}"),
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
        case MSkillList.SLIME_STICKY_ATTACK:
          resultSkill = new AttackSkill()
          {
            Name = "끈적끈적 공격",
            Text = CTexts.Make("{(폴짝폴짝)}"),
            Damage = 2,
            IgnoreDef = 0
          };
          break;
        case MSkillList.SLIME_SPOUT_STICKY_LIQUID:
          resultSkill = new AttackSkill()
          {
            Name = "끈적 액체 내뿜기",
            Text = CTexts.Make("{(쮸르륵쭈욱..)}"),
            Damage = 2.7,
            IgnoreDef = 0.3
          };
          break;
        case MSkillList.GOLD_GOBLIN_SWORD_SWING:
          resultSkill = new AttackSkill()
          {
            Name = "검 휘두르기",
            Text = CTexts.Make("{...}"),
            Damage = 3.2,
            IgnoreDef = 0.2
          };
          break;
        case MSkillList.GOLD_GOBLIN_SWORD_STING:
          resultSkill = new AttackSkill()
          {
            Name = "찌르기",
            Text = CTexts.Make("{...}"),
            Damage = 2.6,
            IgnoreDef = 1.5
          };
          break;
        case MSkillList.GOLD_GOBLIN_ANGER:
          resultSkill = new BuffSkill()
          {
            Name = "분노",
            Text = CTexts.Make("{..!}"),
            buff = new Buff()
            {
              MaxHp = 0,
              MaxEp = 0,
              AttDmg = 6.6,
              DefPer = -22.5,
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