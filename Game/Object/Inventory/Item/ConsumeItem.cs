using Colorify;
using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;
using static Goguma.Game.Console.StringFunction;

namespace Goguma.Game.Object.Inventory.Item
{
    class ConsumeItem : IConsumeItem
    {
        public ItemEffect Effect { get; set; }
        public CTexts Name { get; set; }
        public CTexts Lore { get; set; }
        public CTexts Description { get; set; }
        public int Count { get; set; }
        public bool IsAir { get; set; }
        public ItemType Type { get; set; }

        public void DescriptionItem()
        {
            if (Effect.Hp != 0)
            {
                PrintText(CTexts.Make("{\nHP [ }"));
                PrintText(NumberColor(Effect.Hp));
                PrintText(CTexts.Make("{ ]}"));
            }
            if (Effect.Ep != 0) 
            {
                PrintText(CTexts.Make("{  EP [ }"));
                PrintText(NumberColor(Effect.Ep));
                PrintText(CTexts.Make("{ ]}"));
            }
            if (Effect.AttDmg != 0) 
            {
                PrintText(CTexts.Make("{\nATT [ }"));
                PrintText(NumberColor(Effect.AttDmg));
                PrintText(CTexts.Make("{ ]}"));
            }
            if (Effect.DefPer != 0) 
            {
                PrintText(CTexts.Make("{  DEF [ }"));
                PrintText(NumberColor(Effect.Ep));
                PrintText(CTexts.Make("{% ]}"));
            }
            if (Effect.Gold != 0) 
            {
                PrintText(CTexts.Make("{\nGOLD [ }"));
                PrintText(NumberColor(Effect.AttDmg));
                PrintText(CTexts.Make("{G ]}"));
            }
            if (Effect.Exp != 0) 
            {
                PrintText(CTexts.Make("{\nEXP [ }"));
                PrintText(NumberColor(Effect.Ep));
                PrintText(CTexts.Make("{ ]\n}"));
            }
        }

        public void UseItem(IPlayer toPlayer)
        {
            //TODO
        }
    }
}