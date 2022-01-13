using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public enum State
{
    start,
    finish
}
public class GameManager : Singleton<GameManager>
{
    public Text magazineSize; 
    private void Start()
    {
       //magazineSize.text = "0 / 0" ;
    }
   
    
    public void Magazine(int ammo, int magazineSizeForGun)
    {
        magazineSize.text = ammo +" / "+ magazineSizeForGun;
    }
   
}
