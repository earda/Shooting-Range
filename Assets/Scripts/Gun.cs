using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Gun : Singleton<Gun>
{
    public List<GameObject> bullet;
    public List<GameObject> bulletbaretta;
    public int count = 0;
    public int countbaretta = 0;
    public Transform muzzle;
    public List<GunType> scriptables;
    public GunType gunType;
    public int bulletCountM4A1 = 30;
    public int bulletCountBarette = 10;
    public int bulletsRemainingM4A1;
    public int bulletsRemainingBarette;
    public RaycastHit raycastHit;
    public GameObject m4a1;
    public GameObject baretta;
    public GameObject hedef; 
    int i = 0;
    public bool onFireBaretta=true;
    private float timer;
    public bool onFire=true;
    public int hitRate;
    public int targetCount = 0;
    public IEnumerator ResetBullet(int index)
    {
        yield return new WaitForSeconds(.7f);
        bullet[index].SetActive(false);
        bullet[index].transform.localPosition = Vector3.zero;
        bullet[index].GetComponent<Rigidbody>().velocity= Vector3.zero;
        bullet[index].GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
    }
    public IEnumerator ResetBulletBaretta(int index)
    {
        yield return new WaitForSeconds(.7f);
        bulletbaretta[index].SetActive(false);
        bulletbaretta[index].transform.localPosition = Vector3.zero;
        bulletbaretta[index].GetComponent<Rigidbody>().velocity= Vector3.zero;
        bulletbaretta[index].GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
    }
    private void Start()
    {
        
        bulletsRemainingM4A1 = 30;
        bulletsRemainingBarette = 10;
        GameManager.Instance.Magazine(bulletsRemainingM4A1, bulletCountM4A1);
        m4a1.SetActive(true);
        baretta.SetActive(false);
    }
  private void Timer()
    {
        if (!onFireBaretta)
        {
            timer += Time.deltaTime;
            if (timer>=gunType.WeaponFireDelay)
            {
                onFireBaretta = true;
                timer = 0;
            }
        }
    }
    private void GetInput()
    {
        switch (gunType.fireType)
        {
            case  FireType.automatic:
                if (Input.GetKey(KeyCode.D))
                {
                    if (onFire)
                    {
                        onFire = false;
                        StartCoroutine(FireRiffle());
                    }
                    //else if (!onFire) StopAllCoroutines();
                }
                break;
            case FireType.manuel:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (onFireBaretta)
                    {
                        onFireBaretta = false;
                        FireBaretta();
                    }
                }
                break;
            default:
                break;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            onFire = true;
            StopCoroutine("FireRiffle");
        }
    }
    IEnumerator FireRiffle()
    {
        if (bulletsRemainingM4A1>=0)
        {
            gunType.FireGun(this, Vector3.forward, muzzle.transform);
            yield return new WaitForSeconds(gunType.WeaponFireDelay);
            if (!onFire)
            {
                StartCoroutine(FireRiffle());
            }
           
        }
        else
        {
            Debug.Log("Ammo is empty. ");
        }
    }

    private void FireBaretta()
    {
        if (bulletsRemainingBarette >= 0)
        {
            gunType.FireGun(this, Vector3.forward, muzzle.transform); 
        }
        else
        {
            Debug.Log("Ammo is empty. ");
        }
    }
  
    void Update()
    {
         
        GetInput();
        Timer();
        if (Input.GetKeyDown(KeyCode.W))
        {
            gunType = scriptables[i++];
          
            i = i == 0 ? 0 : i == 2 ? 0 : 1;

            if (gunType == scriptables[0])
            {
                GameManager.Instance.Magazine(bulletsRemainingM4A1, bulletCountM4A1);
                m4a1.SetActive(true);
                baretta.SetActive(false);
            }
            else
            {
                GameManager.Instance.Magazine(bulletsRemainingBarette, bulletCountBarette);
                m4a1.SetActive(false);
                baretta.SetActive(true);
            }
        }

        if (gunType == scriptables[0] && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Ammo is loading...");
            StartCoroutine(M4A1LoadingAmmo());
        }
        if (gunType == scriptables[1] && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Ammo is loading...");
            StartCoroutine(BarettaLoadingAmmo());
        }
        Debug.Log(gunType.name);

       if (hedef.active==false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hedef.SetActive(true);
                TargetHealthManager.Instance.currentHealth = 100;
                TargetHealthManager.Instance.slider.value = 100;
                targetCount++;
                if (targetCount >= 5)
                {
                    UIManager.Instance.FinishLevel();
                }
            }
        }
    }
    IEnumerator M4A1LoadingAmmo()
    {
        yield return new WaitForSeconds(5f);
        bulletsRemainingM4A1 = bulletCountM4A1;
        
        Debug.Log("Ammo is full. ");
       
    }
    IEnumerator BarettaLoadingAmmo()
    {
        yield return new WaitForSeconds(4f);
        bulletsRemainingBarette = bulletCountBarette;

        Debug.Log("Ammo is full. ");
    }

    
}
