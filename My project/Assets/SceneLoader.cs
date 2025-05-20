using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 씬 이름을 입력할 수 있는 Public 변수
    public string sceneName; // 일반적인 씬 이름
    public string arSceneName; // AR 씬 이름

    public void LoadScene()
    {
        // 일반 씬 로드하기
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set in the Inspector.");
        }
    }

    public void LoadARScene()
    {
        // AR 씬 로드하기
        if (!string.IsNullOrEmpty(arSceneName))
        {
            SceneManager.LoadScene(arSceneName);
        }
        else
        {
            Debug.LogError("AR Scene name is not set in the Inspector.");
        }
    }
}
