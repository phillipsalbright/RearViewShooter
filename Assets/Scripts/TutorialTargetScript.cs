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
    private int direction;

    private void Start()
    {
        if (slidingDoor.localPosition.z > zpos)
        {
            direction = -1;
        } else {
            direction = 1;
        }
    }

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
        if (direction > 0)
        {
            while (slidingDoor.localPosition.z < zpos)
            {
                slidingDoor.localPosition = new Vector3(slidingDoor.localPosition.x, slidingDoor.localPosition.y, slidingDoor.localPosition.z + direction * .03f);
                yield return new WaitForSeconds(.0001f);
            }
        } else
        {
            while (slidingDoor.localPosition.z > zpos)
            {
                slidingDoor.localPosition = new Vector3(slidingDoor.localPosition.x, slidingDoor.localPosition.y, slidingDoor.localPosition.z + direction * .03f);
                yield return new WaitForSeconds(.0001f);
            }
        }
    }
}
