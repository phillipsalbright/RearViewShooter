using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script for a target/sliding door combo that was originally only going to be in the tutorial,
 * but has since been generalized.
 */
public class TutorialTargetScript : MonoBehaviour
{
    /** Door to slide after target is hit */
    public Transform slidingDoor;
    public float zpos;

    void Update()
    {
        Transform[] ts = GetComponentsInChildren<Transform>();
        foreach(Transform t in ts)
        {
            if (t.gameObject.layer == 12)
            {
                StartCoroutine(MoveSlidingDoor());
                this.enabled = false;
            }
        }
    }

    private IEnumerator MoveSlidingDoor()
    {
        while (slidingDoor.localPosition.z > zpos)
        {
            slidingDoor.localPosition = new Vector3(slidingDoor.localPosition.x, slidingDoor.localPosition.y, slidingDoor.localPosition.z - .01f);
            yield return new WaitForSeconds(.0002f);
        }
    }
}
