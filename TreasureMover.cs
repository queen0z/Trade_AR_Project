using UnityEngine;

public class TreasureMover : MonoBehaviour
{
    public GameObject treasureBox; // 이동할 보물상자
    public Transform targetPosition; // 목표 위치
    public float moveSpeed = 2.0f; // 이동 속도

    private bool isMoving = false; // 이동 여부

    void Update()
    {
        if (isMoving && treasureBox != null && targetPosition != null)
        {
            // 보물상자를 목표 위치로 이동
            treasureBox.transform.position = Vector3.MoveTowards(
                treasureBox.transform.position,
                targetPosition.position,
                moveSpeed * Time.deltaTime
            );

            // 보물상자가 목표 위치에 도달했는지 확인
            if (Vector3.Distance(treasureBox.transform.position, targetPosition.position) < 0.01f)
            {
                isMoving = false; // 이동 멈춤
                Debug.Log("보물상자 이동 완료!");
            }
        }
    }

    // 이동 시작 함수
    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("보물상자 이동 시작!");
    }
}
