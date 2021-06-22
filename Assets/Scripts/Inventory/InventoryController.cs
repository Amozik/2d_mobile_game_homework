using System;
using System.Collections.Generic;
using System.Linq;
using MobileGame.Controllers;
using MobileGame.Data.Items;
using MobileGame.Interfaces;
using MobileGame.Interfaces.Inventory;
using MobileGame.Interfaces.Items;
using MobileGame.Items;
using MobileGame.Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MobileGame.Inventory
{
    public class InventoryController: BaseController, IInventoryController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/inventory"};
        private readonly IInventoryModel _inventoryModel;
        private readonly IRepository<int, IItem> _itemsRepository;
        private readonly IInventoryView _inventoryWindowView;

        private Action _onHide;

        public InventoryController(List<ItemConfig> itemConfigs, Transform placeForUi)
        {
            _inventoryModel = new InventoryModel();
            _itemsRepository = new ItemsRepository(itemConfigs);
            _inventoryWindowView = LoadView(placeForUi);
        }
        
        public InventoryController(IInventoryModel inventoryModel, IRepository<int, IItem> itemsRepository, Transform placeForUi)
        {
            _inventoryModel = inventoryModel;
            _itemsRepository = itemsRepository;
            _inventoryWindowView = LoadView(placeForUi);
        }
        
        private InventoryView LoadView(Transform placeForUi)
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
        
            return objectView.GetComponent<InventoryView>();
        }
        
        public void ShowInventory(Action onHide)
        {
            _inventoryWindowView.Display(_itemsRepository.Collection.Values.ToList());
            _onHide += onHide;
            SubscribeView();
        }

        public void HideInventory()
        {
            _inventoryWindowView.UnDisplay();
            _onHide?.Invoke();
            UnSubscribeView();
        }

        private void SubscribeView()
        {
            _inventoryWindowView.CloseInventory += HideInventory;
            _inventoryWindowView.Selected += OnItemSelected;
            _inventoryWindowView.Deselected += OnItemDeselected;
        }

        private void UnSubscribeView()
        {
            _inventoryWindowView.CloseInventory -= HideInventory;
            _inventoryWindowView.Selected -= OnItemSelected;
            _inventoryWindowView.Deselected -= OnItemDeselected;
        } 

        private void OnItemSelected(IItem item)
        {
            _inventoryModel.EquipItem(item);
        }
        
        private void OnItemDeselected(IItem item)
        {
            _inventoryModel.UnEquipItem(item);
        }

        protected override void OnDispose()
        {
            UnSubscribeView();
            base.OnDispose();
        }
    }
}