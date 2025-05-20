using UnityEngine;

public class TreasureMover : MonoBehaviour
{
    public GameObject treasureBox; // �̵��� ��������
    public Transform targetPosition; // ��ǥ ��ġ
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    private bool isMoving = false; // �̵� ����

    void Update()
    {
        if (isMoving && treasureBox != null && targetPosition != null)
        {
            // �������ڸ� ��ǥ ��ġ�� �̵�
            treasureBox.transform.position = Vector3.MoveTowards(
                treasureBox.transform.position,
                targetPosition.position,
                moveSpeed * Time.deltaTime
            );

            // �������ڰ� ��ǥ ��ġ�� �����ߴ��� Ȯ��
            if (Vector3.Distance(treasureBox.transform.position, targetPosition.position) < 0.01f)
            {
                isMoving = false; // �̵� ����
                Debug.Log("�������� �̵� �Ϸ�!");
            }
        }
    }

    // �̵� ���� �Լ�
    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("�������� �̵� ����!");
    }
}
