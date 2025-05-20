using UnityEngine;

public class ShipAndContainerTransport : MonoBehaviour
{
    public GameObject ship; // 배 오브젝트
    public GameObject container; // 컨테이너 오브젝트
    public Transform startDock; // 출발 위치
    public Transform endDock; // 도착 위치
    public Transform containerDropPosition; // 컨테이너가 내려질 위치
    public float moveSpeed = 0.5f; // 이동 속도

    private bool moveShip = false; // 배와 컨테이너 이동 플래그
    private bool dropContainer = false; // 컨테이너 분리 플래그

    void Update()
    {
        // 배와 컨테이너가 함께 이동
        if (moveShip)
        {
            ship.transform.position = Vector3.MoveTowards(
                ship.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // 배가 도착하면 이동 멈춤
            if (Vector3.Distance(ship.transform.position, endDock.position) < 0.01f)
            {
                moveShip = false;
                dropContainer = true; // 컨테이너 분리 시작
            }
        }

        // 컨테이너를 배에서 분리하고 바닥에 내려놓음
        if (dropContainer)
        {
            container.transform.position = Vector3.MoveTowards(
                container.transform.position,
                containerDropPosition.position,
                moveSpeed * Time.deltaTime
            );

            // 컨테이너가 내려놓아졌으면 이동 종료
            if (Vector3.Distance(container.transform.position, containerDropPosition.position) < 0.01f)
            {
                dropContainer = false; // 모든 동작 완료
            }
        }
    }

    // 배와 컨테이너 이동 시작
    public void StartTransport()
    {
        moveShip = true;
        // 컨테이너를 배의 자식으로 설정
        container.transform.SetParent(ship.transform);
    }
}
