using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // �� �̸��� �Է��� �� �ִ� Public ����
    public string sceneName; // �Ϲ����� �� �̸�
    public string arSceneName; // AR �� �̸�

    public void LoadScene()
    {
        // �Ϲ� �� �ε��ϱ�
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
        // AR �� �ε��ϱ�
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
