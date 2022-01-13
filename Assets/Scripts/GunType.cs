using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FireType {automatic,manuel}
public abstract class GunType : ScriptableObject
{
    public abstract void FireGun(Gun gun, Vector3 direction, Transform transform);
    public FireType fireType;
    public float WeaponFireDelay;
    public float BulletDamage;
}
