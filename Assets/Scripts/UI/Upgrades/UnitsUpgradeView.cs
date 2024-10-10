using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    public class UnitsUpgradeView:MonoBehaviour
    {
        [SerializeField]
        private Button healthUpgrade;
        
        [SerializeField]
        private Button powerUpgrade;
        
        [SerializeField]
        private Button speedUpgrade;

        public event Action<UpgradeType> OnUpgradeUnit;

        private void Awake()
        {
            healthUpgrade.onClick.AddListener(OnHealthUpgrade);
            powerUpgrade.onClick.AddListener(OnPowerUpgrade);
            speedUpgrade.onClick.AddListener(OnSpeedUpgrade);
        }

        private void OnHealthUpgrade()
        {
            OnUpgradeUnit?.Invoke(UpgradeType.HEALTH_UPGRADE);
        }
        
        private void OnPowerUpgrade()
        {
            OnUpgradeUnit?.Invoke(UpgradeType.POWER_UPGRADE);
        }
        
        private void OnSpeedUpgrade()
        {
            OnUpgradeUnit?.Invoke(UpgradeType.SPEED_UPGRADE);
        }

        private void OnDestroy()
        {
            healthUpgrade.onClick.RemoveListener(OnHealthUpgrade);
            powerUpgrade.onClick.RemoveListener(OnPowerUpgrade);
            speedUpgrade.onClick.RemoveListener(OnSpeedUpgrade);
        }
    }
}