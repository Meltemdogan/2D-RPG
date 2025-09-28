using System;
using Quest;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace Managers
{
    public class QuestCardPlayer : QuestCard
    {
        [Header("Config")]
        [SerializeField] private TextMeshProUGUI statusTMP;
        [SerializeField] private TextMeshProUGUI goldRewardTMP;
        [SerializeField] private TextMeshProUGUI expRewardTMP;
        
        [Header("Item")]
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI itemQuantityTMP;
        
        [Header("QuestCompleted")]
        [SerializeField] private GameObject claimButton;
        [SerializeField] private GameObject rewardsPanel;
        
        private void Update()
        {
            statusTMP.text = $"Status\n {QuestToComplete.CurrentStatus}/{QuestToComplete.QuestGoal}";
        }
        
        public override void ConfigQuestUI(Quest.Quest quest)
        {
            base.ConfigQuestUI(quest);
            statusTMP.text = $"Status\n {quest.CurrentStatus}/{quest.QuestGoal}";
            goldRewardTMP.text = quest.GoldReward.ToString();
            expRewardTMP.text = quest.ExpReward.ToString();
            
            itemIcon.sprite = quest.ItemReward.Item.Icon;
            itemQuantityTMP.text = quest.ItemReward.Quantity.ToString();
            
        }
        
        public void ClaimQuest()
        {
            GameManager.Instance.AddPlayerExp(QuestToComplete.ExpReward);
            Inventory.Inventory.Instance.AddItem(QuestToComplete.ItemReward.Item, QuestToComplete.ItemReward.Quantity);
            CoinManager.Instance.AddCoins(QuestToComplete.GoldReward);
            gameObject.SetActive(false);
        }
        private void QuestCompletedCheck()
        {
            claimButton.SetActive(true);
            rewardsPanel.SetActive(false);
        }
        
        private void OnEnable()
        {
            QuestCompletedCheck();
        }
    }
}