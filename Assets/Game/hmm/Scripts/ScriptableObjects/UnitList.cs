using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.hmm.ScriptableObjects
{
    [CreateAssetMenu(fileName = "UnitList", menuName = "Unit/UnitList", order = 0)]
    public class UnitList : ScriptableObject
    {
        public List<UnitData> Units;
    }

    [Serializable]
    public class UnitData
    {
        public string name;
        public GameObject unitPrefab;
    }
}