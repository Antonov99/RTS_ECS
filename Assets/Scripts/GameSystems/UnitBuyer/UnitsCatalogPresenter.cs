using System;
using DefaultNamespace;
using JetBrains.Annotations;
using Zenject;

namespace Units
{
    [UsedImplicitly]
    public class UnitsCatalogPresenter:IInitializable,IDisposable
    {
        private readonly UnitsCatalogView _catalogView;

        public event Action<UnitsData, TeamData> OnBuyUnit;

        private const TeamData _TEAM = TeamData.BLUE;
        
        public UnitsCatalogPresenter(UnitsCatalogView view)
        {
            _catalogView = view;
        }

        void IInitializable.Initialize()
        {
            _catalogView.OnBuyUnit += BuyUnit;
        }
        
        private void BuyUnit(UnitsData data)
        {
            OnBuyUnit?.Invoke(data,_TEAM);
        }

        void IDisposable.Dispose()
        {
            _catalogView.OnBuyUnit -= BuyUnit;
        }

    }
}