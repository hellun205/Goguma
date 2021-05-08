using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Inventory;

namespace Goguma.Game.Object.Inventory.Item
{
    class EquipmentItem : IEquipmentItem
    {
        public EquipmentType EquipmentType { get ; set ; }
        public ItemIncrease Increase { get ; set ; }
        public CTexts Name { get ; set ; }
        public CTexts Lore { get  ; set; }
        public CTexts Description { get ; set ; }
        public int Count { get ; set; }
        public bool IsAir { get ; set ; }
        public ItemType Type { get; set; }

        public void DescriptionItem()
        {
            //TODO
        }

        public void UseItem(IPlayer player)
        {
            //TODO
        }
    }
}