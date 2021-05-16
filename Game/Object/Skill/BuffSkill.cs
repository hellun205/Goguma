using System;

namespace Goguma.Game.Object.Skill
{
  [Serializable]
  class BuffSkill : Skill, IBuffSkill
  {
    public Buff buff { get; set; }
  }
}