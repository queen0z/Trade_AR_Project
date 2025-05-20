using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("프로그램 종료 시도!");

        // 에디터 모드에서 종료 대신 메시지 출력
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 실제 프로그램 종료
#endif
    }
}
