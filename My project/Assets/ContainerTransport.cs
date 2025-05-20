using UnityEngine;

public class ContainerTransport : MonoBehaviour
{
    public Transform ship; // �� ������Ʈ
    public Transform startDock; // ��� ��ġ
    public Transform endDock; // ���� ��ġ
    public Transform container; // �����̳� ������Ʈ
    public float shipSpeed = 2.0f; // �� �̵� �ӵ�
    public float containerDropSpeed = 1.0f; // �����̳� �ϰ� �ӵ�

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            // �踦 �̵���Ŵ
            ship.position = Vector3.MoveTowards(ship.position, endDock.position, shipSpeed * Time.deltaTime);

            // �谡 �������� �����ϸ� �����̳ʸ� ����
            if (Vector3.Distance(ship.position, endDock.position) < 0.1f)
            {
                container.position = Vector3.MoveTowards(container.position, endDock.position, containerDropSpeed * Time.deltaTime);

                // �����̳ʰ� ������ �������� �̵� ����
                if (Vector3.Distance(container.position, endDock.position) < 0.1f)
                {
                    isMoving = false;
                }
            }
        }
    }

    public void StartTransport()
    {
        // �踦 ��� ��ġ�� �����ϰ� �̵� ����
        ship.position = startDock.position;
        isMoving = true;
    }
}
