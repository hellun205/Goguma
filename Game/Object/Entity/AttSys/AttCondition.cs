namespace Goguma.Game.Object.Entity.AttSys
{
  class AttCondition
  {
    public double cond1;
    public double cond2;
    public string cond;
    public AttCondition(in double c1, string c, in double c2)
    {
      cond1 = c1;
      cond = c;
      cond2 = c2;
    }
    public bool Get()
    {
      switch (cond)
      {
        case "==":
          return (cond1 == cond2);
        case "!=":
          return (cond1 != cond2);
        case "<=":
          return (cond1 <= cond2);
        case ">=":
          return (cond1 >= cond2);
        case ">":
          return (cond1 > cond2);
        case "<":
          return (cond1 < cond2);
        default:
          return false;
      }
    }
  }
}