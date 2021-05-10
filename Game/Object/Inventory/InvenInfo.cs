using System;
using Colorify;
using Goguma.Game.Console;

namespace Goguma.Game.Object.Inventory
{
  [Serializable]
  static class InvenInfo
  {
    static public class Inven
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
    }
    static public class WearingInven
    {
      static public string GetTypeString(WearingType iType)
      {
        switch (iType)
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
    }
    static public class HavingInven
    {
      static public string GetTypeString(HavingType iType)
      {
        switch (iType)
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
    }
    static public class Scene
    {
      static public class SelInvenType
      {
        static public CTexts GetQText()
        {
          return CTexts.Make("{어떤 인벤토리를 열으시겠습니까?}");
        }

        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(InvenType)).Length; i++)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{[ }} {{{InvenInfo.Inven.GetTypeString((InvenType)i)}, {Colors.txtSuccess}}} {{ ] 인벤토리}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));

          return resultSSI;
        }
      }
      static public class WearingInven
      {
        static private readonly InvenType iType = InvenType.Wearing;
        static public CTexts GetQText()
        {
          return CTexts.Make($"{{인벤토리를 열었습니다. }} {{아이템, {Colors.txtInfo}}} {{을 선택하세요.\n    위치 : }} {{{InvenInfo.Inven.GetTypeString(iType)}, {Colors.txtSuccess}}}");
        }
        static public SelectSceneItems GetSSI(Inventory inven)
        {
          var resultSSI = new SelectSceneItems();

          for (var i = 0; i < Enum.GetValues(typeof(WearingType)).Length; i++)
          {
            if (!inven.Items.wearing.GetItem((WearingType)i).IsAir)
              resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString((WearingType)i)}, {Colors.txtSuccess}}} {{ : }} {{{inven.Items.wearing.GetItem((WearingType)i).Name.ToString()} , {Colors.txtInfo}}}")));
            else
              resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{InvenInfo.WearingInven.GetTypeString((WearingType)i)}, {Colors.txtSuccess}}} {{ : }} {{비어 있음 , {Colors.txtInfo}}}"), false));
          }
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));

          return resultSSI;
        }
      }
      static public class SelHavingInven
      {
        static private readonly InvenType iType = InvenType.Having;
        static public CTexts GetQText()
        {
          return CTexts.Make($"{{어떤 인벤토리를 열으시겠습니까?\n    위치 : }} {{{InvenInfo.Inven.GetTypeString(iType)}, {Colors.txtSuccess}}}");
        }

        static public SelectSceneItems GetSSI()
        {
          var resultSSI = new SelectSceneItems();
          for (var i = 0; i < Enum.GetValues(typeof(HavingType)).Length; i++)
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{InvenInfo.Inven.GetTypeString(iType)}, {Colors.txtSuccess}}} {{ : }} {{{InvenInfo.HavingInven.GetTypeString((HavingType)i)} , {Colors.txtSuccess}}}")));
          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));

          return resultSSI;
        }
      }
      static public class HavingInven
      {
        static private readonly InvenType iType = InvenType.Having;
        static public CTexts GetQText(HavingType hType)
        {
          return CTexts.Make($"{{인벤토리를 열었습니다. }} {{아이템,{Colors.txtInfo}}} {{을 선택하세요.\n    위치 : }} {{{InvenInfo.Inven.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{InvenInfo.HavingInven.GetTypeString(hType)},{Colors.txtSuccess}}}");
        }
        static public SelectSceneItems GetSSI(Inventory inven, HavingType hType)
        {
          var resultSSI = new SelectSceneItems();
          foreach (var item in inven.Items.having.GetItems(hType))
          {
            if (!item.IsAir)
            {
              if (hType == HavingType.Equipment)
                resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{item.Name.ToString()}}} {{ [{item.Count}], {Colors.txtInfo}}} {{ [{InvenInfo.WearingInven.GetTypeString((WearingType)item.Type)}],{Colors.txtWarning}}}")));
              else
                resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{{item.Name.ToString()}}} {{ [{item.Count}], {Colors.txtInfo}}}")));
            }
            else
              resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{비어 있음}} {{ [{item.Count}], {Colors.txtInfo}}}"), false));
          }

          resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
          return resultSSI;
        }
      }
      static public class ItemOption
      {
        static public class Wearing
        {
          static private readonly InvenType iType = InvenType.Wearing;
          static public CTexts GetQText(Inventory inven, WearingType wType)
          {
            var sItem = inven.Items.wearing.GetItem(wType);
            return CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} {{{sItem.Name.ToString()}}} {{ [{sItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }} {{{InvenInfo.Inven.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{InvenInfo.WearingInven.GetTypeString(wType)},{Colors.txtSuccess}}}");
          }
          static public SelectSceneItems GetSSI(WearingType wType)
          {
            var resultSSI = new SelectSceneItems();

            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{아이템 정보 보기}")));

            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{착용 해제}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{버리기}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
            return resultSSI;
          }
        }
        static public class Having
        {
          static private readonly InvenType iType = InvenType.Having;
          static public CTexts GetQText(Inventory inven, HavingType hType, int sIndex)
          {
            var sItem = inven.Items.having.GetItems(hType)[sIndex];
            return CTexts.Make($"{{무슨 작업을 하시겠습니까?\n    }} {{\n    선택 : }} {{{sItem.Name.ToString()}}} {{ [{sItem.Count}], {Colors.txtInfo}}} {{\n    위치 : }}  {{{InvenInfo.Inven.GetTypeString(iType)}, {Colors.txtSuccess}}} {{.}} {{{InvenInfo.HavingInven.GetTypeString(hType)},{Colors.txtSuccess}}} {{.}} {{{sIndex + 1},{Colors.txtSuccess}}}");
          }
          static public SelectSceneItems GetSSI(HavingType hType, int sIndex)
          {
            var resultSSI = new SelectSceneItems();

            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{아이템 정보 보기}")));

            switch (hType)
            {
              case HavingType.Equipment:
                resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{착용}")));
                break;
              case HavingType.Consume:
                resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{사용}}")));
                break;
              case HavingType.Other:
                // TO DO
                break;
            }
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make("{버리기}")));
            resultSSI.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));
            return resultSSI;
          }
          // TO DO
        }
      }

    }
  }
}
