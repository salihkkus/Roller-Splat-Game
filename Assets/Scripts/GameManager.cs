using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    public float groundNumber;
    private int currentlevel;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        currentlevel = SceneManager.GetActiveScene().buildIndex;
    }

   
    void Update()
    {
        groundNumber = grounds.Length;
    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentlevel + 1);
    }
}
