using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*float currentTime;
    public float createTime = 5;
    public GameObject createnemy;*/

    //�̵��� ��ǥ������ ������Ʈ
    private Transform target;
    //�̵��ӵ�
    public float speed = 2f;
    //WayPoint �ε���
    private int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //target ����
        wayPointIndex = 0;
        target = WayPoints.points[wayPointIndex];

        //�̵��ϱ�
        //target.position = new Vector3(0, 2.5f, -45f);
    }

    // Update is called once per frame
    void Update()
    {
        //Ÿ�ϱ��� �̵��ϱ�
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

        //���� ���� - enemy�� target�� �Ÿ��� 0.5�����̸� �����ߴٰ� ����
        //Ÿ�ٱ��� �̵��� �Ϸ�Ǿ����� Debug.Log("ù��° ����Ʈ���� ����")
        /*if (Vector3.Distance(transform.position, targetposition) <= 0.5f)
            {
            Debug.Log("ù��° ����Ʈ���� ����");
            }*/
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= 0.5f)
        {
            GetNextPoint();
        }

        /*currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            GameObject enemy = Instantiate(createnemy);
            enemy.transform.position = transform.position;
            currentTime = 0;
        }*/
    }
   
    //���� WayPoint ������ Ÿ������ ����
    private void GetNextPoint()
    {
        //������ ������ ���� ����
        //Debug.Log("���� ����!!!!");
        if(wayPointIndex == WayPoints.points.Length - 1) //������ �ε��� ��ȣ�� �迭�� ���� - 1
        {
            Debug.Log("���� ����!!!!");
            Destroy(this.gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

}
