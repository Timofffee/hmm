using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.hmm.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerUnits", menuName = "Map/PlayerUnits", order = 0)]
    public class PlayerUnits : ScriptableObject
    {
        public List<PlayerUnit> Units;
    }

    [Serializable]
    public class PlayerUnit
    {
        public Vector2Int position;
        public int count;
        public int unitIndex;
    }
}