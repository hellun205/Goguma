using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;

namespace Goguma.Game.Object.Inventory.Item
{
    class OtherItem : IOtherItem
    {
        public CTexts Name { get; set; }
        public CTexts Lore { get; set; }
        public CTexts Description { get; set; }
        public int Count { get; set; }
        public bool IsAir { get; set; }
        public ItemType Type { get; set; }

        public void DescriptionItem()
        {
            
        }

        public void UseItem(IPlayer player)
        {
            
        }
    }
}