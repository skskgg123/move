using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*float currentTime;
    public float createTime = 5;
    public GameObject createnemy;*/

    //이동할 목표지점의 오브젝트
    private Transform target;
    //이동속도
    public float speed = 2f;
    //WayPoint 인덱스
    private int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //target 설정
        wayPointIndex = 0;
        target = WayPoints.points[wayPointIndex];

        //이동하기
        //target.position = new Vector3(0, 2.5f, -45f);
    }

    // Update is called once per frame
    void Update()
    {
        //타켓까지 이동하기
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

        //도착 판정 - enemy와 target의 거리가 0.5이하이면 도착했다고 판정
        //타겟까지 이동이 완료되었으면 Debug.Log("첫번째 포인트까지 도착")
        /*if (Vector3.Distance(transform.position, targetposition) <= 0.5f)
            {
            Debug.Log("첫번째 포인트까지 도착");
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
   
    //다음 WayPoint 지점을 타겟으로 설정
    private void GetNextPoint()
    {
        //마지막 지점에 도착 판정
        //Debug.Log("종점 도착!!!!");
        if(wayPointIndex == WayPoints.points.Length - 1) //마지막 인덱스 번호는 배열의 길이 - 1
        {
            Debug.Log("종점 도착!!!!");
            Destroy(this.gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

}
