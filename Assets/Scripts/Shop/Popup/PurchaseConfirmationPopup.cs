using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Popup
{
    public class PurchaseConfirmationPopup : MonoBehaviour
    {
        public event Action OnBuyClick;
        public event Action OnCloseClick;

        private const string _explanatoryFormat = "Would you like to purchase {0}?";
        private const string _congratulationFormat = "Сongratulations on the purchase of the {0}!";
        
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _closeButton;

        public void Init()
        {
            _buyButton.onClick.RemoveListener(BuyClick);
            _buyButton.onClick.AddListener(BuyClick);
            
            _closeButton.onClick.RemoveListener(CloseClick);
            _closeButton.onClick.AddListener(CloseClick);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetupBuyingPopup(string productName)
        {
            _buyButton.gameObject.SetActive(true);
            _description.text = string.Format(_explanatoryFormat, productName);
        }
        
        public void SetupCongratulationPopup(string productName)
        {
            _buyButton.gameObject.SetActive(false);
            _description.text = string.Format(_congratulationFormat, productName);
        }
        
        private void BuyClick()
        {
            OnBuyClick?.Invoke();
        }
        
        private void CloseClick()
        {
            OnCloseClick?.Invoke();
        }
        
        private void OnDestroy()
        {
            _buyButton.onClick.RemoveListener(BuyClick);
            _closeButton.onClick.RemoveListener(CloseClick);
        }
    }
}
