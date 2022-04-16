using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessUI : MonoBehaviour
{
    public GameObject madness3;
    public GameObject madness2;
    public GameObject madness1;
    
 
    private PlayerHealth playerHealth;
    void Awake()
    {
        madness3.SetActive(true);
        madness2.SetActive(true);
        madness1.SetActive(true);

       

    }


    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator PlayerMadnessToFull()
    {
        yield return new WaitForSeconds(.1f);
       madness3.SetActive(true);
        madness2.SetActive(true);
        madness1.SetActive(true);
    }

    public IEnumerator PlayerMadnessToTwo()
    {

        yield return new WaitForSeconds(.1f);
        //then makes the health 3 image inactive
        madness3.SetActive(false);
    }

    public IEnumerator PlayerMadnessToOne()
    {
        madness3.SetActive(false);

        yield return new WaitForSeconds(.1f);

        madness2.SetActive(false);

    }

    public IEnumerator PlayerMadnessToZero()
    {
        madness3.SetActive(false);

        madness2.SetActive(false);

        yield return new WaitForSeconds(.1f);

        madness1.SetActive(false);
    }

}