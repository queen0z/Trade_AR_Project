using UnityEngine;

public class GroupTransport : MonoBehaviour
{
    public Transform transportGroup; // ��, ��������, ������ ���Ե� �׷�
    public Transform startDock; // ��� ��ġ
    public Transform endDock; // ���� ��ġ
    public float moveSpeed = 0.5f; // �̵� �ӵ�

    private bool isMoving = false; // �̵� ����

    void Update()
    {
        if (isMoving)
        {
            // TransportGroup �̵�
            transportGroup.position = Vector3.MoveTowards(
                transportGroup.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // ���� ��ġ�� �����ߴ��� Ȯ��
            if (Vector3.Distance(transportGroup.position, endDock.position) < 0.01f)
            {
                isMoving = false; // �̵� ����
                Debug.Log("��� �Ϸ�!");
            }
        }
    }

    // ��� ����
    public void StartTransport()
    {
        if (transportGroup == null || startDock == null || endDock == null)
        {
            Debug.LogError("TransportGroup, StartDock, �Ǵ� EndDock�� �������� �ʾҽ��ϴ�.");
            return;
        }

        // ���� ��ġ�� �̵�
        transportGroup.position = startDock.position;
        isMoving = true;
        Debug.Log("��� ����!");
    }
}