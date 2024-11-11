using System;
using UnityEngine;
using UnityEngine.UI;
using View;

namespace MainMenu
{
    public class MainMenuView : MonoBehaviour, IView
    {
        public event Action OnClickShop;
        public event Action OnClickSetting;
        public event Action OnClickExit;
        
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _exitButton;

        public void Init()
        {
            _shopButton.onClick.RemoveListener(ClickShop);
            _shopButton.onClick.AddListener(ClickShop);
            
            _settingButton.onClick.RemoveListener(ClickSetting);
            _settingButton.onClick.AddListener(ClickSetting);
            
            _exitButton.onClick.RemoveListener(ClickExit);
            _exitButton.onClick.AddListener(ClickExit);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        
        private void ClickShop()
        {
            OnClickShop?.Invoke();
        }
        
        private void ClickSetting()
        {
            OnClickSetting?.Invoke();
        }
        
        private void ClickExit()
        {
            OnClickExit?.Invoke();
        }

        private void OnDestroy()
        {
            _shopButton.onClick.RemoveAllListeners();
            _settingButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}