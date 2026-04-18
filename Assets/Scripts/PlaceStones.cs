using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceStones : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject blackStonePrefab;
    [SerializeField] private GameObject whiteStonePrefab;
    
    
    
    public void OnPointerDown(PointerEventData eventData) 
    {
        Vector3 clickPosition = eventData.pointerCurrentRaycast.worldPosition;
        Debug.Log(clickPosition);
        
        Vector3 localPoint = transform.InverseTransformPoint(clickPosition);
        Debug.Log(localPoint);
    }
}
