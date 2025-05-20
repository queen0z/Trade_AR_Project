using UnityEngine;

public class MultiObjectTransport : MonoBehaviour
{
    public GameObject ship; // 배 오브젝트
    public GameObject treasureBox; // 보물상자 오브젝트
    public GameObject container; // 컨테이너 오브젝트
    public Transform startDock; // 출발 위치
    public Transform endDock; // 도착 위치
    public float moveSpeed = 0.5f; // 이동 속도

    private bool isMoving = false; // 이동 여부

    void Update()
    {
        if (isMoving)
        {
            // 배 이동
            ship.transform.position = Vector3.MoveTowards(
                ship.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // 보물상자 이동
            treasureBox.transform.position = Vector3.MoveTowards(
                treasureBox.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // 컨테이너 이동
            container.transform.position = Vector3.MoveTowards(
                container.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // 모든 오브젝트가 목표 위치에 도달했는지 확인
            if (Vector3.Distance(ship.transform.position, endDock.position) < 0.01f &&
                Vector3.Distance(treasureBox.transform.position, endDock.position) < 0.01f &&
                Vector3.Distance(container.transform.position, endDock.position) < 0.01f)
            {
                isMoving = false; // 이동 종료
                Debug.Log("모든 오브젝트가 도착했습니다!");
            }
        }
    }

    // 이동 시작 함수
    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("이동 시작!");
    }
}
