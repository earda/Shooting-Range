using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(menuName = "Silah Tipi / M4A1")]
public class M4A1 : GunType
{  
    public float speed = 5f; 
    public ForceMode mode;
     

    public override void FireGun(Gun gun, Vector3 direction, Transform bulletTransform)
    {
        Gun.Instance.hitRate = 60;

        if (Gun.Instance.count == Gun.Instance.bullet.Count)  
        {
            Gun.Instance.count = 0;
           
        }
         
        else if(Gun.Instance.count < Gun.Instance.bullet.Count)
        { 
            var bullet = Gun.Instance.bullet[Gun.Instance.count];
            bullet.SetActive(true);
            bullet.transform.rotation = bulletTransform.rotation;
            if (Random.RandomRange(1, 100) <= Gun.Instance.hitRate)
            { 
                bullet.GetComponent<Rigidbody>().AddForce((Gun.Instance.hedef.transform.position - new Vector3(0.053f, 1.159f, -32f)) * speed);
            }
            else
            {
                bullet.GetComponent<Rigidbody>().AddForce((Gun.Instance.hedef.transform.position - new Vector3(Random.Range(-2f, 3f), Random.Range(0f, 6f), -32f)) * speed);
            }
            GameManager.Instance.Magazine(Gun.Instance.bulletsRemainingM4A1, Gun.Instance.bulletCountM4A1);
            Gun.Instance.bulletsRemainingM4A1--;
            Gun.Instance.StartCoroutine(Gun.Instance.ResetBullet(Gun.Instance.count));
            Gun.Instance.count++;
        }
       
    }
}
