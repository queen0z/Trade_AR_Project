using UnityEngine;

public class ContainerTransport : MonoBehaviour
{
    public Transform ship; // 배 오브젝트
    public Transform startDock; // 출발 위치
    public Transform endDock; // 도착 위치
    public Transform container; // 컨테이너 오브젝트
    public float shipSpeed = 2.0f; // 배 이동 속도
    public float containerDropSpeed = 1.0f; // 컨테이너 하강 속도

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            // 배를 이동시킴
            ship.position = Vector3.MoveTowards(ship.position, endDock.position, shipSpeed * Time.deltaTime);

            // 배가 목적지에 도착하면 컨테이너를 내림
            if (Vector3.Distance(ship.position, endDock.position) < 0.1f)
            {
                container.position = Vector3.MoveTowards(container.position, endDock.position, containerDropSpeed * Time.deltaTime);

                // 컨테이너가 완전히 내려지면 이동 중지
                if (Vector3.Distance(container.position, endDock.position) < 0.1f)
                {
                    isMoving = false;
                }
            }
        }
    }

    public void StartTransport()
    {
        // 배를 출발 위치로 설정하고 이동 시작
        ship.position = startDock.position;
        isMoving = true;
    }
}
