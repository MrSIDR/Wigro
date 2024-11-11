using System.Collections.Generic;

namespace Shop.View
{
    public class ShopViewConfig
    {
        public List<ShopItemViewConfig> ItemViewConfigs { get; }

        public ShopViewConfig(List<ShopItemViewConfig> itemViewConfigs)
        {
            ItemViewConfigs = itemViewConfigs;
        }
    }
}