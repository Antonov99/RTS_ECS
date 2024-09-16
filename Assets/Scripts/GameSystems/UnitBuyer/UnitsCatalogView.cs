using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UnitsCatalogView:MonoBehaviour
    {
        [SerializeField]
        private Button warriorBuyer;
        
        [SerializeField]
        private Button archerBuyer;
        
        [SerializeField]
        private Button wizardBuyer;

        public event Action<UnitsData> OnBuyUnit;

        private void Awake()
        {
            warriorBuyer.onClick.AddListener(OnSpawnWarrior);
            archerBuyer.onClick.AddListener(OnSpawnArcher);
            wizardBuyer.onClick.AddListener(OnSpawnWizard);
        }

        private void OnSpawnWarrior()
        {
            OnBuyUnit?.Invoke(UnitsData.BLUE_WARRIOR);
        }
        
        private void OnSpawnArcher()
        {
            OnBuyUnit?.Invoke(UnitsData.BLUE_ARCHER);
        }
        
        private void OnSpawnWizard()
        {
            OnBuyUnit?.Invoke(UnitsData.BLUE_WIZARD);
        }

        private void OnDestroy()
        {
            warriorBuyer.onClick.RemoveListener(OnSpawnWarrior);
            archerBuyer.onClick.RemoveListener(OnSpawnArcher);
            wizardBuyer.onClick.RemoveListener(OnSpawnWizard);
        }
    }
}