using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] 
        private Text _title;

        public Text Title => _title;
    }
}