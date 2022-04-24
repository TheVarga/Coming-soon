using System.Collections;
using UnityEngine;

public class ShootingProjectile : MonoBehaviour
{
    public AudioSource gunSound;
    public GameObject projectile;
    public Transform shootingPoint;
    [SerializeField] float TimeBetweenShots;
    public bool canShoot = true;
    int crLimit = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            if (canShoot)
            {
                Shoot();
                gunSound.Play();
                canShoot = false;
                ShootingDelay();
            }          
        }
    }

    void Shoot() {
        if (!canShoot) return;

        GameObject si = Instantiate(projectile, shootingPoint);
        
        si.transform.parent = null;

    }

    private void ShootingDelay()
    {
        if (crLimit == 0)
        {
            StartCoroutine(Delay());
        }

    }
    IEnumerator Delay()
    {
        crLimit++;
        yield return new WaitForSeconds(TimeBetweenShots);
        canShoot = true;
        crLimit--;
    }

}
