using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item;
using Goguma.Game.Object.Inventory.Item.Equipment;
using System.Linq;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  public static class InvenInfo
  {
    public static class Scene
    {
      public static SelectScene SelInvenType()
      {
        CTexts GetQText()
        {
          return CTexts.Make("{어떤 인벤토리를 열으시겠습니까?}");
        }

        ;

        SelectSceneItems GetSsi()
        {
          var resultSsi = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(InvenType)).Length; i++)
            resultSsi.Add($"{{[ }} {{{InvenItems.GetTypeString((InvenType)i)}, {Colors.txtSuccess}}} {{ ] 인벤토리}}");

          return resultSsi;
        }

        ;
        return new SelectScene(GetQText(), GetSsi(), true);
      }

      public static SelectScene WearingInven(Inventory inven)
      {
        var iType = InvenType.WEARING;

        CTexts GetQText()
        {
          return CTexts.Make(
            $"{{인벤토리를 열었습니다. }} {{아이템, {Colors.txtInfo}}} {{을 선택하세요.\n    위치 : }} {{{InvenItems.GetTypeString(iType)}, {Colors.txtSuccess}}}");
        }

        ;

        SelectSceneItems GetSsi(Inventory inven)
        {
          var resultSsi = new SelectSceneItems();

          for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          {
            if (inven.Items.wearing[i] != null)
            {
              var item = ((ItemPair)inven.Items.wearing[i]).ItemM;
              resultSsi.Add(CTexts
                .Make($"{{{EquipmentItem.GetETypeString((WearingType)i)}, {Colors.txtSuccess}}} {{ : }} ")
                .Combine(item.DisplayName));
            }
            else
            {
              resultSsi.Add(
                  $"{{{EquipmentItem.GetETypeString((WearingType)i)}, {Colors.txtSuccess}}} {{ : }} {{비어 있음 , {Colors.txtMuted}}}",
                  false);
            }
          }

          return resultSsi;
        }

        ;
        return new SelectScene(GetQText(), GetSsi(inven), true);
      }

      public static SelectScene SelHavingInven()
      {
        var iType = InvenType.HAVING;

        CTexts GetQText()
        {
          return CTexts.Make(
            $"{{어떤 인벤토리를 열으시겠습니까?\n    위치 : }} {{{InvenItems.GetTypeString(iType)}, {Colors.txtSuccess}}}");
        }

        ;

        SelectSceneItems GetSsi()
        {
          var resultSsi = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
            resultSsi.Add(
              $"{{{InvenItems.GetTypeString(iType)}, {Colors.txtSuccess}}} {{ : }} {{{Item.Item.GetTypeString((HavingType)i)} , {Colors.txtSuccess}}}");

          return resultSsi;
        }

        ;
        return new SelectScene(GetQText(), GetSsi(), true);
      }

      public static SelectScene HavingInven(Inventory inven, HavingType hType)
      {
        InvenType iType = InvenType.HAVING;

        CTexts GetQText(HavingType hType)
        {
          return CTexts.Make(
            $"{{인벤토리를 열었습니다. }} {{아이템,{Colors.txtInfo}}} {{을 선택하세요.\n    위치 : }} {{{InvenItems.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{Item.Item.GetTypeString(hType)},{Colors.txtSuccess}}}");
        };

        SelectSceneItems GetSsi(Inventory inventory, HavingType hType)
        {
          var resultSsi = new SelectSceneItems();
          foreach (var item in inventory.Items.having[hType, true])
          {
            resultSsi.Add(item.ItemM.DisplayName.Combine($"{{ [ {item.Count}개 ], {Colors.txtInfo}}}"));
          }

          return resultSsi;
        };

        return new SelectScene(GetQText(hType), GetSsi(inven, hType), true);
      }

      public static SelectScene ItemOption(Inventory inven, WearingType wType) // Wearing
      {
        InvenType iType = InvenType.WEARING;
        CTexts GetQText(Inventory inven, WearingType wType)
        {
          var sItem = inven.Items.wearing[wType];
          if (sItem != null)
          {
            var item = ((ItemPair)sItem).ItemM;
            return CTexts.Make(
                        $"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} ").Combine(item.DisplayName).Combine($"{{\n    위치 : }} {{{InvenItems.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{EquipmentItem.GetETypeString(wType)},{Colors.txtSuccess}}}");
          }
          else return null;
        };
        SelectSceneItems GetSsi(WearingType wType)
        {
          var resultSsi = new SelectSceneItems();

          resultSsi.Add("{아이템 정보 보기}");
          resultSsi.Add("{착용 해제}");
          resultSsi.Add("{버리기}");
          return resultSsi;
        };
        return new SelectScene(GetQText(inven, wType), GetSsi(wType), true);
      }

      static public SelectScene ItemOption(Inventory inven, ItemPair item) // Having
      {
        InvenType iType = InvenType.HAVING;
        CTexts GetQText()
        {
          return CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} ")
          .Combine(item.ItemM.DisplayName)
          .Combine($"{{ [ {item.Count}개 ], {Colors.txtInfo}}} {{\n    위치 : }}  {{{InvenItems.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{Item.Item.GetTypeString(item.ItemM.Type)},{Colors.txtSuccess}}}");
        };
        SelectSceneItems GetSsi()
        {
          var resultSsi = new SelectSceneItems();

          resultSsi.Items.Add(new SelectSceneItem(CTexts.Make("{아이템 정보 보기}")));

          switch (item.ItemM.Type)
          {
            case HavingType.EQUIPMENT:
              resultSsi.Add("{착용}");
              break;
            case HavingType.CONSUME:
              resultSsi.Add("{사용}}");
              break;
            case HavingType.OTHER:
              // TO DO
              break;
          }

          resultSsi.Add("{버리기}");
          return resultSsi;
        };
        return new SelectScene(GetQText(), GetSsi(), true);
      }
    }
  }
}