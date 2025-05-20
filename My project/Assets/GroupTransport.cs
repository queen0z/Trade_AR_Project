using UnityEngine;

public class GroupTransport : MonoBehaviour
{
    public Transform transportGroup; // 배, 보물상자, 물류가 포함된 그룹
    public Transform startDock; // 출발 위치
    public Transform endDock; // 도착 위치
    public float moveSpeed = 0.5f; // 이동 속도

    private bool isMoving = false; // 이동 여부

    void Update()
    {
        if (isMoving)
        {
            // TransportGroup 이동
            transportGroup.position = Vector3.MoveTowards(
                transportGroup.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // 도착 위치에 도달했는지 확인
            if (Vector3.Distance(transportGroup.position, endDock.position) < 0.01f)
            {
                isMoving = false; // 이동 종료
                Debug.Log("운송 완료!");
            }
        }
    }

    // 운송 시작
    public void StartTransport()
    {
        if (transportGroup == null || startDock == null || endDock == null)
        {
            Debug.LogError("TransportGroup, StartDock, 또는 EndDock이 설정되지 않았습니다.");
            return;
        }

        // 시작 위치로 이동
        transportGroup.position = startDock.position;
        isMoving = true;
        Debug.Log("운송 시작!");
    }
}