using System;
using DefaultNamespace;
using DefaultNamespace.GameSystems;
using JetBrains.Annotations;
using Zenject;

namespace Units
{
    [UsedImplicitly]
    public class UnitsCatalogPresenter:IInitializable,IDisposable
    {
        private readonly UnitsCatalogView _catalogView;
        private readonly UnitBuyer _unitBuyer;
        
        public UnitsCatalogPresenter(UnitsCatalogView view,UnitBuyer unitBuyer)
        {
            _catalogView = view;
            _unitBuyer = unitBuyer;
        }

        void IInitializable.Initialize()
        {
            _catalogView.OnBuyUnit += BuyUnit;
        }
        
        private void BuyUnit(UnitsData data)
        {
            _unitBuyer.BuyUnit(data);
        }

        void IDisposable.Dispose()
        {
            _catalogView.OnBuyUnit -= BuyUnit;
        }
    }
}