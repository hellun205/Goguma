namespace Gogu_Remaster.Game.Object.Map.Town
{
  public class Towns
  {
    public static TKks kks = new TKks();

    public static Town GetTownByName(string name)
    {
      if (kks.Name == name) return kks;
      else return null;
    }
  }
}
