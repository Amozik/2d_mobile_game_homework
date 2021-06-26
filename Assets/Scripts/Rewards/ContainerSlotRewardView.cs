﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MobileGame.Rewards
{
    public class ContainerSlotRewardView : MonoBehaviour
    {
        [SerializeField] 
        private Image _selectBackground;
    
        [SerializeField] 
        private Image _iconCurrency;
    
        [SerializeField] 
        private TMP_Text _textDays;
    
        [SerializeField] 
        private TMP_Text _countReward;

        public void SetData(Reward reward, int countDay, bool isSelect)
        {
            _iconCurrency.sprite = reward.iconCurrency;
            _textDays.text = $"Day {countDay}";
            _countReward.text = reward.countCurrency.ToString();
            _selectBackground.gameObject.SetActive(isSelect);
        }
    }
}