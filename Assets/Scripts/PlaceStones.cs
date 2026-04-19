using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceStones : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject blackStonePrefab;
    [SerializeField] private GameObject whiteStonePrefab;
    [SerializeField] private LayerMask stoneLayer;
    
    [SerializeField] private float cellSize;
    private int gridSize = 9;
    private CustomGrid grid;

    private bool blackTurn = true;
    
    [SerializeField] private AudioClip[] placeStoneSounds;
    [SerializeField] private AudioClip removeStoneSound;
    private float volume = 1f;

    void Start()
    {
        grid = new CustomGrid(gridSize, gridSize, cellSize);
    }
    
    public void OnPointerDown(PointerEventData eventData) 
    {
        Vector3 clickPosition = eventData.pointerCurrentRaycast.worldPosition;
        
        int gridIndexX = (int)(Math.Round(clickPosition.x / cellSize) + gridSize / 2);
        int gridIndexY = (int)(Math.Round(clickPosition.y / cellSize) + gridSize / 2);
        
        // Get the collider - if we clicked on the Stone Layer, the collider won't be null, and we'll remove the stone
        Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition, stoneLayer);
        Debug.Log(hitCollider);
        Debug.Log(grid.CheckPosition(gridIndexX, gridIndexY));
        
        if (hitCollider != null)  // Remove the stone
        {
            Destroy(hitCollider.gameObject);  // Since we have the collider of the stone, we can destroy the game object it through the collider
            grid.RemoveStone(gridIndexX, gridIndexY);
            SoundFXManager.instance.PlaySound(removeStoneSound, transform, volume);
            return;  // So that we don't proceed with the code
        }  
        
        // Place either a white or black stone
        if (blackTurn)
        {
            GameObject newStone = Instantiate(blackStonePrefab, transform);
            newStone.transform.position = grid.GetWorldPosition(gridIndexX, gridIndexY);
            SoundFXManager.instance.PlayRandomSound(placeStoneSounds, transform, volume);
            
            grid.SetStone(gridIndexX, gridIndexY, 1);  // 1 to indicate black
        }
        else
        {
            GameObject newStone = Instantiate(whiteStonePrefab, transform);
            newStone.transform.position = grid.GetWorldPosition(gridIndexX, gridIndexY);
            SoundFXManager.instance.PlayRandomSound(placeStoneSounds, transform, volume);
            
            grid.SetStone(gridIndexX, gridIndexY, 2);  // 1 to indicate white
        }
        
        blackTurn = !blackTurn;  // Toggle turns
        
    }
}
