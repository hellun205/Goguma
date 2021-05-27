using System;
using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Inventory.Item.Equipment;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  static class InvenInfo
  {
    static public string GetTypeString(InvenType iType)
    {
      switch (iType)
      {
        case InvenType.Wearing:
          return "착용";
        case InvenType.Having:
          return "소지";
        default:
          return null;
      }
    }
    static public string GetTypeString(WearingType wType)
    {
      switch (wType)
      {
        case WearingType.Head:
          return "머리";
        case WearingType.Chestplate:
          return "상체";
        case WearingType.Leggings:
          return "하체";
        case WearingType.Boots:
          return "신발";
        case WearingType.Weapon:
          return "무기";
        default:
          return null;
      }
    }

    static public string GetTypeString(HavingType hType)
    {
      switch (hType)
      {
        case HavingType.Equipment:
          return "장비";
        case HavingType.Consume:
          return "소비";
        case HavingType.Other:
          return "기타";
        default:
          return null;
      }
    }

    static public class Scene
    {
      static public SelectScene SelInvenType()
      {
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make("{어떤 인벤토리를 열으시겠습니까?}");
        };

        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(InvenType)).Length; i++)
            resultSSI.Add($"{{[ }} {{{InvenInfo.GetTypeString((InvenType)i)}, {Colors.txtSuccess}}} {{ ] 인벤토리}}");

          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI(), true);
      }

      static public SelectScene WearingInven(Inventory inven)
      {
        InvenType iType = InvenType.Wearing;
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make($"{{인벤토리를 열었습니다. }} {{아이템, {Colors.txtInfo}}} {{을 선택하세요.\n    위치 : }} {{{InvenInfo.GetTypeString(iType)}, {Colors.txtSuccess}}}");
        };
        Func<Inventory, SelectSceneItems> GetSSI = (Inventory inven) =>
        {
          var resultSSI = new SelectSceneItems();

          for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          {
            if (inven.Items.wearing.GetItem((WearingType)i) != null)
              resultSSI.Add(CTexts.Make($"{{{InvenInfo.GetTypeString((WearingType)i)}, {Colors.txtSuccess}}} {{ : }} ").Combine(inven.Items.wearing.GetItem((WearingType)i).Name));
            else
              resultSSI.Add($"{{{InvenInfo.GetTypeString((WearingType)i)}, {Colors.txtSuccess}}} {{ : }} {{비어 있음 , {Colors.txtMuted}}}", false);
          }

          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI(inven), true);
      }

      static public SelectScene SelHavingInven()
      {
        InvenType iType = InvenType.Having;
        Func<CTexts> GetQText = () =>
        {
          return CTexts.Make($"{{어떤 인벤토리를 열으시겠습니까?\n    위치 : }} {{{InvenInfo.GetTypeString(iType)}, {Colors.txtSuccess}}}");
        };

        Func<SelectSceneItems> GetSSI = () =>
        {
          var resultSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
            resultSSI.Add($"{{{InvenInfo.GetTypeString(iType)}, {Colors.txtSuccess}}} {{ : }} {{{InvenInfo.GetTypeString((HavingType)i)} , {Colors.txtSuccess}}}");

          return resultSSI;
        };
        return new SelectScene(GetQText(), GetSSI(), true);
      }

      static public SelectScene HavingInven(Inventory inven, HavingType hType)
      {
        InvenType iType = InvenType.Having;

        Func<HavingType, CTexts> GetQText = (HavingType hType) =>
        {
          return CTexts.Make($"{{인벤토리를 열었습니다. }} {{아이템,{Colors.txtInfo}}} {{을 선택하세요.\n    위치 : }} {{{InvenInfo.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{InvenInfo.GetTypeString(hType)},{Colors.txtSuccess}}}");
        };
        Func<Inventory, HavingType, SelectSceneItems> GetSSI = (Inventory inven, HavingType hType) =>
        {
          var resultSSI = new SelectSceneItems();
          foreach (var item in inven.Items.having.GetItems(hType))
          {
            if (item != null)
            {
              if (hType == HavingType.Equipment)
                resultSSI.Add(item.Name.Combine($"{{ [{item.Count}], {Colors.txtInfo}}} {{ [{InvenInfo.GetTypeString((WearingType)((IEquipmentItem)item).EType)}],{Colors.txtWarning}}}"));
              else
                resultSSI.Add($"{{{item.Name.ToString()}}} {{ [{item.Count}], {Colors.txtInfo}}}");
            }
            else
              resultSSI.Add($"{{비어 있음}} {{ [{item.Count}], {Colors.txtMuted}}}", false);
          }
          return resultSSI;
        };

        return new SelectScene(GetQText(hType), GetSSI(inven, hType), true);
      }

      static public SelectScene ItemOption(Inventory inven, WearingType wType) // Wearing
      {
        InvenType iType = InvenType.Wearing;
        Func<Inventory, WearingType, CTexts> GetQText = (Inventory inven, WearingType wType) =>
        {
          var sItem = inven.Items.wearing.GetItem(wType);
          return CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} {{{sItem.Name.ToString()}}} {{ [{sItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{InvenInfo.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{InvenInfo.GetTypeString(wType)},{Colors.txtSuccess}}}");
        };
        Func<WearingType, SelectSceneItems> GetSSI = (WearingType wType) =>
        {
          var resultSSI = new SelectSceneItems();

          resultSSI.Add("{아이템 정보 보기}");
          resultSSI.Add("{착용 해제}");
          resultSSI.Add("{버리기}");
          return resultSSI;
        };
        return new SelectScene(GetQText(inven, wType), GetSSI(wType), true);
      }

      static public SelectScene ItemOption(Inventory inven, HavingType hType, int sIndex) // Having
      {
        InvenType iType = InvenType.Having;
        Func<Inventory, HavingType, int, CTexts> GetQText = (Inventory inven, HavingType hType, int sIndex) =>
        {
          var sItem = inven.Items.having.GetItems(hType)[sIndex];
          return CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} {{{sItem.Name.ToString()}}} {{ [{sItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }}  {{{InvenInfo.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{InvenInfo.GetTypeString(hType)},{Colors.txtSuccess}}} {{.}} {{{sIndex + 1},{Colors.txtSuccess}}}");
        };
        Func<HavingType, int, SelectSceneItems> GetSSI = (HavingType hType, int sIndex) =>
        {
          var resultSSI = new SelectSceneItems();

          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{아이템 정보 보기}")));

          switch (hType)
          {
            case HavingType.Equipment:
              resultSSI.Add("{착용}");
              break;
            case HavingType.Consume:
              resultSSI.Add("{사용}}");
              break;
            case HavingType.Other:
              // TO DO
              break;
          }
          resultSSI.Add("{버리기}");
          return resultSSI;
        };
        return new SelectScene(GetQText(inven, hType, sIndex), GetSSI(hType, sIndex), true);
      }
    }
  }
}
