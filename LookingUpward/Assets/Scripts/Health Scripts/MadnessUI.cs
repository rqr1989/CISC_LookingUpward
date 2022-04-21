using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessUI : MonoBehaviour
{
    [SerializeField] private HealthSystem playerMadness;
    [SerializeField] private Image totalMadnessBar;
    [SerializeField] private Image currentMadnesshBar;

    // Start is called before the first frame update
    void Start()
    {
        totalMadnessBar.fillAmount = playerMadness.currentMadness / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentMadnesshBar.fillAmount = playerMadness.currentMadness / 10;
    }
}
