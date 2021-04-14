using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] AudioSource successSound;
    [SerializeField] GameObject root;

    [SerializeField] GameObject firstObj;
    [SerializeField] GameObject secondObj;

    [SerializeField] GameObject thirdObj;
    [SerializeField] GameObject fourthObj;

    [SerializeField] float angleOffset;

    [SerializeField] GameObject capsule;

    public void SpawnCapsule()
    {
        capsule.GetComponent<Capsule>().Rise();
    }

    public void WatchFirst()
    {
        NotWatch(firstObj);
    }

    public void WatchSecond()
    {
        NotWatch(secondObj);
    }
    public void WatchThird()
    {
        NotWatch(thirdObj);
    }

    public void WatchFourth()
    {
        NotWatch(fourthObj);
    }

    public void BeginEncounter()
    {
        GetComponent<Animator>().Play("encounter");
        GetComponent<AudioSource>().Play();
    }

    public void SetRoot(float angle)
    {
        watchTarget = false;
        root.transform.eulerAngles = new Vector3(-90f, angle, 0);
    }

    public void WatchTarget()
    {
        watchTarget = true;
    }

    GameObject lookAt;

    public void NotWatch(GameObject obj)
    {
        watchTarget = false;
        lookAt = obj;
    }

    public void NotWatchNull()
    {
        watchTarget = false;
        lookAt = null;
    }

    public void SuccessSound()
    {
        successSound.Play();
        watchTarget = false;
    }

    bool watchTarget = false;
    private void Update()
    {
        if(watchTarget)
        {
            var targetRotation = Quaternion.LookRotation(target.transform.position - root.transform.position);

            targetRotation = Quaternion.Euler(-89.98f, targetRotation.eulerAngles.y - 45 + angleOffset, targetRotation.eulerAngles.z);

                root.transform.rotation = Quaternion.Slerp(root.transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
        else if(lookAt != null)
        {
            var targetRotation = Quaternion.LookRotation(lookAt.transform.position - root.transform.position);

            targetRotation = Quaternion.Euler(-89.98f, targetRotation.eulerAngles.y - 45 + angleOffset, targetRotation.eulerAngles.z);

            root.transform.rotation = Quaternion.Slerp(root.transform.rotation, targetRotation, 5 * Time.deltaTime);
        }
    }
}
