using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextLevelScript3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene("LevelThreeFinalBoss", LoadSceneMode.Single);
        }
    }
}