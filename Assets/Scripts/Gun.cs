using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 10f;
    public float fireRate = 1.6f;

    public int maxAmmo = 25;
    public int ammoCount;

    /** Set this to the Camera within the scene or prefab */
    public Camera fpsCam;
    private Animator m_animator;
    /** Position to fire raycast from, set in prefab. */
    public GameObject firingPos;

    /** Set these to other prefabs */
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bloodImpactEffect;

    private float nextTimeToFire = 0f;

    /** Crosshair to disable if in hard mode (determined by playerprefs). Set in prefab. */
    [SerializeField] private GameObject easyModeCrosshair;
    public AudioSource gunShotSound;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("Difficulty", 0) != 0)
        {
            easyModeCrosshair.SetActive(false);
        }
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
            m_animator.SetTrigger("Shoot");
            ammoCount--;
            muzzleFlash.Play();
            RaycastHit hit;
            gunShotSound.Play();
            //FindObjectOfType<AudioManager>().Play("Gunshot sound");
            //Change "this" to "fpsCam" for testing.
            if (Physics.Raycast(firingPos.transform.position, firingPos.transform.forward, out hit, range))
            {
                GameObject impact;
                EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    impact = Instantiate(bloodImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                } else
                {
                    impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                impact.transform.SetParent(hit.transform);
                Destroy(impact, 2f);
            }
        }
    }
}
