using System.Collections.Generic;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Map;

namespace Goguma.Game.Object.Entity.Player
{
  class PlayerActInfo
  {
    public MapList Map { get; set; }
    public MapInfo MapInfo { get; set; }
    public CTexts QuestionText { get; set; }
    public SelectSceneItems SelectItemAnswers { get; set; }

    public PlayerActInfo(MapList map)
    {
      Map = map;
      MapInfo = new MapInfo(map);

      QuestionText = CTexts.Make($"{{[ {MapInfo.Text} ] , {Colors.bgSuccess}}} {{이 곳에서 무슨 작업을 하시겠습니까?}}");
      SelectItemAnswers = new SelectSceneItems();

      SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{캐릭터 정보 보기}")));
      SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{인벤토리 열기}")));
      switch (map)
      {
        case MapList.Not:
          // SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{}")));
          break;
      }
      // SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make("{}")));
      SelectItemAnswers.Items.Add(new SelectSceneItem(CTexts.Make($"{{게임 종료, {Colors.txtMuted}}}")));

    }
  }
}