using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //���� ����� ��
    private GameObject target;

    //�ͷ��� ���� ����
    public float attackRange = 15f;

    //Ÿ�� �˻� Ÿ�̸�
    public float timerSearch = 0.5f;
    private float countdown = 0f;

    //ȸ���� �����ϴ� ������Ʈ
    public Transform pratToRotate;

    //x�ͷ��� ȸ�� �ӵ�
    public float turnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //0.5�ʸ��� SearchTarget �޼��� ȣ��
        //InvokeRepeating("SearchTarget", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //���� ����� ���� ã�´� - 0.5�ʸ��� �ѹ��� ã�´�
        if (countdown <= 0f)
        {
            //���๮
            SearchTarget();

            countdown = timerSearch;
        }
        countdown -= Time.deltaTime;

        //InvokeRepeating("SearchTarget", 0f, 5f);

        if (target == null)
            return;
       
            //Ÿ���� �����ӿ� ���� �ͷ� ��尡 Ÿ�� �������� ȸ���Ѵ�
            Vector3 dir = target.transform.position - this.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(pratToRotate.rotation, lookRotation, Time.deltaTime  * turnSpeed).eulerAngles;
            pratToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    //���� ����� ���� ã�´� 
    private void SearchTarget()
    {
        //[1]��� Enemy���� ������ �����´� - GameObject.FindGameObjectsWithTag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //[2]������ �̿��ؼ� ��� Enemy�߿� ���� ����� �Ÿ��� ã�´�(�ּҰ�)
        float minDistance = float.MaxValue;
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            //�ͷ��� enemy���� �Ÿ��� ���Ѵ�
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            //�ּ� �Ÿ��� ���Ͽ� �ּҰŸ� ���� ������ ���ο� �Ÿ��� �ּҰŸ��� �����Ѵ�
            if(distance < minDistance)
            {
                minDistance = distance;
                nearEnemy = enemy;
            }

        }

        if(nearEnemy != null && minDistance <= attackRange)
        {
            target = nearEnemy;
        }
        else
        {
            target = null;
        }
    }

    //���� ���� Ȯ��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;                               //����� �� ����
        Gizmos.DrawWireSphere(transform.position, attackRange); //�ڽ��� ��ġ���� ���ݹ�����ŭ ����
        

    }

}
