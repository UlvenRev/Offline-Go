using Unity.VectorGraphics;
using UnityEngine;

public class CustomGrid
{
    private int width, height;
    private float cellSize;
    private int[,] gridArray;

    public CustomGrid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        
        gridArray = new int[width, height];

        // for (int x = 0; x < gridArray.GetLength(0); x++)  // .GetLength(0) to get the length of the first dimension
        // {
        //     for (int y = 0; y < gridArray.GetLength(1); y++)  // .GetLength(1) to get the length of the second   dimension
        //     {
        //         CreateWorldText(gridArray[x, y].ToString(), GameObject.Find("Board").GetComponent<Transform>(), GetWorldPosition(x, y), 3, Color.white, TextAnchor.MiddleCenter);
        //     }
        // }
    }

    public int CheckPosition(int x, int y)
    {
        return gridArray[x, y];
    }

    public int[,] SetStone(int x, int y, int stone)
    {
        gridArray[x, y] = stone;  // 0 for empty, 1 for black, 2 for white
        return gridArray;
    }

    public int[,] RemoveStone(int x, int y)
    {
        gridArray[x, y] = 0;
        return gridArray;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        // 9 INTERSECTIONS (width), but 8 squares => half is 4 => 8 * the actual cellSize we chose to have 8 squares and / 2
        float offsetX = (width - 1) * cellSize / 2;
        float offsetY = (height - 1) * cellSize / 2;
        
        return new Vector3(x * cellSize - offsetX, y *  cellSize - offsetY, 0);
    }

    public TextMesh CreateWorldText(string text, Transform parent, Vector3 localPosition, int fontSize, Color color,
        TextAnchor textAnchor, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
