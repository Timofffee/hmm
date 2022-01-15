using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.hmm.ScriptableObjects;
using UnityEngine;

namespace Game.hmm.Map
{
    public class MapComponent : MonoBehaviour
    {
        [Header("Data")]
        private Dictionary<Vector2Int, HexComponent> cells = new Dictionary<Vector2Int, HexComponent>();
        private List<Vector2Int> avaliableHexList = new List<Vector2Int>();

        [Header("Scriptable Objects")]
        public PlayerList players;

        private void Awake()
        {
            GetComponent<MapGenerator>().GenerateMap();

            gameObject.GetComponentsInChildren<HexComponent>().ToList().ForEach(hex =>
            {
                cells.Add(hex.cellPos, hex);
            });
        }

        private IEnumerator Start()
        {
            yield return null;
            SetAvaliableRadius(new Vector2Int(6, 4), 1);
        }

        public void SetAvaliableRadius(Vector2Int cellPos, int cellRadius)
        {
            for (int yOffset = -cellRadius; yOffset <= cellRadius; yOffset++)
            {
                int minXOffset = -cellRadius + Mathf.Abs(yOffset / 2);
                int maxXOffset = cellRadius - Mathf.Abs(yOffset / 2) + 1;

                if (cellPos.y % 2 == 0)
                {
                    if (yOffset % 2 != 0)
                        minXOffset++;
                }
                else
                {
                    if (yOffset % 2 != 0)
                        maxXOffset--;
                }

                for (int xOffset = minXOffset; xOffset < maxXOffset; xOffset++)
                {
                    var pos = new Vector2Int(cellPos.x + xOffset, cellPos.y + yOffset);
                    if (cells.ContainsKey(pos) && cells[pos].unitOnHex == null)
                    {
                        AddAvaliableHex(pos);
                    }
                }
            }

            RemoveAvaliableHex(cellPos);
        }

        public void AddAvaliableHex(Vector2Int cellPos)
        {
            cells[cellPos].IsAvaliable = true;
            avaliableHexList.Add(cellPos);
        }

        public void RemoveAvaliableHex(Vector2Int cellPos)
        {
            cells[cellPos].IsAvaliable = false;
            avaliableHexList.Remove(cellPos);
        }

        public void ResetAvaliable()
        {
            for (int idx = 0; idx < avaliableHexList.Count; idx++)
            {
                cells[avaliableHexList[idx]].IsAvaliable = false;
            }

            avaliableHexList.Clear();
        }
    }
}
