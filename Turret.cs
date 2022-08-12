using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //가장 가까운 적
    private GameObject target;

    //터렛의 공격 범위
    public float attackRange = 15f;

    //타겟 검색 타이머
    public float timerSearch = 0.5f;
    private float countdown = 0f;

    //회전을 관리하는 오브젝트
    public Transform pratToRotate;

    //x터렛의 회전 속도
    public float turnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //0.5초마다 SearchTarget 메서드 호출
        //InvokeRepeating("SearchTarget", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //가장 가까운 적을 찾는다 - 0.5초마다 한번씩 찾는다
        if (countdown <= 0f)
        {
            //실행문
            SearchTarget();

            countdown = timerSearch;
        }
        countdown -= Time.deltaTime;

        //InvokeRepeating("SearchTarget", 0f, 5f);

        if (target == null)
            return;
       
            //타겟의 움직임에 따라 터렛 헤드가 타겟 방향으로 회전한다
            Vector3 dir = target.transform.position - this.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(pratToRotate.rotation, lookRotation, Time.deltaTime  * turnSpeed).eulerAngles;
            pratToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    //가장 가까운 적을 찾는다 
    private void SearchTarget()
    {
        //[1]모든 Enemy들의 정보를 가져온다 - GameObject.FindGameObjectsWithTag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //[2]정보를 이용해서 모든 Enemy중에 가장 가까운 거리를 찾는다(최소값)
        float minDistance = float.MaxValue;
        GameObject nearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            //터렛과 enemy와의 거리를 구한다
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            //최소 거리와 비교하여 최소거리 보다 작으면 새로운 거리를 최소거리로 저장한다
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

    //공격 범위 확인
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;                               //기즈모 색 변경
        Gizmos.DrawWireSphere(transform.position, attackRange); //자신의 위치에서 공격범위만큼 설정
        

    }

}
