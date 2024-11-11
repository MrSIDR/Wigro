using System;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class ShopItemConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;

        public string ID => _id;
        public string Name => _name;
        public string Description => _description;
        public Sprite Sprite => _sprite;
    }
}