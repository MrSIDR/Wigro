using System;
using Sound;
using View;

namespace Settings
{
    public class SettingsController : IDisposable
    {
        private const string _viewName = "settings_view";

        private readonly SimpleSoundController _soundController;
        private readonly ViewController _viewController;
        private readonly SettingsView _view;

        public SettingsController(SimpleSoundController soundController, ViewController viewController, SettingsView view)
        {
            _soundController = soundController;
            _viewController = viewController;
            _view = view;
            
            _viewController.AddView(_viewName, _view);

            SubscribeView();
        }

        public void ShowSettings()
        {
            _viewController.Show(_viewName);
        }
        
        private void HideSettings()
        {
            _viewController.Hide(_viewName);
        }

        private void ChangeSound(bool isOn)
        {
            if (isOn)
            {
                _soundController.EnableSound();
            }
            else
            {
                _soundController.DisableSound();
            }
        }
        
        private void ChangeMusic(bool isOn)
        {
            if (isOn)
            {
                _soundController.EnableMusic();
            }
            else
            {
                _soundController.DisableMusic();
            }
        }

        private void SubscribeView()
        {
            _view.OnClickClose -= HideSettings;
            _view.OnClickClose += HideSettings;
            
            _view.OnChangeSound -= ChangeSound;
            _view.OnChangeSound += ChangeSound;
            
            _view.OnChangeMusic -= ChangeMusic;
            _view.OnChangeMusic += ChangeMusic;
        }

        private void UnsubscribeView()
        {
            _view.OnClickClose -= HideSettings;
            _view.OnChangeSound -= ChangeSound;
            _view.OnChangeMusic -= ChangeMusic;
        }
        
        public void Dispose()
        {
            UnsubscribeView();
        }
    }
}