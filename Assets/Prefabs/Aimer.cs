using UnityEngine;

public class Aimer : MonoBehaviour
{
    public GameObject crosshair;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(p);
        pos.z = 0;
        crosshair.transform.position = pos;
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse 0 down");
    }

    private void OnMouseUp()
    {
        Debug.Log("mouse 0 up");
    }

    private void OnMouseDrag()
    {
        Debug.Log("mouse is moving"); 
    }
}
