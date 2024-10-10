using System;
using DefaultNamespace;
using JetBrains.Annotations;
using Zenject;

namespace Money
{
    [UsedImplicitly]
    public sealed class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly MoneyView _moneyView;
        private readonly MoneyStorage _moneyStorage;

        public MoneyPresenter(MoneyView moneyView, MoneyStorage moneyStorage)
        {
            _moneyView = moneyView;
            _moneyStorage = moneyStorage;
        }

        void IInitializable.Initialize()
        {
            _moneyStorage.OnMoneyChanged += UpdateMoney;
        }

        void IDisposable.Dispose()
        {
            _moneyStorage.OnMoneyChanged -= UpdateMoney;
        }

        private void UpdateMoney(int money)
        {
            string moneyText = money.ToString();
            _moneyView.UpdateMoney(moneyText);
        }
    }
}