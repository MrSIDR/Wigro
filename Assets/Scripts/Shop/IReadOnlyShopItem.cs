using UnityEngine;

namespace Shop
{
    public interface IReadOnlyShopItem
    {
        public string ID { get; }
        public string Name { get; }
        public string Description { get; }
        public Sprite Sprite { get; }
        public bool WasBought { get; }
    }
}