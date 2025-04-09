using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private float speed = 50;
    private float smoothSpeed = 0.125f; 
    private Vector3 desiredPosition;


    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        desiredPosition = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, transform.position + desiredPosition, smoothSpeed);

    }



}
