using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTargetScript : MonoBehaviour
{
    /** Door to slide after target is hit */
    public Transform slidingDoor2;

    void Update()
    {
        Transform[] ts = GetComponentsInChildren<Transform>();
        foreach(Transform t in ts)
        {
            if (t.gameObject.layer == 12)
            {
                StartCoroutine(MoveSlidingDoor2());
                this.enabled = false;
            }
        }
    }

    private IEnumerator MoveSlidingDoor2()
    {
        while (slidingDoor2.localPosition.z > -17f)
        {
            slidingDoor2.localPosition = new Vector3(slidingDoor2.localPosition.x, slidingDoor2.localPosition.y, slidingDoor2.localPosition.z - .01f);
            yield return new WaitForSeconds(.005f);
        }
    }
}
