using System;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Quest
{
  [Serializable]
  public abstract class QGeneral : Quest
  {
    public override QuestType Type => QuestType.General;

    protected QGeneral() : base() { }

    public override bool IsCompleted => true;

    protected override CTexts InfoDetails()
    {
      return CTexts.Empty;
    }
  }
}