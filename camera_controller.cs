using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // Offset from the player
    public float followSpeed = 10f;
    public float lookSpeed = 10f;

    private void FixedUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = player.position + player.transform.TransformDirection(offset);
        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Calculate the desired rotation to look at the player
        Quaternion desiredRotation = Quaternion.LookRotation(player.position - transform.position);
        // Smoothly rotate the camera to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, lookSpeed * Time.deltaTime);
    }
}
/*
public class camera_controller : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 Offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerForward = (playerRB.velocity + player.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position, player.position + player.transform.TransformVector(Offset) + playerForward * (-5f), speed * Time.deltaTime);
        transform.LookAt(player);
    }
}
*/