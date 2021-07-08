using System;
using MobileGame.Extensions;
using MobileGame.Interfaces.Items;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        private const float ON_TRANSPARENCY = 1f;
        private const float OFF_TRANSPARENCY = .5f;
        
        [SerializeField]
        private Button _toggleButton;

        [SerializeField] 
        private Text _title;

        private Image _buttonImage;
        private IItem _item;
        private bool _isEquipped = false;

        private Action<IItem, bool> _toggle;

        public void Init(IItem item, Action<IItem, bool> toggle, bool isEquipped = false)
        {
            _buttonImage = GetComponent<Image>();

            _item = item;
            _title.text = item.Info.Title;
            _toggleButton.onClick.AddListener(OnToggle);
            _toggle = toggle;

            _isEquipped = isEquipped;
            _buttonImage.SetTransparency(_isEquipped ? ON_TRANSPARENCY : OFF_TRANSPARENCY);
        }

        private void OnToggle()
        {
            _buttonImage.SetTransparency(_isEquipped ? OFF_TRANSPARENCY : ON_TRANSPARENCY);
            _isEquipped = !_isEquipped;
            
            _toggle?.Invoke(_item, _isEquipped);
        }
    }
}