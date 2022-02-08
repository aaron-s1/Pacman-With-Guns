using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    // public float testing;
    [SerializeField] GameObject bulletFlash;
    [SerializeField] GameObject casingPrefab;
    [SerializeField] GameObject barrel;
    [SerializeField] float shotPower = 100f;

    Rigidbody rigid;
    Animator anim;
    ObjectPooler BulletPooler;
    Transform casingExitLocation;

    bool canFire;


    void Start() {
        BulletPooler = GetComponent<ObjectPooler>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    // FireGun(false) is called from Game Manager when game is won
    public void FireGun(bool willFire = true, float delayBeforeStartFiring = 0f, float fireRate = 0.1f) {
        canFire = willFire;

        if (willFire) 
            InvokeRepeating("PewPew", delayBeforeStartFiring, fireRate);        
        
        else {
            willFire = false;
            CancelInvoke();
            GetComponent<LookAtTarget>().enabled = false;
            StartCoroutine("TossGunThenAddGravity");
        }
    }

    public void PewPew() {
        if (canFire)
            anim.SetTrigger("Fire");

        else if (anim.enabled)
            anim.enabled = false;
    }



    void Shoot() {
        GameObject bullet = BulletPooler.GetPooledObject("Bullet");        
        
        if (bullet != null) {
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.transform.position = barrel.transform.position;
            bullet.transform.rotation = barrel.transform.rotation;
            bullet?.SetActive(true);
            bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * shotPower);

            barrel.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play(true);        
        }
        
    }


    IEnumerator TossGunThenAddGravity() {
        rigid.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
        yield return new WaitForSeconds(0.15f);
        rigid.useGravity = true;
    }

    void CasingRelease() {
        // holdover method; empty on purpose
    }
}


// GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(); 
//   if (bullet != null) {
//     bullet.transform.position = turret.transform.position;
//     bullet.transform.rotation = turret.transform.rotation;
//     bullet.SetActive(true);
//   }


    // GameObject casing;
    // casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
    // casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
    // casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);

    //  GameObject bullet;
    //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
    // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    // Destroy(tempFlash, 0.5f);
    //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
