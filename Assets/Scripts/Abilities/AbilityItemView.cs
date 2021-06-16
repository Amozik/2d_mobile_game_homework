using System;
using MobileGame.Interfaces.Items;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Abilities
{
    public class AbilityItemView : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField] 
        private Text _title;
        
        private IItem _item;

        private Action<IItem> _request;
        
        public void Init(IItem item, Action<IItem> request, bool isEquipped = false)
        {
            _item = item;
            _title.text = item.Info.Title;
            _button.onClick.AddListener(OnAbilityClick);
            _request = request;
        }

        private void OnAbilityClick()
        {
            _request?.Invoke(_item);
        }
    }
}