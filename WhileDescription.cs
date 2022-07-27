using UnityEngine;

public class WhileDescription : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //안녕하세요를 3번 반복 출력
        /* for 문
        for(int i = 0; i <3; i++)
        {
            Debug.Log("안녕하세요");
        }
        */

        int i = 0; //초기식 
        while(i < 3)    //조건식 참이면 실행문을 반복해서 실행, 거짓이면 while문 종료 
        {
            //반복 실행문
            Debug.Log("안녕하세요");

            //증감식 (반복 실행문 위쪽에서 실행해도 실행 가능 but 값이 달라질 수 있음)
            i++;
        }
    }
}
