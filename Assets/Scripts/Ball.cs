using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody rb; // Rigidbody component
    private GameManager gm; // Reference to the GameManager script
    public Image scoreBar; // UI score bar
    public float moveSpeed; // Movement speed of the ball
    private Vector2 firstPos; // First touch position
    private Vector2 secondPos; // Second touch position
    public Vector2 currentPos; // Current swipe direction
    public float currentGroundNumber; // Number of ground tiles the ball has touched

    void Start() {
        gm = GameObject.FindObjectOfType<GameManager>(); // Find the GameManager instance
    }
    
    void Update()
    {
        Swipe(); // Handle swipe input
        scoreBar.fillAmount = currentGroundNumber / gm.groundNumber; // Update score bar
        // if(scoreBar.fillAmount == 1) {
        //     gm.LevelUpdate(); // Uncomment if level progression is needed
        // } 
    }

    private void Swipe() {
        if(Input.GetMouseButtonDown(0)) {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // Store the first touch position
            Debug.Log(firstPos);
        }

        if(Input.GetMouseButtonUp(0)) {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // Store the second touch position

            currentPos = new Vector2(
                secondPos.x - firstPos.x,
                secondPos.y - firstPos.y
            );

            currentPos.Normalize(); // Normalize the swipe direction
        }

        // Determine the movement direction based on swipe
        if(currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f) {
            rb.velocity = Vector3.forward * moveSpeed; // Move forward
        }
        else if(currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f) {
            rb.velocity = Vector3.back * moveSpeed; // Move backward
        }
        else if(currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f) {
            rb.velocity = Vector3.right * moveSpeed; // Move right
        }
        else if(currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f) {
            rb.velocity = Vector3.left * moveSpeed; // Move left
        }
    }

    private void OnCollisionEnter(Collision other) {
        // Check if the ground tile has already been visited (red color)
        if(other.gameObject.GetComponent<MeshRenderer>().material.color != Color.red) {
            if(other.gameObject.tag == "Ground") {
                Constraints(); // Apply movement constraints
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red; // Change ground color to red
                currentGroundNumber++; // Increment ground counter
            }
        }
    }

    private void Constraints() {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation; // Restrict movement
    }
}
