using static Goguma.Game.Console.ConsoleFunction;
namespace Goguma.Game.Object.Entity.Player
{
  class PlayerDoActInfo
  {
    public PlayerActInfo PlayerActInfo { get; set; }
    public string SelectedActText { get; set; }
    public PlayerDoActInfo(PlayerActInfo pac, string selectActText)
    {
      PlayerActInfo = pac;
      SelectedActText = selectActText;
    }

    public void Act(IPlayer player)
    {
      switch (SelectedActText)
      {
        case "캐릭터 정보 보기":
          break;
        case "인벤토리 열기":
          player.Inventory.PrintInventory();
          break;
        case "게임 종료":
          InGame.ExitGame();
          break;
      }
    }
  }
}