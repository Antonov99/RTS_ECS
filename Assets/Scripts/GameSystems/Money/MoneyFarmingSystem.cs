using System;
using JetBrains.Annotations;
using Money;
using TimeManagement;
using UnityEngine;
using Zenject;
using ITickable = Zenject.ITickable;

namespace DefaultNamespace.GameSystems
{
    [UsedImplicitly]
    public sealed class MoneyFarmingSystem:IInitializable,IDisposable, ITickable
    {
        private MoneyStorage[] _moneyStorages;
        private Timer _timer;

        private const float _DURATION = 1f;
        private const int _AMOUNT = 1;
        
        [Inject]
        public void Construct(MoneyStorage[] moneyStorages)
        {
            _moneyStorages = moneyStorages;
        }

        void IInitializable.Initialize()
        {
            _timer = new Timer(_DURATION,true);

            _timer.Start();
            _timer.OnEnded += AddMoney;
        }

        private void AddMoney()
        {
            foreach (var storage in _moneyStorages)
            {
                storage.EarnMoney(_AMOUNT);
            }
        }

        void ITickable.Tick()
        {
            _timer.Tick(Time.deltaTime);
        }

        void IDisposable.Dispose()
        {
            _timer.OnEnded += AddMoney;
        }
    }
}