using UnityEngine;

public class ShipAndContainerTransport : MonoBehaviour
{
    public GameObject ship; // �� ������Ʈ
    public GameObject container; // �����̳� ������Ʈ
    public Transform startDock; // ��� ��ġ
    public Transform endDock; // ���� ��ġ
    public Transform containerDropPosition; // �����̳ʰ� ������ ��ġ
    public float moveSpeed = 0.5f; // �̵� �ӵ�

    private bool moveShip = false; // ��� �����̳� �̵� �÷���
    private bool dropContainer = false; // �����̳� �и� �÷���

    void Update()
    {
        // ��� �����̳ʰ� �Բ� �̵�
        if (moveShip)
        {
            ship.transform.position = Vector3.MoveTowards(
                ship.transform.position,
                endDock.position,
                moveSpeed * Time.deltaTime
            );

            // �谡 �����ϸ� �̵� ����
            if (Vector3.Distance(ship.transform.position, endDock.position) < 0.01f)
            {
                moveShip = false;
                dropContainer = true; // �����̳� �и� ����
            }
        }

        // �����̳ʸ� �迡�� �и��ϰ� �ٴڿ� ��������
        if (dropContainer)
        {
            container.transform.position = Vector3.MoveTowards(
                container.transform.position,
                containerDropPosition.position,
                moveSpeed * Time.deltaTime
            );

            // �����̳ʰ� �������������� �̵� ����
            if (Vector3.Distance(container.transform.position, containerDropPosition.position) < 0.01f)
            {
                dropContainer = false; // ��� ���� �Ϸ�
            }
        }
    }

    // ��� �����̳� �̵� ����
    public void StartTransport()
    {
        moveShip = true;
        // �����̳ʸ� ���� �ڽ����� ����
        container.transform.SetParent(ship.transform);
    }
}
