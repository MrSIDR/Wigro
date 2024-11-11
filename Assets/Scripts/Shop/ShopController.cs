using System;
using System.Collections.Generic;
using Shop.Popup;
using Shop.View;
using UnityEngine;
using View;

namespace Shop
{
    public class ShopController : IDisposable
    {
        private const string _viewName = "shop_view";
        
        private readonly ViewController _viewController;
        private readonly PurchaseConfirmationPopup _purchaseConfirmationPopup;
        private readonly ShopModel _model;
        private readonly ShopView _view;

        private IReadOnlyShopItem _selectedShopItem;

        public ShopController(
            ViewController viewController,
            PurchaseConfirmationPopup purchaseConfirmationPopup,
            ShopView view,
            ShopModel model)
        {
            _viewController = viewController;
            _purchaseConfirmationPopup = purchaseConfirmationPopup;
            _view = view;
            _model = model;
            
            _viewController.AddView(_viewName, _view);
            SubscribeView();
        }

        public void ShowShop()
        {
            SetupShopView();
            _viewController.Show(_viewName);
        }

        private void BuyItem()
        {
            if (_selectedShopItem == null)
            {
                Debug.LogError($"{nameof(_selectedShopItem)} is null!");
                return;
            }
            
            _purchaseConfirmationPopup.SetupCongratulationPopup(_selectedShopItem.Name);
            _model.BuyItem(_selectedShopItem.ID);
            SetupShopView();
        }

        private void SelectItem(string id)
        {
            var result = _model.GetItem(id);
            if (!result.IsExist)
            {
                Debug.LogError($"Product with id {id} doesn't exist!");
                return;
            }

            _selectedShopItem = result.Object;
            _purchaseConfirmationPopup.SetupBuyingPopup(_selectedShopItem.Name);
            ShowPopup();
        }

        private void SetupShopView()
        {
            var itemConfigs = new List<ShopItemViewConfig>();
            foreach (var item in _model.Items)
            {
                if (item.WasBought)
                {
                    continue;
                }
                
                itemConfigs.Add(new ShopItemViewConfig(item.ID, item.Description, item.Sprite));
            }
            
            _view.Setup(new ShopViewConfig(itemConfigs));
        }
        
        private void CloseShop()
        {
            _viewController.Hide(_viewName);
        }

        private void ShowPopup()
        {
            _purchaseConfirmationPopup.SetActive(true);
        }

        private void ClosePopup()
        {
            _purchaseConfirmationPopup.SetActive(false);
        }

        private void SubscribeView()
        {
            _purchaseConfirmationPopup.OnBuyClick -= BuyItem;
            _purchaseConfirmationPopup.OnBuyClick += BuyItem;
            
            _purchaseConfirmationPopup.OnCloseClick -= ClosePopup;
            _purchaseConfirmationPopup.OnCloseClick += ClosePopup;
            
            _view.OnClickClose -= CloseShop;
            _view.OnClickClose += CloseShop;
            
            _view.OnSelectItem -= SelectItem;
            _view.OnSelectItem += SelectItem;
        }

        private void UnsubscribeView()
        {
            _purchaseConfirmationPopup.OnBuyClick -= BuyItem;
            _purchaseConfirmationPopup.OnCloseClick -= ClosePopup;

            _view.OnClickClose -= CloseShop;
            _view.OnSelectItem -= SelectItem;
        }

        public void Dispose()
        {
            UnsubscribeView();
        }
    }
}