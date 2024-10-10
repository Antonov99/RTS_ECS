using UnityEngine;

namespace DefaultNamespace.GameSystems
{
    [CreateAssetMenu(
        fileName = "UnitsCatalog",
        menuName = "Units/New UnitsCatalog"
    )]
    public class UnitsCatalog:ScriptableObject
    {
        [SerializeField]
        private UnitConfig[] configs;

        public UnitConfig[] GetAllUnits()
        {
            return configs;
        }
    }
}