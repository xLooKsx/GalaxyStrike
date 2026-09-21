using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelCoroutine());
    }

    IEnumerator ReloadLevelCoroutine()
    {
        yield return new WaitForSeconds(1);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
