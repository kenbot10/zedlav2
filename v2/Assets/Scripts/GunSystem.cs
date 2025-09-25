using UnityEngine;
using TMPro;
public class GunSystem : MonoBehaviour
{
    //gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, BulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    private void aweake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //settext
        text.SetText(bulletsLeft +" / "+ magazineSize);
    }
    private void MyInput()
    {
       if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
       else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            BulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("enemy"))
                rayHit.collider.GetComponent <agro>().TakeDamage(damage);
        }

        //ShakeCamera
        camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        BulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(BulletsShot > 0 && bulletsLeft >0)
        Invoke("Shoot", timeBetweenShots);
    }
    
    private void Resetshot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
