using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDemo : MonoBehaviour
{
    public float speed;                             // ĳ���� ������ ���ǵ�
    public CharacterController CharacterController; // ĳ���� ��Ʈ�ѷ�
    public Vector3 movePoint;                       // �̵� ��ġ ����
    public Camera mainCamera;                       // ���� ī�޶�
    public Vector3 cameraOffset;                    // ī�޶� ���(����)��
    

    
    void Start()
    {
        speed = 4.0f;
        mainCamera = Camera.main;
        CharacterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        // ��Ŭ�� �̺�Ʈ�� ���Դٸ�
        if (Input.GetMouseButtonUp(0))
        {
            // ī�޶󿡼� �������� ���.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // Scence ���� ī�޶󿡼� ������ ������ ������ Ȯ���ϱ�
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            // �������� ������ �¾Ҵٸ�
            if (Physics.Raycast(ray, out RaycastHit raycastHit)) 
                // RaycastHit �޼��� ���ÿ� ��ȯ�޴� �浹 ����
            {
                // ���� ��ġ�� �������� ����
                movePoint = raycastHit.point;
                Debug.Log("movePoint : " + movePoint.ToString());
                Debug.Log("���� ��ü : " + raycastHit.transform.name);

            }
        }

        // ���������� �Ÿ��� 0.1f ���� �ִٸ�
        if (Vector3.Distance(transform.position, movePoint) > 0.1f)
        {
            // �̵�
            Move();
        }

        // �� ������Ʈ �޼ҵ尡 ����� ������ ī�޶��� ��ġ�� ������Ʈ�� ��ġ + ī�޶� ���(����)�� ��ġ�� �ٲ۴�.

        mainCamera.transform.position = transform.position + cameraOffset;

    }

    void Move()
    {
        // thisUpdatePoint �� �̹� ������Ʈ (������) ���� �̵��� ���θ� ��� ������.
        // �̵��� ����(�̵��� �� - ���� ��ġ) ���ϱ� �ӵ��� �ؼ� �̵��� ��ġ���� ����Ѵ�.

        Vector3 thisUpdatePoint = (movePoint - transform.position).normalized * speed;
        // characterController �� ĳ���� �̵��� ����ϴ� ������Ʈ��.
        // simpleMove �� �ڵ����� �߷��� ����ؼ� �̵������ִ� �޼ҵ��.
        // ������ �̵��� ����Ʈ�� �������ָ� �ȴ�.
        CharacterController.SimpleMove(thisUpdatePoint);
    }

}
