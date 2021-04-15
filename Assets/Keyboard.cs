using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] AudioSource keyPress;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject[] keyboards;
    [SerializeField] AudioSource error;
    [SerializeField] Boss boss;

    int index = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Hand"))
        {
                keyPress.Play();

            index++;

                if (index == 20)
                {
                    gold.SetActive(false);
                    bool ok = false;
                    foreach(GameObject keyboard in keyboards)
                    {
                        if(keyboard.activeInHierarchy)
                        {
                        ok = true;
                        }
                    }
                    if(ok == false)
                    {
                        error.Play();
                        boss.Lasers();
                    }
                }
            
        }
    }
}
