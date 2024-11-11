using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.View
{
    public class ShopItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Button _selectButton;
        
        private Action _clickCallback;

        public void Init()
        {
            _selectButton.onClick.RemoveListener(SelectItem);
            _selectButton.onClick.AddListener(SelectItem);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        
        public void Setup(ShopItemViewConfig config, Action clickCallback)
        {
            _image.sprite = config.Sprite;
            _description.text = config.Description;
            _clickCallback = clickCallback;
        }

        private void SelectItem()
        {
            _clickCallback?.Invoke();
        }

        private void OnDestroy()
        {
            _selectButton.onClick.RemoveAllListeners();
        }
    }
}