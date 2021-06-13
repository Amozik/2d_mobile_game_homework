using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MobileGame.Data.Items;
using MobileGame.Interfaces.Garage;
using MobileGame.Interfaces.Inventory;
using MobileGame.Interfaces.Items;
using MobileGame.Interfaces.Upgrades;
using MobileGame.Inventory;
using MobileGame.Items;
using MobileGame.Upgrades;
using Platformer.Player;
using UnityEngine;

namespace MobileGame.Controllers
{
    public class GarageController : BaseController, IGarageController
    {
        private readonly Car _car;

        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly IInventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;

        public GarageController([NotNull] List<UpgradeItemConfig> upgradeItemConfigs, [NotNull] Car car, Transform placeForUi)
        {
            _car = car;
            
            _upgradeHandlersRepository
                = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddController(_upgradeHandlersRepository);
            
            _upgradeItemsRepository
                = new ItemsRepository(upgradeItemConfigs.Select(value => value.itemConfig).ToList());
            AddController(_upgradeItemsRepository);

            _inventoryModel = new InventoryModel();

            _inventoryController = new InventoryController(_inventoryModel, _upgradeItemsRepository, placeForUi);
            AddController(_inventoryController);

        }
        
        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
            Debug.Log($"Enter: car has speed : {_car.Speed}");
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(_car, _inventoryModel.GetEquippedItems(), _upgradeHandlersRepository.UpgradeItems);
            Debug.Log($"Exit: car has speed : {_car.Speed}");
        }
        
        private void UpgradeCarWithEquippedItems(
            IUpgradableCar upgradableCar,
            IReadOnlyList<IItem> equippedItems,
            IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(upgradableCar);
                }
            }
        }

    }
}