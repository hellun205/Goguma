using Goguma.Game.Console;
using Goguma.Game.Object.Entity.Player;
using Goguma.Game.Object.Enum;

namespace Goguma.Game.Object.Inventory.Item
{
    class EquipmentItem : IEquipmentItem
    {
        public EquipmentType EquipmentType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ItemIncrease Increase { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public CTexts Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public CTexts Lore { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public CTexts Description { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Count { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsAir { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ItemType Type { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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