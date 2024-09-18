using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(
        fileName = "InitialUnitStats",
        menuName = "Units/New InitialUnitStats"
    )]
    public class StatsConfig:SerializedScriptableObject
    {
        [OdinSerialize]
        public Dictionary<StatsData,int> Stats;

        public int GetStat(StatsData id)
        {
            return Stats[id];
        }
    }
}