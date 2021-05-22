using System;
using System.Buffers;
using Goguma.Game;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Map.Facility
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
