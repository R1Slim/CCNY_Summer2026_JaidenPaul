using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerWASD : MonoBehaviour
{   
    public float points = 0f; // Player's score
    
    public float speed = 100f; // Speed of the player movement
    public KeyCode left = KeyCode.A; // Key to move left
    public KeyCode right = KeyCode.D; // Key to move right
    public KeyCode down = KeyCode.S; // Key to move down
    public KeyCode up = KeyCode.W; // Key to move up
    public bool canjump = false; // Flag to check if the player can jump
    public Rigidbody2D PlayerRB; // Player Rigidbody2D component
    public float jumpForce = 500f; // Force applied for jumping


    Transform PlayerT; //Player Transform
    PlayerWASD Script; // Player Script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Script = this; // Assign the current instance of the script to the Script variable
        PlayerT = gameObject.transform;
        PlayerRB = gameObject.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player game object
        touchingcheck(); // Call the function to check if the player is touching the ground at the start of the game
        //stick the touching check to the player so it can be called in the jump function to check if the player can jump or not
        
    }

    // Update is called once per frame
    void Update()
    {
     
         
        jump(); // Call the jump function to handle player jumping


    }
    private void FixedUpdate()
    {
        Vector3 dir = OmniMovemnet(Time.fixedDeltaTime); // Get the movement direction from the OmniMovement function
        dir.y = 0; // Preserve the vertical velocity for jumping
        if (dir != Vector3.zero) // Check if there is any movement input
        {
            PlayerRB.linearVelocity = new Vector2(dir.x, PlayerRB.linearVelocity.y); // Set the player's horizontal velocity based on the movement direction while preserving the vertical velocity
        }
    }
    //void move()
    //{


    //    if (Input.GetKey(left))
    //    {
    //        PlayerRB.linearVelocity = Vector3.left * speed * Time.deltaTime;
    //    }



    //    if (Input.GetKey(right))
    //    {
    //        PlayerRB.linearVelocity = Vector3.right * speed * Time.deltaTime;
    //    }
    //    if (!Input.GetKey(left) && !Input.GetKey(right))
    //    {
    //        PlayerRB.linearVelocity = Vector3.zero; // Stop the player when no movement keys are pressed
    //    }
    //}
    //Vector3 Movement()
    //{
    //    Vector3 movement = Vector3.zero; // Initialize movement vector to zero
    //    if (Input.GetKey(left))
    //    {
    //        movement += Vector3.left; // Add left movement to the movement vector
    //    }
    //    if (Input.GetKey(right))
    //    {
    //        movement += Vector3.right; // Add right movement to the movement vector
    //    }
    //    return movement.normalized * speed * Time.deltaTime; // Normalize the movement vector and scale it by speed and deltaTime
    //}

    Vector3 OmniMovemnet(float deltaT)
    {
        float h = Input.GetAxisRaw("Horizontal"); // Get horizontal input axis value
        float v = Input.GetAxisRaw("Vertical"); // Get vertical input axis value
        return new Vector3(h, v, 0f).normalized * speed * deltaT; // Create a movement vector based on input and scale it by speed and deltaTime
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            points += 1; // Increment the player's score by 1 when colliding with a coin
            Destroy(collision.gameObject); // Destroy the coin game object when the player collides with it
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(up) && canjump) // Check if the jump key is pressed
        {
            PlayerRB.AddForce(Vector2.up * jumpForce); // Apply an upward force to the player's Rigidbody2D to make it jump
        }
    }
    void touchingcheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f); // Cast a ray downwards from the player's position to check for ground
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red); // Draw a debug ray in the scene view for visualization
        if (hit.collider != null) // Check if the ray hit a collider
        {
            canjump = true; // Set canjump to true if the player is touching the ground and the jump key is pressed
        }
    }
}


