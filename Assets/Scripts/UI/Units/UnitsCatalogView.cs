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

        public event Action<UnitsType> OnBuyUnit;

        private void Awake()
        {
            warriorBuyer.onClick.AddListener(OnSpawnWarrior);
            archerBuyer.onClick.AddListener(OnSpawnArcher);
            wizardBuyer.onClick.AddListener(OnSpawnWizard);
        }

        private void OnSpawnWarrior()
        {
            OnBuyUnit?.Invoke(UnitsType.WARRIOR);
        }
        
        private void OnSpawnArcher()
        {
            OnBuyUnit?.Invoke(UnitsType.ARCHER);
        }
        
        private void OnSpawnWizard()
        {
            OnBuyUnit?.Invoke(UnitsType.WIZARD);
        }

        private void OnDestroy()
        {
            warriorBuyer.onClick.RemoveListener(OnSpawnWarrior);
            archerBuyer.onClick.RemoveListener(OnSpawnArcher);
            wizardBuyer.onClick.RemoveListener(OnSpawnWizard);
        }
    }
}