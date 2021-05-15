using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using Goguma.Game.Console;
using static Goguma.Game.Console.ConsoleFunction;
using Colorify;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Goguma.Game.Object.Entity.Player
{
  [Serializable]
  static class PlayerSave
  {
    public static void SaveCurrentPlayer()
    {
      CreateDirectory(InGame.player.Name);

      var ws = new FileStream($"datas/{InGame.player.Name}/player.pdata", FileMode.OpenOrCreate);
      var serializer = new BinaryFormatter();

#pragma warning disable SYSLIB0011
      serializer.Serialize(ws, InGame.player);
      ws.Close();
    }

    public static void SavePlayerData(Player player)
    {
      CreateDirectory(player.Name);

      var ws = new FileStream($"datas/{player.Name}/player.pdata", FileMode.OpenOrCreate);
      var serializer = new BinaryFormatter();

#pragma warning disable SYSLIB0011
      serializer.Serialize(ws, player);
      ws.Close();
    }

    public static Player LoadPlayerData(string name)
    {
      CreateDirectory(name);

      var path = $"datas/{name}/player.pdata";
      if (!File.Exists(path)) return null;
      var ws = new FileStream(path, FileMode.OpenOrCreate);
      var deserializer = new BinaryFormatter();

      var profile = deserializer.Deserialize(ws);
      ws.Close();

      if (new Player().GetType().IsInstanceOfType(profile))
        return (Player)profile;
      else
        return null;
    }

    public static Player CreatePlayerData()
    {
      Func<string, bool> checkNull = str =>
      {
        var reg = new Regex("^[a-zA-Z0-9]*$");
        if (
          str == null ||
          str.Trim() == "" ||
          str.IndexOf(">") != -1 ||
          str.IndexOf("<") != -1 ||
          str.IndexOf("|") != -1 ||
          str.IndexOf("/") != -1 ||
          str.IndexOf("\\") != -1 ||
          str.IndexOf(":") != -1 ||
          str.IndexOf("*") != -1 ||
          str.IndexOf("?") != -1 ||
          str.IndexOf("\"") != -1 ||
          !reg.IsMatch(str)
        )
          return false;
        else
          return true;
      };

      var name = ReadTextScean(CTexts.Make("{만들 캐릭터의 이름을 입력하세요.}"), checkNull);
      if (name == "" || name == null) return null;
      name = name.Trim();
      if (IsExistUserName(name))
      {
        if (ReadYesOrNoScean(CTexts.Make("{캐릭터가 이미 존재합니다. 불러오시겠습니까?}")))
          return LoadPlayerData(name);
        else
          return null;
      }
      var player = new Player(name);

      SavePlayerData(player);
      return player;
    }

    public static bool IsExistUserName(string name)
    {
      return Directory.Exists($"datas/{name}");
    }

    private static void CreateDirectory(string name = "")
    {
      Directory.CreateDirectory("datas");
      if (name != "")
        Directory.CreateDirectory($"datas/{name}");
    }

    public static Player GetPlayerData()
    {
      CreateDirectory();

      var questionText = CTexts.Make("{불러올 캐릭터를 선택하세요.}");
      var selectSceneItems = new SelectSceneItems();

      var di = new DirectoryInfo("datas");

      foreach (var item in di.GetDirectories())
        selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{{item.Name}}}")));
      selectSceneItems.Items.Add(new SelectSceneItem(CTexts.Make($"{{뒤로 가기, {Colors.txtMuted}}}")));

      var ss = new SelectScene(questionText, selectSceneItems);
      var name = ss.getString.Trim();
      Player player;
      if (name == "" || name == null || name == "뒤로 가기") return null;
      player = LoadPlayerData(name);

      if (player == null)
      {
        PrintText("캐릭터를 찾을 수 없습니다.");
        Pause();
        return null;
      }
      else
        return player;
    }

    public static List<string> GetPlayerList()
    {
      CreateDirectory();

      var di = new DirectoryInfo("datas");
      var list = new List<string>();

      foreach (var dir in di.GetDirectories())
      {
        list.Add(dir.Name);
      }

      return list;
    }
  }
}
