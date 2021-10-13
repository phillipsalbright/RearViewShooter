using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimator : MonoBehaviour
{
    float rotationPerTick = 1.2f;
    Vector3 heightPerTick = new Vector3(0, .001f, 0);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateY());
        StartCoroutine(Up());
    }

    /**
     * Rotates the pickup and makes it go up and down. Values can be changed to determine the speed of this.
     */
    IEnumerator RotateY()
    {
        while (true)
        {
            yield return new WaitForSeconds(.02f);
            transform.Rotate(0, rotationPerTick, 0);
            //transform.Rotate(Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z).eulerAngles + rotationPerTick);
        }
    }

    /**
     * Translates up then calls Down().
     */
    IEnumerator Up()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(.02f);
            transform.position += heightPerTick;
        }
        StartCoroutine(Down());
    }

    /**
     * Translates down then calls Up().
     */
    IEnumerator Down()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(.02f);
            transform.position -= heightPerTick;
        }
        StartCoroutine(Up());
    }
}
