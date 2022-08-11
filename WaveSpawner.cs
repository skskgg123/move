using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //텍스트 사용

public class WaveSpawner : MonoBehaviour
{
    //적 오브젝트 프리팹
    public GameObject enemyPrefab;
    //시작 지점 
    public Transform start;
    //스폰 타이머 - 5초 간격
    public float spawnTimer = 5f;
    private float countdown = 2f;
    //wave 카운트
    private int waveCount = 0;
    //Text UI
    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //타이머
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            //실행문
         

            countdown = spawnTimer;
        }
        countdown -= Time.deltaTime;

        //text UI 연결
        //countdownText.text = countdown.ToString(); //countdown이 숫자형이라서 문자형으로 변환하기 위해 ToString
        //[1]소수점 두자리까지 끊어서 출력
        //[1-1]
        //countdownText.text = countdown.ToString("F2"); //원하는 소수점 자리수 맞춰서 Fn
        //[1-2]
        //countdownText.text = string.Format("{0:0.0}", countdown);
        //[2]소수점을 보이지 않게 출력 (int형으로 출력)
        countdownText.text = Mathf.Round(countdown).ToString();
    }

    //5초마다 wave 발생
    IEnumerator SpawnWave()
    {
        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }

    //시작점 위치에 enemy 1개를 생성
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, start.position, Quaternion.identity);
    }
}
