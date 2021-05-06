namespace Goguma.Game.Console
{
  class SelectSceneItem
  {
    public CTexts Texts { get; set; }
    public bool Enabled { get; set; }

    public SelectSceneItem(CTexts texts, bool enabled = true)
    {
      Texts = texts;
      Enabled = enabled;
    }
  }
}
