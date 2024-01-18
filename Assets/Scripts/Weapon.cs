using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour

{

    [SerializeField] float Range = 100f;
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;
    [SerializeField] float Damage = 33f;
    [SerializeField] float coolDownTimer = 0.5f;
    [SerializeField] Ammo ammo;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;


    bool canShoot = true;


    private void OnEnable()
    {
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }

        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammo.GetAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if(ammo.GetAmmoAmount(ammoType) > 0)
        {
            Raycast();
            playMuzzleFlash();
            ammo.ReduceAmmo(ammoType);
        }
        
        yield return new WaitForSeconds(coolDownTimer);
        canShoot = true;
    }

  

    private void Raycast()
    {
        RaycastHit thingWeHit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thingWeHit, Range))
        {
            EnemyHealth target = thingWeHit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(Damage);
        }

        else { return; }
        CreateHitVFX(thingWeHit);
    }

    private void CreateHitVFX(RaycastHit thingWeHit)
    {
       GameObject Impact = Instantiate(hitVFX, thingWeHit.point,Quaternion.identity);
        Destroy(Impact,0.1f);



    }

    private void playMuzzleFlash()
    {
        muzzleFlash.Play();

    }
}
