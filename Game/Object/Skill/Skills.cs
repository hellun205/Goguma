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
            Descriptions = CTexts.Make("{그냥 테스트용으로 쓰이는 스킬이다.}"),
            UseEp = 2,
            Damage = 5,
            IgnoreDef = 0
          };
          break;
        case SkillList.TestSkill2:
          resultSkill = new AttackSkill()
          {
            Name = "테스트 스킬2",
            Text = CTexts.Make("{테스테스테스트!}"),
            Descriptions = CTexts.Make("{그냥 테스트용으로 쓰이는 스킬이다.}"),
            UseEp = 4,
            Damage = 7,
            IgnoreDef = 0
          };
          break;
        case SkillList.TestBuffSkill1:
          resultSkill = new BuffSkill()
          {
            Name = "테스트 버프 스킬1",
            Text = CTexts.Make("{테스트 버프 !!!!!!!}"),
            Descriptions = CTexts.Make("{그냥 테스트용으로 쓰이는 스킬이다.}"),
            UseEp = 10,
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
            Descriptions = CTexts.Make("{테스트 몬스터가 사용하는 테스트 스킬이다.}"),
            Damage = 1,
            IgnoreDef = 1
          };
          break;
        case MSkillList.TestMonster_TestFireBall:
          resultSkill = new AttackSkill()
          {
            Name = "파이어 볼",
            Text = CTexts.Make("{파이아  뽈 !}}"),
            Descriptions = CTexts.Make("{테스트 몬스터가 사용하는 테스트 스킬이다.}"),
            Damage = 3,
            IgnoreDef = 0
          };
          break;
        case MSkillList.TestMonster_TestAttackSkill:
          resultSkill = new AttackSkill()
          {
            Name = "그냥 공격",
            Text = CTexts.Make("{으아아앙락ㅇ}}"),
            Descriptions = CTexts.Make("{테스트 몬스터가 사용하느 테스트 스킬이다.}"),
            Damage = 2,
            IgnoreDef = 0
          };
          break;
        case MSkillList.TestMonster_DefensivePosture:
          resultSkill = new BuffSkill()
          {
            Name = "방어태세",
            Text = CTexts.Make("{방어태세!}"),
            Descriptions = CTexts.Make("{테스트 몬스터가 자신의 체력이 낮아지면 사용하는 버프 스킬이다.}"),
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
            Descriptions = CTexts.Make("{슬라임의 역겨운 공격이다.}"),
            Damage = 2,
            IgnoreDef = 0
          };
          break;
        case MSkillList.SLIME_SPOUT_STICKY_LIQUID:
          resultSkill = new AttackSkill()
          {
            Name = "끈적 액체 내뿜기",
            Text = CTexts.Make("{(쮸르륵쭈욱..)}"),
            Descriptions = CTexts.Make("{슬라임의 역겨운 공격2}"),
            Damage = 2.7,
            IgnoreDef = 0.3
          };
          break;
        case MSkillList.GOLD_GOBLIN_SWORD_SWING:
          resultSkill = new AttackSkill()
          {
            Name = "검 휘두르기",
            Text = CTexts.Make("{...}"),
            Descriptions = CTexts.Make("{황금 고블린이 적에게 검을 휘두른다.}"),
            Damage = 3.2,
            IgnoreDef = 0.2
          };
          break;
        case MSkillList.GOLD_GOBLIN_SWORD_STING:
          resultSkill = new AttackSkill()
          {
            Name = "찌르기",
            Text = CTexts.Make("{...}"),
            Descriptions = CTexts.Make("{황금 고블린이 적을 찌른다.}"),
            Damage = 2.6,
            IgnoreDef = 1.5
          };
          break;
        case MSkillList.GOLD_GOBLIN_ANGER:
          resultSkill = new BuffSkill()
          {
            Name = "분노",
            Text = CTexts.Make("{..!}"),
            Descriptions = CTexts.Make("{황금 고블린이 체력이 낮아지면 사용하는 버프이다.}"),
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