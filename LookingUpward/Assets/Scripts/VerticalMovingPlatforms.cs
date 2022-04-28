using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatforms : MonoBehaviour
{
    [SerializeField] private Transform topedge;
    [SerializeField] private Transform bottomedge;

    [Header("Platform")]
    [SerializeField] private Transform platform;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingUp;
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
        if (movingUp)//if platform moving up
        {
            if (platform.position.y >= bottomedge.position.y)
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
            if (platform.position.y <= topedge.position.y)
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
        platform.position = new Vector3(platform.position.x, platform.position.y + Time.deltaTime * _direction * speed,
             platform.position.z);
    }

    private void DirectionChange() //change direction of platform
    {
       
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingUp = !movingUp;
        }

    }
}
