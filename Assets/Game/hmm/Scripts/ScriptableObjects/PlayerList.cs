using System.Collections.Generic;
using UnityEngine;

namespace Game.hmm.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerList", menuName = "Map/PlayerList", order = 0)]
    public class PlayerList : ScriptableObject
    {
        private List<PlayerUnits> _defaultPlayers;
        public List<PlayerUnits> Players;
    }
}