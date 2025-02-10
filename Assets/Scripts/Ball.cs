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
        
    }

    
    void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
       if(Input.GetMouseButtonDown(0))
       {
         firstPos = new Vector2(Input.MousePosition.x , Input.MousePosition.x);
       }

        if(Input.GetMouseButtonUp(0))
       {
         secondPos = new Vector2(Input.MousePosition.x , Input.MousePosition.x);
       }

       currentPos = new Vector2(secondPos.x - firstPos.x , secondPos.y - firstPos.y);

       currentPos.Normalize();

       if(currentPos.y < 0 && currentPos.x < 0.5f && currentPos.x > 0.5f ) //back
       {
          rb.velocity = Vector3.back * speed;
       }
       else if(currentPos.y > 0  && currentPos.x < 0.5f && currentPos.x > 0.5f) //forward
       {
        rb.velocity = Vector3.forward * speed;
       }
       else if(currentPos.x < 0 && currentPos.y < 0.5f && currentPos.y > 0.5f) // left
       {
        rb.velocity = Vector3.left * speed;
       }
       else if(currentPos.x > 0 && currentPos.y < 0.5f && currentPos.y > 0.5f) // right
       {
        rb.velocity = Vector3.right * speed;
       }

    }
    
      private void OnCollisionEnter(Collision other)
      {
        if(other.gameObject.tag == "Ground")
        {
         other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
      }

      private void Constraints()
      {
        rb.constraints = RigidbodyConstraints.FreezePositionY | rb.constraints = RigidbodyConstraints.FreezeRotation;        
      }

}
