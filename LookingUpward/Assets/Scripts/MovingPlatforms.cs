using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{


    public Vector3 endingPosition = Vector3.zero;
    public float speed = 0.7f; //platfrom movement speed

    private Vector3 startingPosition;
    private float trackPosition = 0; //Where along the track the platform is currently

    private int direction = 1; //direction platform is currently moving 


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; //sets starting point equal to platforms placement in scene
    }

    // Update is called once per frame
    void Update()
    {

        trackPosition += direction * speed * Time.deltaTime;

        float x = (endingPosition.x - startingPosition.x) * trackPosition + startingPosition.x;
        float y = (endingPosition.y - startingPosition.y) * trackPosition + startingPosition.y;
        transform.position = new Vector3(x, y, startingPosition.z);

        //if platform has reached the edge of the track in either direction
        if((direction ==1 && trackPosition >.9f) ||

                (direction == -1 && trackPosition <.1f))
                {
            //reverse the direction the platform is moving in
            direction *= -1;
        }
    }
}
