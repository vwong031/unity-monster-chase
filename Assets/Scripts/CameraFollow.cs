using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player; 

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Called every frame if behavior is enabled
    // Called after all calculations in Update are finished
    void LateUpdate()
    {

        if (!player) {
          return;
        }
        
        // Current position of camera
        tempPos = transform.position;
        // Set the x position of player to the x position of the temp position (aka camera)
        tempPos.x = player.position.x;

        if (tempPos.x < minX) {
          tempPos.x = minX;
        }

        if (tempPos.x > maxX) {
          tempPos.x = maxX;
        }

        // Assign value back to current position of camera
        // Camera will have its own y & z position, but have x of player
        transform.position = tempPos;
    }

}
