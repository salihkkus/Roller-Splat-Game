using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public GameObject[] _grounds;
    public float groundNumber;
    private int _currentLevel;
    void Start()
    {
        _grounds = GameObject.FindGameObjectsWithTag("Ground");
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    
    void Update()
    {
        groundNumber = _grounds.Length;
    }

    public void LevelUpdate() {
        SceneManager.LoadScene(_currentLevel + 1);
    }
}