using System.Collections;
using System.Collections.Generic;
using Game.hmm.ScriptableObjects;
using Game.hmm.Unit;
using UnityEngine;

namespace Game.hmm.Map
{
    [RequireComponent(typeof(HexComponent))]
    public class UnitPlaceholder : MonoBehaviour
    {
        private HexComponent _hexComponent;
        private Transform _transform;

        [SerializeField] private UnitList unitList;
        [SerializeField] private PlayerList playerList;

        private void Awake()
        {
            _hexComponent = GetComponent<HexComponent>();
            _transform = transform;
        }

        private void Start()
        {
            InstantiateUnit();
        }

        public void InstantiateUnit()
        {
            for (int playerIdx = 0; playerIdx < playerList.Players.Count; playerIdx++)
            {
                for (int idx = 0; idx < playerList.Players[playerIdx].Units.Count; idx++)
                {
                    if (_hexComponent.cellPos == playerList.Players[playerIdx].Units[idx].position)
                    {
                        var unitIndex = playerList.Players[playerIdx].Units[idx].unitIndex;
                        var unitPrefab = unitList.Units[unitIndex].unitPrefab;
                        var unitObj = Instantiate(unitPrefab, _transform.position, Quaternion.identity, _transform.parent);
                        var unit = unitObj.GetComponent<UnitComponent>();
                        unit.Count = playerList.Players[playerIdx].Units[idx].count;
                        unit.playerIdx = playerIdx;
                        _hexComponent.unitOnHex = unit;

                        break;
                    }
                }
            }

        }
    }
}