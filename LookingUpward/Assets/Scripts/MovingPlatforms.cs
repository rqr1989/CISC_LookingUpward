using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    [SerializeField] private Transform rightedge;
    [SerializeField] private Transform leftedge;

    [Header("Platform")]
    [SerializeField] private Transform platform;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [Header("Idle Time")]
    [SerializeField] private float idleDuration;
    private float idleTimer;
    private void Awake()
    {
        initScale = platform.localScale;
    }

    //Adapt for vertical moving platform
    void Update()
    {
        if (movingLeft)
        {
            if (platform.position.x >= leftedge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //change direction
                DirectionChange();
            }

        }
        else
           if (platform.position.x <= rightedge.position.x)
        {
            MoveInDirection(1);
        }
        else
            //change direction
            DirectionChange();
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        //makes enemy move in direction
        platform.position = new Vector3(platform.position.x + Time.deltaTime * _direction * speed, platform.position.y, 
             platform.position.z);
    }

    private void DirectionChange() //change direction of platform
    {

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }

    }
}
