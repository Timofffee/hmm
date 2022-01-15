using UnityEngine;

namespace Game.hmm.ScriptableObjects
{
    [CreateAssetMenu(fileName = "UnitBaseStats", menuName = "Unit/UnitBaseStats", order = 0)]
    public class UnitBaseStats : ScriptableObject
    {
        [Min(1)]
        public int health;
        [Min(0)]
        public int speed;
        [Min(0)]
        public int initiative;
    }
}