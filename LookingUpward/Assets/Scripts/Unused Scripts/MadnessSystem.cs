using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadnessSystem : MonoBehaviour
{
    [SerializeField] private float startingMadness;
    public float currentMadness { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        currentMadness = startingMadness;
    }

    // Update is called once per frame
    public void TakeMadnessDamage(float damageTaken)
    {
        currentMadness = Mathf.Clamp(currentMadness - damageTaken, 0, startingMadness);

        if (currentMadness > 0)
        {
            //player hurt
        }
        else
        {
            //player dead
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            TakeMadnessDamage(1);
    }
}