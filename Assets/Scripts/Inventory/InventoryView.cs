using System;
using System.Collections.Generic;
using MobileGame.Interfaces.Inventory;
using MobileGame.Interfaces.Items;
using MobileGame.Tools;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MobileGame.Inventory
{
    public sealed class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] 
        private Transform _targetItems;
        
        [SerializeField] 
        private Button _closeBtn;
        
        private readonly ResourcePath _itemViewPath = new ResourcePath {PathResource = "Prefabs/inventoryItem"};
        
        public Action<IItem> Selected { get; set; }
        public Action<IItem> Deselected { get; set; }
        
        private IReadOnlyList<IItem> _itemInfoCollection;
        private List<InventoryItemView> _itemViiewCollection = new List<InventoryItemView>();
        private CanvasGroup _canvasGroup;

        public void OnEnable()
        {
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
            SetupCanvasGroup(false);
            
            _closeBtn.onClick.AddListener(UnDisplay);
        }

        public void Display(IReadOnlyList<IItem> items)
        {
            SetupCanvasGroup(true);
            _itemInfoCollection = items;
            foreach (var item in items)
            {
                var itemView = Object.Instantiate(ResourceLoader.LoadPrefab(_itemViewPath), _targetItems, false);

                var inventoryItemView = itemView.GetComponent<InventoryItemView>();
                inventoryItemView.Init(item, OnItemViewSelect);
                    
                _itemViiewCollection.Add(inventoryItemView);
            }
        }

        public void UnDisplay()
        {
            SetupCanvasGroup(false);
        }

        private void OnItemViewSelect(IItem item, bool isSelected)
        {
            if (isSelected)
            {
                OnSelected(item);
            }
            else
            {
                OnDeselected(item);
            }
        }

        private void OnSelected(IItem e)
        {
            Selected?.Invoke(e);
        }

        private void OnDeselected(IItem e)
        {
            Deselected?.Invoke(e);
        }

        private void SetupCanvasGroup(bool value)
        {
            _canvasGroup.alpha = value ? 1 : 0;
            _canvasGroup.interactable = value;
            _canvasGroup.blocksRaycasts = value;
        }
    }
}