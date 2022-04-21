using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
    public GameObject healthShell3;
    public GameObject healthShell2;
    public GameObject healthShell1;


     private PlayerHealth playerHealth;
    void Awake()
    {
        healthShell3.SetActive(true);
        healthShell2.SetActive(true);
        healthShell1.SetActive(true);

    }


    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator PlayerHealthToFull()
    {
        yield return new WaitForSeconds(.1f);
        healthShell3.SetActive(true);
        healthShell2.SetActive(true);
        healthShell1.SetActive(true);
    }

   public IEnumerator PlayerHealthToTwo()
    {
      
        yield return new WaitForSeconds(.1f);
        //then makes the health 3 image inactive
        healthShell3.SetActive(false);
    }

   public IEnumerator PlayerHealthToOne()
    {
        healthShell3.SetActive(false);

        yield return new WaitForSeconds(.1f);

        healthShell2.SetActive(false);

    }

  public  IEnumerator PlayerHealthToZero()
    {
        healthShell3.SetActive(false);

        healthShell2.SetActive(false);

        yield return new WaitForSeconds(.1f);

        healthShell1.SetActive(false);
    }

}