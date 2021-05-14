using System;
using System.Buffers;
using Gogu_Remaster.Game.Object.Map.Facility;
using Goguma.Game;
using Goguma.Game.Console;

namespace Gogu_Remaster.Game.Object.Map.Facilility
{
  public class FHospital : IFacility
  {
    public string Name
    {
      get => "병원";
    }
    public double Fee
    {
      get => 0;
    }

    public void OnUse()
    {
      InGame.player.Heal(Double.MaxValue);
      ConsoleFunction.PrintText("치료되었습니다.");
      ConsoleFunction.Pause();
    }
  }
}
