using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using static Goguma.Game.Console.ConsoleFunction;

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
            PrintText();
            //TODO
        }

        public void UseItem(IPlayer toPlayer)
        {
            //TODO
        }
    }
}