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
    public class StatsConfig : SerializedScriptableObject
    {
        //ToDo
        [OdinSerialize]
        public Dictionary<StatsType, int> stats;

        public int GetStat(StatsType id)
        {
            return stats[id];
        }
    }
}