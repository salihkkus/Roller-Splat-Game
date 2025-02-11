using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds; // Stores all ground objects in the scene
    public float groundNumber; // Total number of ground objects
    private int currentLevel; // Stores the current scene's build index

    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground"); // Finds all objects tagged as "Ground"
        currentLevel = SceneManager.GetActiveScene().buildIndex; // Gets the current scene's build index
    }

    void Update()
    {
        groundNumber = grounds.Length; // Updates the total number of ground objects
    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevel + 1); // Loads the next scene in the build index
    }
}
