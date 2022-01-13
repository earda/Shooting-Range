using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject StartPanel;
    public GameObject NextLevelS;
    public GameObject Ammo;
    public Text LevelCount;
    public static int LeveLCount=0;
    public GameObject LevelObject;
 
    private void Start()
    {
        GameLevel(1);
        Ammo.SetActive(false);
        LevelObject.SetActive(false);
        StartPanel.SetActive(true);
        NextLevelS.SetActive(false);
    }
    public void TapToPlay()
    {
        Ammo.SetActive(true);
        LevelObject.SetActive(true);
        StartPanel.SetActive(false);
        NextLevelS.SetActive(false);
    }
    public void FinishLevel()
    {
        Ammo.SetActive(false);
        LevelObject.SetActive(false);
        StartPanel.SetActive(false);
        NextLevelS.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnApplicationQuit()
    {
        LeveLCount = 0;
    }
    public void GameLevel(int level)
    {

        LeveLCount += level;
        LevelCount.text = ("LEVEL " + LeveLCount.ToString());
    }
}
