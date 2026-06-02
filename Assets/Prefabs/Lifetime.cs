using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float lifetime = 5f; // Lifetime in seconds
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime; // Decrease lifetime by the time elapsed since the last frame
        if (lifetime <= 0f)
        {
            Destroy(gameObject); // Destroy the game object when lifetime reaches zero
        }
    }
}
