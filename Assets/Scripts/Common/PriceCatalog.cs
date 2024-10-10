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
        public Dictionary<UnitsType,int> Price;

        public int GetPrice(UnitsType id)
        {
            return Price[id];
        }
    }
}