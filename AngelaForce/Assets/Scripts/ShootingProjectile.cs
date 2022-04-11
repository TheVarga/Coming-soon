using UnityEngine;

public class ShootingProjectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void Shoot() {
        if (!canShoot) return;

        GameObject si = Instantiate(projectile, shootingPoint);
        si.transform.parent = null;

    }
}
