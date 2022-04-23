using UnityEngine;

public class ShootingProjectile : MonoBehaviour
{
    public AudioSource gunSound;

    public GameObject projectile;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
            gunSound.Play();
        }
    }

    void Shoot() {
        if (!canShoot) return;

        GameObject si = Instantiate(projectile, shootingPoint);
        si.transform.parent = null;

    }
}
