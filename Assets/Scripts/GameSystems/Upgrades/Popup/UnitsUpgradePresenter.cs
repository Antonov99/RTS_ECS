using System;
using Data;
using DefaultNamespace;
using JetBrains.Annotations;
using Zenject;

namespace Upgrades
{
    [UsedImplicitly]
    public class UnitsUpgradePresenter : IInitializable, IDisposable
    {
        private readonly UnitsUpgradeView _upgradeView;

        public event Action<UpgradeType, TeamData> OnUpgradeUnit;

        private const TeamData _TEAM = TeamData.BLUE;

        public UnitsUpgradePresenter(UnitsUpgradeView view)
        {
            _upgradeView = view;
        }

        void IInitializable.Initialize()
        {
            _upgradeView.OnUpgradeUnit += BuyUnit;
        }

        private void BuyUnit(UpgradeType upgrade)
        {
            OnUpgradeUnit?.Invoke(upgrade, _TEAM);
        }

        void IDisposable.Dispose()
        {
            _upgradeView.OnUpgradeUnit -= BuyUnit;
        }
    }
}