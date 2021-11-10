[1mdiff --git a/Game/Object/Entity/Entity.cs b/Game/Object/Entity/Entity.cs[m
[1mindex 1d18972..2ec2772 100644[m
[1m--- a/Game/Object/Entity/Entity.cs[m
[1m+++ b/Game/Object/Entity/Entity.cs[m
[36m@@ -154,16 +154,16 @@[m [mnamespace Goguma.Game.Object.Entity[m
         .Append("{\n체력 : }")[m
         .Append(GetHpBar())[m
         .Append($"{{\n물리 공격력 : }}{{{PhysicalDamage},{Colors.txtDanger}}}")[m
[31m-        .Append($"{{\n마법 공격력 : }}{{{MagicDamage},{Colors.txtInfo}}}")[m
[32m+[m[32m        .Append($"{{\t\t마법 공격력 : }}{{{MagicDamage},{Colors.txtInfo}}}")[m
 [m
         .Append($"{{\n물리 관통력 : }}{{{PhysicalPenetration},{Colors.txtDanger}}}")[m
[31m-        .Append($"{{\n마법 관통력 : }}{{{MagicPenetration},{Colors.txtInfo}}}")[m
[32m+[m[32m        .Append($"{{\t\t마법 관통력 : }}{{{MagicPenetration},{Colors.txtInfo}}}")[m
 [m
[31m-        .Append($"{{\n물리 방어력 : }}{{{PhysicalDefense},{Colors.txtDanger}}}{{ ( {Math.Round(1 - (100 / (100 + PhysicalDefense)), 2)} % )}}")[m
[31m-        .Append($"{{\n마법 방어력 : }}{{{MagicDefense},{Colors.txtInfo}}}{{ ( {Math.Round(1 - (100 / (100 + MagicDefense)), 2)} % )}}")[m
[32m+[m[32m        .Append($"{{\n물리 방어력 : }}{{{PhysicalDefense},{Colors.txtDanger}}}{{ ({Math.Floor(1 - (100 / (100 + PhysicalDefense)))}%)}}")[m
[32m+[m[32m        .Append($"{{\t\t마법 방어력 : }}{{{MagicDefense},{Colors.txtInfo}}}{{ ({Math.Floor(1 - (100 / (100 + MagicDefense)))}%)}}")[m
 [m
         .Append($"{{\n치명타 데미지 : }}{{{CriticalDamage} %,{Colors.txtWarning}}}")[m
[31m-        .Append($"{{\n치명타 확률 : }}{{{CriticalPercent} %,{Colors.txtWarning}}}")[m
[32m+[m[32m        .Append($"{{\t치명타 확률 : }}{{{CriticalPercent} %,{Colors.txtWarning}}}")[m
         .Append($"{{\n{GetSep(40)}}}");[m
     }[m
 [m
[1mdiff --git a/Game/Object/Entity/Npc/PartyNpc.cs b/Game/Object/Entity/Npc/PartyNpc.cs[m
[1mindex bb65d87..7570196 100644[m
[1m--- a/Game/Object/Entity/Npc/PartyNpc.cs[m
[1m+++ b/Game/Object/Entity/Npc/PartyNpc.cs[m
[36m@@ -1,9 +1,11 @@[m
 using static Goguma.Game.Console.ConsoleFunction;[m
 using static Goguma.Game.Console.StringFunction;[m
 using Colorify;[m
[32m+[m[32musing System;[m
 [m
[31m-namespace Goguma.Game.Object.Entity.Npc [m
[32m+[m[32mnamespace Goguma.Game.Object.Entity.Npc[m
 {[m
[32m+[m[32m  [Serializable][m
   public class PartyNpc : Entity[m
   {[m
     public override EntityType Type => EntityType.NPC;[m
[36m@@ -15,4 +17,4 @@[m [mnamespace Goguma.Game.Object.Entity.Npc[m
       // TO DO[m
     }[m
   }[m
[31m-} [m
\ No newline at end of file[m
[32m+[m[32m}[m
\ No newline at end of file[m
[1mdiff --git a/Game/Object/Entity/Player/Player.cs b/Game/Object/Entity/Player/Player.cs[m
[1mindex 7262d82..3c7cdef 100644[m
[1m--- a/Game/Object/Entity/Player/Player.cs[m
[1m+++ b/Game/Object/Entity/Player/Player.cs[m
[36m@@ -115,12 +115,9 @@[m [mnamespace Goguma.Game.Object.Entity.Player[m
         else if (MaxExp <= value)[m
         {[m
           Level += 1; // Level Up[m
[31m-          PhysicalDamage += IncreaseAttDmg;[m
[31m-          MaxHp += IncreaseMaxHp;[m
[31m-          MaxEp += IncreaseMaxEp;[m
           Hp = MaxHp;[m
           Ep = MaxEp;[m
[31m-          MaxExp += IncreaseMaxExp;[m
[32m+[m[32m          MaxExp *= 1.4;[m
           PrintCText($"{{\nLevel UP! Lv. }} {{{Level}\n, {Colors.txtInfo}}}");[m
           Exp = Math.Max(0, value - MaxExp);[m
           Pause();[m
[36m@@ -131,41 +128,10 @@[m [mnamespace Goguma.Game.Object.Entity.Player[m
 [m
     public double MaxExp { get; set; }[m
 [m
[31m-    public double IncreaseMaxExp[m
[31m-    {[m
[31m-      get => IncreaseMul(increaseMaxExp);[m
[31m-      set => increaseMaxExp = value;[m
[31m-    }[m
[31m-    public double IncreaseAttDmg[m
[31m-    {[m
[31m-      get => IncreaseMul(increaseAttDmg);[m
[31m-      set => increaseAttDmg = value;[m
[31m-    }[m
[31m-    // public int 