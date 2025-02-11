using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;

    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 currentPos;
    public float speed;
    public float currentgroundnumber;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Constraints(); // Başlangıçta Constraints ayarlarını uygula
    }

    void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPos = (secondPos - firstPos).normalized; 

            Vector3 moveDirection = Vector3.zero;

            if (currentPos.y < -0.5f && Mathf.Abs(currentPos.x) < 0.5f) // Back
            {
                moveDirection = Vector3.back;
            }
            else if (currentPos.y > 0.5f && Mathf.Abs(currentPos.x) < 0.5f) // Forward
            {
                moveDirection = Vector3.forward;
            }
            else if (currentPos.x < -0.5f && Mathf.Abs(currentPos.y) < 0.5f) // Left
            {
                moveDirection = Vector3.left;
            }
            else if (currentPos.x > 0.5f && Mathf.Abs(currentPos.y) < 0.5f) // Right
            {
                moveDirection = Vector3.right;
            }

            // Hareket vektörünü düz bir çizgide tut
            rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            MeshRenderer meshRenderer = other.gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material.color = Color.red;
                currentgroundnumber++;
            }
        }
    }

    private void Constraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | 
                         RigidbodyConstraints.FreezeRotationX | 
                         RigidbodyConstraints.FreezeRotationZ;
    }
}
