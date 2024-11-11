using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using View;

namespace Shop.View
{
    public class ShopView : MonoBehaviour, IView
    {
        public event Action OnClickClose;
        public event Action<string> OnSelectItem;

        private readonly List<ShopItemView> _items = new();
        
        [SerializeField] private Transform _itemRoot;
        [SerializeField] private Button _closeButton;
        
        private ShopItemViewFactory _factrory;

        public Transform ItemRoot => _itemRoot;

        public void Init(ShopItemViewFactory factory)
        {
            _factrory = factory;
            _closeButton.onClick.RemoveListener(ClickClose);
            _closeButton.onClick.AddListener(ClickClose);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void Setup(ShopViewConfig config)
        {
            SetupItems(config.ItemViewConfigs);
        }

        private void SetupItems(List<ShopItemViewConfig> configs)
        {
            for (int i = 0; i < configs.Count; i++)
            {
                if (i >= _items.Count)
                {
                    var shopItemView = _factrory.Create();
                    shopItemView.Init();
                    _items.Add(shopItemView);
                }
                
                var item = _items[i];
                var config = configs[i];
                item.SetActive(true);
                item.Setup(config, () => SelectItem(config.ID));
            }

            DisableUnnecessaryView(configs.Count);
        }

        private void DisableUnnecessaryView(int itemNumber)
        {
            if (_items.Count > itemNumber)
            {
                for (int i = _items.Count - 1; i > itemNumber - 1; i--)
                {
                    _items[i].SetActive(false);
                }
            }
        }
        
        private void SelectItem(string id)
        {
            OnSelectItem?.Invoke(id);
        }

        private void ClickClose()
        {
            OnClickClose?.Invoke();
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}