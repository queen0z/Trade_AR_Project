using UnityEngine;

public class MultiObjectTransport : MonoBehaviour
{
    public GameObject ship; // �� ������Ʈ
    public GameObject treasureBox; // �������� ������Ʈ
    public GameObject container; // �����̳� ������Ʈ
    public Transform startDock; // ��� ��ġ
    public Transform endDock; // ���� ��ġ
    public float moveSpeed = 0.5f; // �̵� �ӵ�

    private bool isMoving = false; // �̵� ����

    void Update()
    {
        if (isMoving)
        {
            // �� �̵�
            ship.transform.position = Vector3.MoveTowards(
                ship.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // �������� �̵�
            treasureBox.transform.position = Vector3.MoveTowards(
                treasureBox.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // �����̳� �̵�
            container.transform.position = Vector3.MoveTowards(
                container.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // ��� ������Ʈ�� ��ǥ ��ġ�� �����ߴ��� Ȯ��
            if (Vector3.Distance(ship.transform.position, endDock.position) < 0.01f &&
                Vector3.Distance(treasureBox.transform.position, endDock.position) < 0.01f &&
                Vector3.Distance(container.transform.position, endDock.position) < 0.01f)
            {
                isMoving = false; // �̵� ����
                Debug.Log("��� ������Ʈ�� �����߽��ϴ�!");
            }
        }
    }

    // �̵� ���� �Լ�
    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("�̵� ����!");
    }
}
