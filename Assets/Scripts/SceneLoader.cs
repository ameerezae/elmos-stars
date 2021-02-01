using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadOpSceneGame()
    {
        SceneManager.LoadScene("opScene");
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }
    
}
