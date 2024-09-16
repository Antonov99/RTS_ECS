using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(
        fileName = "UnitsPriceCatalog",
        menuName = "Units/New UnitsPriceCatalog"
    )]
    public class PriceCatalog:SerializedScriptableObject
    {
        [OdinSerialize]
        public Dictionary<UnitsData,int> Price;

        public int GetPrice(UnitsData id)
        {
            return Price[id];
        }
    }
}