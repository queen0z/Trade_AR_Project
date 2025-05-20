using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    public GameObject container; // �̵��� 3D ��
    public Transform targetPosition; // �̵��� ��ġ(Target Object)
    public float speed = 0.5f; // �̵� �ӵ�

    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove && container != null && targetPosition != null)
        {
            // Container�� targetPosition���� �̵�
            container.transform.position = Vector3.MoveTowards(
                container.transform.position,
                targetPosition.position,
                speed * Time.deltaTime
            );

            // �̵� �Ϸ� üũ
            if (Vector3.Distance(container.transform.position, targetPosition.position) < 0.01f)
            {
                shouldMove = false;
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true; // �̵� ����
    }
}
