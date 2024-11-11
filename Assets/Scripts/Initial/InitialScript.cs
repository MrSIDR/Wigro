using MainMenu;
using Settings;
using Shop;
using Shop.Popup;
using Shop.View;
using Sound;
using UnityEngine;
using View;

namespace Initial
{
    public class InitialScript : MonoBehaviour
    {
        [SerializeField] private ShopConfig _shopConfig;
        [SerializeField] private ShopItemView _shopItemViewPrefab;
        [Space]
        [SerializeField] private PurchaseConfirmationPopup _purchaseConfirmationPopup;
        [SerializeField] private ShopView _shopView;
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private MainMenuView _mainMenuView;
        [Space]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _soundSource;

        private SimpleSoundController _simpleSoundController;
        private MainMenuController _mainMenuController;
        private SettingsController _settingsController;
        private ViewController _viewController;
        private ShopController _shopController;

        private void Start()
        {
            var shopItemViewFactory = new ShopItemViewFactory(_shopItemViewPrefab, _shopView.ItemRoot);
            _shopView.Init(shopItemViewFactory);
            
            _purchaseConfirmationPopup.Init();
            _settingsView.Init();
            _mainMenuView.Init();
            
            _simpleSoundController = new SimpleSoundController(_musicSource, _soundSource);
            
            _viewController = new ViewController();

            var shopModel = new ShopModel(_shopConfig.ShopItemConfigs);
            
            _shopController = new ShopController(_viewController, _purchaseConfirmationPopup, _shopView, shopModel);
            
            _settingsController = new SettingsController(_simpleSoundController, _viewController, _settingsView);
            
            _mainMenuController = new MainMenuController(_viewController, _shopController, _settingsController, _mainMenuView);
        }

        private void OnDestroy()
        {
            _shopController?.Dispose();
            _settingsController?.Dispose();
            _mainMenuController?.Dispose();
        }
    }
}