using System;
using Settings;
using Shop;
using View;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MainMenu
{
    public class MainMenuController : IDisposable
    {
        private const string _viewName = "main_menu_view";
        
        private readonly MainMenuView _view;
        private readonly ViewController _viewController;
        private readonly ShopController _shopController;
        private readonly SettingsController _settingsController;

        public MainMenuController(
            ViewController viewController,
            ShopController shopController,
            SettingsController settingsController,
            MainMenuView view)
        {
            _view = view;
            _viewController = viewController;
            _shopController = shopController;
            _settingsController = settingsController;
            
            _viewController.AddView(_viewName, _view);
            _viewController.Show(_viewName);

            SubscribeView();
        }

        private void ShowShop()
        {
            _shopController.ShowShop();
        }
        
        private void ShowSetting()
        {
            _settingsController.ShowSettings();
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void SubscribeView()
        {
            _view.OnClickShop -= ShowShop;
            _view.OnClickShop += ShowShop;
            
            _view.OnClickSetting -= ShowSetting;
            _view.OnClickSetting += ShowSetting;
            
            _view.OnClickExit -= ExitGame;
            _view.OnClickExit += ExitGame;
        }
        
        private void UnsubscribeView()
        {
            _view.OnClickShop -= ShowShop;
            _view.OnClickSetting -= ShowSetting;
            _view.OnClickExit -= ExitGame;
        }

        public void Dispose()
        {
            UnsubscribeView();
        }
    }
}
