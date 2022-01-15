using System.Collections;
using System.Collections.Generic;
using Game.hmm.Map;
using UnityEngine;

namespace Game.hmm.Map
{
    public class MapGenerator : MonoBehaviour
    {
        [Header("Generate Data")]
        public Vector2 size = new Vector2Int(15, 11);
        public Vector2 cellSize = new Vector2(1, 0.75f);
        public GameObject cellPrefab;

        public void GenerateMap()
        {
            float zStartOffset = (float)size.y / 2;

            for (int lineIdx = 0; lineIdx < size.y; lineIdx++)
            {
                float xOffset = -(float)size.x / 2 * cellSize.x;
                if (lineIdx % 2 == 0)
                    xOffset += cellSize.x / 2;
                Vector3 startLinePosition = new Vector3(xOffset, 0, zStartOffset - cellSize.y * lineIdx);
                Vector3 cellLineOffset = new Vector3(cellSize.x, 0, 0);

                for (int columnIdx = 0; columnIdx < size.x; columnIdx++)
                {
                    GameObject obj = Instantiate(cellPrefab, startLinePosition + cellLineOffset * columnIdx, Quaternion.identity, transform);
                    HexComponent hexComponent = obj.GetComponent<HexComponent>();
                    hexComponent.cellPos = new Vector2Int(columnIdx, lineIdx);
                }
            }
        }
    }
}