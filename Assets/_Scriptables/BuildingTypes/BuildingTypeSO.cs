using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    public string BuildingName;
    public Transform Prefab;
    public Transform Sprite;
    public int Width;
    public int Height;

    public Vector2 GetBuildingOffSet()
    {
        return new Vector2(Width, Height) / 2;
    }

    public List<Vector2Int> GetObjectPositionList(Vector2Int offSet)
    {
        List<Vector2Int> objectPosList = new List<Vector2Int>();

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                objectPosList.Add(new Vector2Int(x,y) + offSet);
            }
        }
        return objectPosList;
    }
}
