using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TargetHealthManager target=other.GetComponent<TargetHealthManager>();
        if (target)
        {
            EventManager.OnTargetHit.Invoke();
            Debug.Log("Ýsasbet etti");
        }
    }
}
