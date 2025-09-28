using Extra;
using NPC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("Stats")] 
        [SerializeField] private PlayerStats stats;
        
        [Header("Bars")]
        [SerializeField] private Image healthBar;
        [SerializeField] private Image manaBar;
        [SerializeField] private Image expBar;
        
        [Header("Text")]
        [SerializeField]private TextMeshProUGUI levelTMP;
        [SerializeField] private TextMeshProUGUI healthTMP;
        [SerializeField] private TextMeshProUGUI manaTMP;
        [SerializeField] private TextMeshProUGUI expTMP;
        [SerializeField] private TextMeshProUGUI coinsTMP;
        
        [Header("Stats Panel")]
        [SerializeField] private GameObject statsPanel;
        [SerializeField] private TextMeshProUGUI statsLevelTMP;
        [SerializeField] private TextMeshProUGUI statsDamageTMP;
        [SerializeField] private TextMeshProUGUI statsCChanceTMP;
        [SerializeField] private TextMeshProUGUI statsCDamageTMP;
        [SerializeField] private TextMeshProUGUI statsTotalExpTMP;
        [SerializeField] private TextMeshProUGUI statsCurrentExpTMP;
        [SerializeField] private TextMeshProUGUI statsRequiredExpTMP;
        [SerializeField] private TextMeshProUGUI attributePointsTMP;
        [SerializeField] private TextMeshProUGUI strenghtTMP;
        [SerializeField] private TextMeshProUGUI dexterityExpTMP;
        [SerializeField] private TextMeshProUGUI intellegenceTMP;
        
        [Header("Extra Panels")]
        [SerializeField] private GameObject npcQuestPanel;
        [SerializeField] private GameObject playerQuestPanel;
        [SerializeField] private GameObject shopPanel;
        
        private void Update()
        {
            UpdatePlayerUI();
        }
        public void OpenCloseStatsPanel()
        {
            statsPanel.SetActive(!statsPanel.activeSelf);
            if(statsPanel.activeSelf)
            {
                UpdateStatsPanel();
            }
        }
        public void OpenCloseNPCQuestPanel(bool value)
        {
            npcQuestPanel.SetActive(value);
        }
        public void OpenClosePlayerQuestPanel(bool value)
        {
            playerQuestPanel.SetActive(value);
        }
        public void OpenCloseShopPanel(bool value)
        {
            shopPanel.SetActive(value);
        }
        
        private void UpdatePlayerUI()
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, stats.Health / stats.MaxHealth, Time.deltaTime * 10f);
            manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, stats.Mana / stats.MaxMana, Time.deltaTime * 10f);
            expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, stats.CurrentExp / stats.NextLevelExp, Time.deltaTime * 10f);
            
            levelTMP.text = $"Level: {stats.Level}";
            healthTMP.text = $"{stats.Health}/{stats.MaxHealth}";
            manaTMP.text = $"{stats.Mana}/{stats.MaxMana}";
            expTMP.text = $"{stats.CurrentExp}/{stats.NextLevelExp}";
            
            attributePointsTMP.text = $"Points: {stats.AttributePoints}";
            strenghtTMP.text = stats.Strenght.ToString();
            dexterityExpTMP.text = stats.Dexterity.ToString();
            intellegenceTMP.text = stats.Intelligence.ToString();
            coinsTMP.text = CoinManager.Instance.Coins.ToString();
        }
        
        private void UpdateStatsPanel()
        {
            statsLevelTMP.text = stats.Level.ToString();
            statsDamageTMP.text = stats.TotalDamage.ToString();
            statsCChanceTMP.text = stats.CriticalChance.ToString();
            statsCDamageTMP.text = stats.CriticalDamage.ToString();
            statsTotalExpTMP.text = stats.TotalExp.ToString();
            statsCurrentExpTMP.text = stats.CurrentExp.ToString();
            statsRequiredExpTMP.text = stats.NextLevelExp.ToString();
        }
        private void UpgradeCallback()
        {
            UpdateStatsPanel();
        }
        private void ExtraInteractionCallback(InteractionType type)
        {
            switch (type)
            {
                case InteractionType.Quest:
                    OpenCloseNPCQuestPanel(true);
                    break;
                case InteractionType.Shop:
                    OpenCloseShopPanel(true);
                    break;
            }
        }
        private void OnEnable()
        {
            PlayerUpgrade.OnPlayerUpgradeEvent += UpgradeCallback;
            DialogueManager.OnExtraInteractionEvent += ExtraInteractionCallback;
        }
        private void OnDisable()
        {
            PlayerUpgrade.OnPlayerUpgradeEvent -= UpgradeCallback;
            DialogueManager.OnExtraInteractionEvent -= ExtraInteractionCallback;
        }
    }
}