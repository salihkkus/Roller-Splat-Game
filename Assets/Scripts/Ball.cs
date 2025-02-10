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
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody atanmazsa hata alırsın, bunu ekledim.
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

            currentPos = new Vector2(secondPos.x - firstPos.x, secondPos.y - firstPos.y);
            currentPos = currentPos.normalized; // Normalize işlemi doğru yapıldı.

            if (currentPos.y < -0.5f && Mathf.Abs(currentPos.x) < 0.5f) // Back
            {
                rb.velocity = Vector3.back * speed;
            }
            else if (currentPos.y > 0.5f && Mathf.Abs(currentPos.x) < 0.5f) // Forward
            {
                rb.velocity = Vector3.forward * speed;
            }
            else if (currentPos.x < -0.5f && Mathf.Abs(currentPos.y) < 0.5f) // Left
            {
                rb.velocity = Vector3.left * speed;
            }
            else if (currentPos.x > 0.5f && Mathf.Abs(currentPos.y) < 0.5f) // Right
            {
                rb.velocity = Vector3.right * speed;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) // Doğru ve hızlı tag kontrolü için CompareTag kullan.
        {
            MeshRenderer meshRenderer = other.gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material.color = Color.red;
            }
        }
    }

    private void Constraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;        
    }
}
