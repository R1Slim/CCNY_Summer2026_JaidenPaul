using UnityEngine;

public class PlayerWASD : MonoBehaviour
{
    public float speed; // Speed of the player movement
    public KeyCode left = KeyCode.A; // Key to move left
    public KeyCode right = KeyCode.D; // Key to move right

    Transform PlayerT; //Player Transform
    PlayerWASD Script; // Player Script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Script = this; // Assign the current instance of the script to the Script variable
        PlayerT = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(left))
        {
            PlayerT.position -= Vector3.right * speed;
        }
        if(Input.GetKey(right))
        {
            PlayerT.position += Vector3.right * speed;
        }   
    }
}
