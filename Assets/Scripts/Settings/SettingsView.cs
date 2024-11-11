using System;
using UnityEngine;
using UnityEngine.UI;
using View;

namespace Settings
{
    public class SettingsView : MonoBehaviour, IView
    {
        public event Action OnClickClose;
        public event Action<bool> OnChangeSound;
        public event Action<bool> OnChangeMusic;
        
        [SerializeField] private Button _closeButton;
        
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Toggle _musicToggle;

        public void Init()
        {
            _closeButton.onClick.RemoveListener(ClickClose);
            _closeButton.onClick.AddListener(ClickClose);
            
            _soundToggle.onValueChanged.RemoveListener(ClickSound);
            _soundToggle.onValueChanged.AddListener(ClickSound);
            
            _musicToggle.onValueChanged.RemoveListener(ClickMusic);
            _musicToggle.onValueChanged.AddListener(ClickMusic);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        
        private void ClickClose()
        {
            OnClickClose?.Invoke();
        }
        
        private void ClickSound(bool isOn)
        {
            OnChangeSound?.Invoke(isOn);
        }
        
        private void ClickMusic(bool isOn)
        {
            OnChangeMusic?.Invoke(isOn);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
            _soundToggle.onValueChanged.RemoveAllListeners();
            _musicToggle.onValueChanged.RemoveAllListeners();
        }
    }
}