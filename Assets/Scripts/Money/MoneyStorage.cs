using System;
using DefaultNamespace;
using Sirenix.OdinInspector;

namespace Money
{
    [Serializable]
    public sealed class MoneyStorage
    {
        public event Action<int, TeamData> OnMoneyChanged;
        public event Action<int> OnMoneyEarned;
        public event Action<int> OnMoneySpent;
        
        [ReadOnly, ShowInInspector]
        public int money { get; private set; }

        public TeamData team;

        public MoneyStorage(TeamData teamData)
        {
            team = teamData;
        }

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

            var previousValue = money;
            var newValue = previousValue + amount;

            money = newValue;
            OnMoneyChanged?.Invoke(newValue,team);
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

            var previousValue = money;
            var newValue = previousValue - amount;
            if (newValue < 0)
            {
                throw new Exception(
                    $"Negative money after spend. Money in bank: {previousValue}, spend amount {amount} ");
            }

            money = newValue;
            OnMoneyChanged?.Invoke(newValue,team);
            OnMoneySpent?.Invoke(amount);
        }

        [Button]
        [GUIColor(0, 1, 0)]
        public void SetupMoney(int money)
        {
            this.money = money;
            OnMoneyChanged?.Invoke(money,team);
        }

        public bool CanSpendMoney(int amount)
        {
            return money >= amount;
        }
    }
}