using System;
using Sirenix.OdinInspector;

namespace Money
{
    [Serializable]
    public sealed class MoneyStorage
    {
        public event Action<int> OnMoneyChanged;
        public event Action<int> OnMoneyEarned;
        public event Action<int> OnMoneySpent;

        [ReadOnly, ShowInInspector] public int Money { get; private set; }

        [Title("Methods")]
        [Button]
        [GUIColor(0, 1, 0)]
        public void EarnMoney(int amount)
        {
            if (amount == 0)
            {
                return;
            }

            if (amount < 0)
            {
                throw new Exception($"Can not earn negative money {amount}");
            }

            var previousValue = Money;
            var newValue = previousValue + amount;

            Money = newValue;
            OnMoneyChanged?.Invoke(newValue);
            OnMoneyEarned?.Invoke(amount);
        }

        [Button]
        [GUIColor(0, 1, 0)]
        public void SpendMoney(int amount)
        {
            if (amount == 0)
            {
                return;
            }

            if (amount < 0)
            {
                throw new Exception($"Can not spend negative money {amount}");
            }

            var previousValue = Money;
            var newValue = previousValue - amount;
            if (newValue < 0)
            {
                throw new Exception(
                    $"Negative money after spend. Money in bank: {previousValue}, spend amount {amount} ");
            }

            Money = newValue;
            OnMoneyChanged?.Invoke(newValue);
            OnMoneySpent?.Invoke(amount);
        }

        [Button]
        [GUIColor(0, 1, 0)]
        public void SetupMoney(int money)
        {
            Money = money;
            OnMoneyChanged?.Invoke(money);
        }

        public bool CanSpendMoney(int amount)
        {
            return Money >= amount;
        }
    }
}