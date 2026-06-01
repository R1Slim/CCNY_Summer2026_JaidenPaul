using UnityEngine;

public class PlayerWASD : MonoBehaviour
{
    public float speed = 100f; // Speed of the player movement
    public KeyCode left = KeyCode.A; // Key to move left
    public KeyCode right = KeyCode.D; // Key to move right
    public Rigidbody2D PlayerRB; // Player Rigidbody2D component

    Transform PlayerT; //Player Transform
    PlayerWASD Script; // Player Script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Script = this; // Assign the current instance of the script to the Script variable
        PlayerT = gameObject.transform;
        PlayerRB = gameObject.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player game object
    }

    // Update is called once per frame
    void Update()
    {
        OmniMovemnet(); // Call the move function to handle player movement

    }
    void move()
    {


        if (Input.GetKey(left))
        {
            PlayerRB.linearVelocity = Vector3.left * speed * Time.deltaTime;
        }



        if (Input.GetKey(right))
        {
            PlayerRB.linearVelocity = Vector3.right * speed * Time.deltaTime;
        }
        if (!Input.GetKey(left) && !Input.GetKey(right))
        {
            PlayerRB.linearVelocity = Vector3.zero; // Stop the player when no movement keys are pressed
        }
    }
    Vector3 Movement()
    {
        Vector3 movement = Vector3.zero; // Initialize movement vector to zero
        if (Input.GetKey(left))
        {
            movement += Vector3.left; // Add left movement to the movement vector
        }
        if (Input.GetKey(right))
        {
            movement += Vector3.right; // Add right movement to the movement vector
        }
        return movement.normalized * speed * Time.deltaTime; // Normalize the movement vector and scale it by speed and deltaTime
    }
    Vector3 OmniMovemnet()
    {
        {
            float h = Input.GetAxisRaw("Horizontal"); // Get horizontal input axis value
            float v = Input.GetAxisRaw("Vertical"); // Get vertical input axis value
            return new Vector3(h, v, 0f).normalized * speed * Time.deltaTime; // Create a movement vector based on input and scale it by speed and deltaTime
        }
    }
}

