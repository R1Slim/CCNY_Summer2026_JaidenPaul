using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class Timercode : MonoBehaviour
{
    public float timeRemaining = 3f;
    public float gameTime = 60f;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying the score
    public TextMeshProUGUI gameTimeText; // Reference to the TextMeshProUGUI component for displaying the game time
    public GameObject CoinPrefab; // Reference to the coin GameObject
    public GameObject myPlayer; // Reference to the player GameObject
    public PlayerWASD playerScript; // Reference to the PlayerWASD script attached to the player GameObject
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
            Instantiate(CoinPrefab, pos, Quaternion.identity); // Instantiate the coin GameObject at the random postioion 
            timeRemaining = 3; // Reset the timer to 3 seconds
            return; // Exit the Update method to prevent further execution until the next frame

        }
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime; // Decrease the game time by the time elapsed since the last frame
            if (gameTime <= 0)
            {
                gameTime = 0; // Ensure that the game time does not go below zero
                Debug.Log("Game Over!"); // Log a game over message
                myPlayer.SetActive(false); // Deactivate the player GameObject to end the game

            }
            gameTimeText.text = gameTime.ToString("F1"); // Update the game time text display with the current game time formatted to one decimal place
            scoreText.text = gameTime.ToString(); // Update the score text display with the current game time (you may want to change this to display the actual score instead)
        }
        

    }
}
