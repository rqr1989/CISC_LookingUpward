using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadnessCollectible : MonoBehaviour
{
    [SerializeField] private float madnessValue;
    [SerializeField] private AudioClip madnessPickUpSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(madnessPickUpSound);
            collision.GetComponent<HealthSystem>().AddHealth(madnessValue);
            gameObject.SetActive(false);
        }
    }

}
