using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealthManager : Singleton<TargetHealthManager>
{
    public float currentHealth;

    public float CurrentHealth{ get { return currentHealth; } set { currentHealth = value; } }

    public Slider slider;
    private void Awake()
    {
        slider = transform.root.GetComponentInChildren<Slider>();
    }
    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Gun.Instance.hedef.SetActive(false);
            //Destroy(gameObject);
            Debug.Log("Hedef tahtasý yok olcak");

        } 
    }
    public void SetHealth()
    {
        CurrentHealth -= Gun.Instance.gunType.BulletDamage;
        slider.value = currentHealth;
        
    }

    private void OnEnable()
    {
        EventManager.OnTargetHit.AddListener(SetHealth);
        EventManager.OnTargetHit.AddListener(CheckHealth);
    }

    private void OnDisable()
    {
        EventManager.OnTargetHit.RemoveListener(SetHealth);
        EventManager.OnTargetHit.RemoveListener(CheckHealth);
    }
}
