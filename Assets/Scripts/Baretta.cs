using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Silah Tipi/Baretta")]
public class Baretta : GunType
{ 
    public float speed = 15f; 
    public ForceMode mode;
     

    public override void FireGun(Gun gun, Vector3 direction, Transform bulletTransform)
    {
        Gun.Instance.hitRate = 90;

        if (Gun.Instance.countbaretta == Gun.Instance.bulletbaretta.Count)
        {
            Gun.Instance.countbaretta = 0;

        }
        else if (Gun.Instance.count < Gun.Instance.bullet.Count)
        {
            var bullet = Gun.Instance.bulletbaretta[Gun.Instance.countbaretta];
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
            GameManager.Instance.Magazine(Gun.Instance.bulletsRemainingBarette, Gun.Instance.bulletCountBarette);
            Gun.Instance.bulletsRemainingBarette--;
            Gun.Instance.StartCoroutine(Gun.Instance.ResetBulletBaretta(Gun.Instance.countbaretta));
            Gun.Instance.countbaretta++;
        }
    }
 
}
