using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //�ؽ�Ʈ ���

public class WaveSpawner : MonoBehaviour
{
    //�� ������Ʈ ������
    public GameObject enemyPrefab;
    //���� ���� 
    public Transform start;
    //���� Ÿ�̸� - 5�� ����
    public float spawnTimer = 5f;
    private float countdown = 2f;
    //wave ī��Ʈ
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
        //Ÿ�̸�
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            //���๮
         

            countdown = spawnTimer;
        }
        countdown -= Time.deltaTime;

        //text UI ����
        //countdownText.text = countdown.ToString(); //countdown�� �������̶� ���������� ��ȯ�ϱ� ���� ToString
        //[1]�Ҽ��� ���ڸ����� ��� ���
        //[1-1]
        //countdownText.text = countdown.ToString("F2"); //���ϴ� �Ҽ��� �ڸ��� ���缭 Fn
        //[1-2]
        //countdownText.text = string.Format("{0:0.0}", countdown);
        //[2]�Ҽ����� ������ �ʰ� ��� (int������ ���)
        countdownText.text = Mathf.Round(countdown).ToString();
    }

    //5�ʸ��� wave �߻�
    IEnumerator SpawnWave()
    {
        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }

    //������ ��ġ�� enemy 1���� ����
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, start.position, Quaternion.identity);
    }
}
