using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("���α׷� ���� �õ�!");

        // ������ ��忡�� ���� ��� �޽��� ���
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���� ���α׷� ����
#endif
    }
}
