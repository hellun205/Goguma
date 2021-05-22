namespace Goguma.Game.Object.Map.Facility
{
  public interface IFacility
  {
    public string Name { get; }
    public double Fee { get; }
    public void OnUse();
  }
}
