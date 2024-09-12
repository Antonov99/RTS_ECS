using System;
using DefaultNamespace;
using JetBrains.Annotations;
using Zenject;

namespace Money
{
    [UsedImplicitly]
    public sealed class MoneyPresenter:IInitializable, IDisposable
    {
        private MoneyStorage[] _moneyStorage;
        
        public event Action<string, TeamData> OnMoneyChanged;

        [Inject]
        public void Construct(MoneyStorage[] moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        void IInitializable.Initialize()
        {
            foreach (var storage in _moneyStorage)
            {
                storage.OnMoneyChanged += UpdateMoney;
            }
        }

        void IDisposable.Dispose()
        {
            foreach (var storage in _moneyStorage)
            {
                storage.OnMoneyChanged -= UpdateMoney;
            }
        }

        private void UpdateMoney(int money, TeamData team)
        {
            string moneyText = money.ToString();
            OnMoneyChanged?.Invoke(moneyText, team);
        }
    }
}