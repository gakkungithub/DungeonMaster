using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : SingletonMonoBehaviour<SceneTransitionManager>
{
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
