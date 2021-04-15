using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject laser;
    [SerializeField] AudioSource quote;
    [SerializeField] GameObject dynamite;
    [SerializeField] GameObject lasers;
    bool lookPlayer = false;

    public void InvokeScene()
    {
        Invoke("Scene", 1f);
    }

    void Scene()
    {
        SceneManager.LoadScene("Scene8");
    }

    public void Lasers()
    {
        quote.Play();
        lasers.SetActive(true);
        dynamite.SetActive(true);
    }

    void Update()
    {
        if (lookPlayer)
        {
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 15 * Time.deltaTime, 0);

            Vector3 oldEuler = transform.eulerAngles;

            transform.LookAt(target.transform);

            if (Mathf.Abs(oldEuler.y - transform.eulerAngles.y) < 15)
            {
                laser.SetActive(true);
                lookPlayer = true;
            }

            transform.eulerAngles = oldEuler;
        }
    }
}
