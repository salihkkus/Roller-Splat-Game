using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    public float groundNumber;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        Debug.Log("Parça" + grounds.Length);
    }

   
    void Update()
    {
        
    }
}
