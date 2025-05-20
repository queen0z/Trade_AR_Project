using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    public GameObject container; // 이동할 3D 모델
    public Transform targetPosition; // 이동할 위치(Target Object)
    public float speed = 0.5f; // 이동 속도

    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove && container != null && targetPosition != null)
        {
            // Container를 targetPosition으로 이동
            container.transform.position = Vector3.MoveTowards(
                container.transform.position,
                targetPosition.position,
                speed * Time.deltaTime
            );

            // 이동 완료 체크
            if (Vector3.Distance(container.transform.position, targetPosition.position) < 0.01f)
            {
                shouldMove = false;
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true; // 이동 시작
    }
}
