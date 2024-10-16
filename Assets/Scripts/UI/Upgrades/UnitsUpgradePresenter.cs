using System;
using Data;
using DefaultNamespace;
using JetBrains.Annotations;
using Sample;
using Zenject;

namespace Upgrades
{
    [UsedImplicitly]
    public class UnitsUpgradePresenter : IInitializable, IDisposable
    {
        private readonly UnitsUpgradeView _upgradeView;
        private readonly UpgradesManager _upgradesManager;

        public UnitsUpgradePresenter(UnitsUpgradeView view, UpgradesManager upgradesManager)
        {
            _upgradeView = view;
            _upgradesManager = upgradesManager;
        }

        void IInitializable.Initialize()
        {
            _upgradeView.OnUpgradeUnit += UpgradeUnit;
        }

        private void UpgradeUnit(UpgradeType upgrade)
        {
            _upgradesManager.LevelUp(upgrade);
        }

        void IDisposable.Dispose()
        {
            _upgradeView.OnUpgradeUnit -= UpgradeUnit;
        }
    }
}