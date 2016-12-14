using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class LevelController : MonoBehaviour
{
    public void LoadLevel1()
    {
        Application.LoadLevel("LevelOneThePit");
    }
    public void LoadLevel2()
    {
        Application.LoadLevel("LevelTwoTheTower");
    }
    public void LoadLevel3()
    {
        Application.LoadLevel("LevelThreeFinalBoss");
    }
    public void LoadMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    public void restartLevel()
    {
        //PlayerController restartScene;

        //restartScene = (PlayerController)FindObjectOfType(typeof(PlayerController));

		switch (GentlemansSingleton.GetSceneNum ())
        {
            case (int)1:
                Application.LoadLevel("LevelOneThePit");
                break;
            case (int)2:
                Application.LoadLevel("LevelTwoTheTower");
                break;
            case (int)3:
                Application.LoadLevel("LevelThreeFinalBoss");
                break;
        }
    }
}
