using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "ScriptableObject/Configs/ShopConfig")]
    public class ShopConfig : ScriptableObject
    {
        [SerializeField] private List<ShopItemConfig> _shopItemConfigs;

        public IReadOnlyList<ShopItemConfig> ShopItemConfigs => _shopItemConfigs;
    }
}