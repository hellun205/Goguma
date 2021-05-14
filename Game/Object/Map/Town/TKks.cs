namespace Gogu_Remaster.Game.Object.Map.Town
{
  public class TKks : Town
  {
    public override string Name
    {
      get => "KKS 마을";
    }
    public override string Desc
    {
      get => "제작자 KKS를 기리기 위한 마을";
    }

    public TKks()
    {
      base.AddFacility(Facility.Facilities.hospital);
    }
  }
}
