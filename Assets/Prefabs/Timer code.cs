using NUnit.Framework.Constraints;
using UnityEngine;

public class Timercode : MonoBehaviour
{
    public float timeRemaining = 3;
    public GameObject coin; // Reference to the coin GameObject
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime; // Decrease the remaining time by the time elapsed since the last frame
        if (timeRemaining <= 0)
        {
            Debug.Log("Its a coin!"); // Log a message when the timer reaches zero
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0); // Generate a random position within a specified range
            Instantiate(coin, pos, Quaternion.identity); // Instantiate the coin GameObject at the position of the current GameObject
            timeRemaining = 3; // Reset the timer to 3 seconds

        }

    }
}
