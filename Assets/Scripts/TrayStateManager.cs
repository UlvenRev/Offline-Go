using UnityEngine;
using TMPro;

public class TrayStateManager : MonoBehaviour
{
    [SerializeField] private GameObject blackStonePrefab;
    [SerializeField] private GameObject whiteStonePrefab;
    [SerializeField] private TMP_Text whiteCapturesText;
    [SerializeField] private TMP_Text blackCapturesText;

    private float minX, maxX, minY, maxY;
    private int whiteCaptures, blackCaptures;
    
    void Start()
    {
        // Establishing the range for random placement of the stones within a tray:
        float width = GetComponent<SpriteRenderer>().bounds.size.x - 0.9f;  // Shortening slightly because of the curvature of the tray
        float height = GetComponent<SpriteRenderer>().bounds.size.y - 0.9f;
        
        minX = transform.position.x - width / 2;
        maxX = transform.position.x + width / 2;
        minY = transform.position.y - height / 2;
        maxY = transform.position.y + height / 2;
    }
    
    public void AddStone(int stone)  // 1 for black, 2 for white
    {
        GameObject newStone;
        
        if (stone == 1)
        {
            newStone = Instantiate(blackStonePrefab, transform);
            whiteCaptures++;
            whiteCapturesText.text = "Captures: " + whiteCaptures;
        }
        else
        {
            newStone = Instantiate(whiteStonePrefab, transform);
            blackCaptures++;
            blackCapturesText.text = "Captures: " + blackCaptures;
        }
        
        Vector3 stonePosition = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), 0);
        newStone.transform.position = stonePosition;
    }
}
