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

    public void Act(Player player)
    {
      switch (SelectedActText)
      {
        case "캐릭터 정보 보기":
          player.PrintAbout();
          break;
        case "인벤토리 열기":
          player.Inventory.PrintInventory();
          break;
        case "테스트 아이템 획득": // TEST
          InGame.TestInventory(player);
          PrintText("추가완료");
          Pause();
          break;
        case "레벨 업": // TEST
          player.Exp += player.RequiredForLevelUp();
          break;
        case "게임 종료":
          InGame.ExitGame();
          break;
      }
    }
  }
}