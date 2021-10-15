using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 10f;
    public float fireRate = 3f;

    public int maxAmmo = 25;
    public int ammoCount = 25;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    public AudioSource gunShotSound;

    private void Start()
    {
        ammoCount = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        /** Change to just "GetButton" for automatic */
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            muzzleFlash.Play();
            RaycastHit hit;
            gunShotSound.Play();
            //FindObjectOfType<AudioManager>().Play("Gunshot sound");
            //Change "this" to "fpsCam" for testing.
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
            {
                EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                impact.transform.SetParent(hit.transform);
                Destroy(impact, 2f);
            }
        }
    }
}
