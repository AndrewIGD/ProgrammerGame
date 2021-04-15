using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject vfx;
    [SerializeField] GameObject[] grenades;
    [SerializeField] GameObject fire;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Computer")
        {
            GameObject vfxClone = Instantiate(vfx);
            vfxClone.transform.position = transform.position;
            vfxClone.SetActive(true);

            bool ok = false;

            foreach(GameObject grenade in grenades)
            {
                if (grenade != null && grenade != gameObject)
                    ok = true;
            }


            if (ok == false)
            {
                fire.SetActive(true);
                collision.gameObject.GetComponent<Boss>().InvokeScene();
            }

            Destroy(gameObject);
        }
    }
}
