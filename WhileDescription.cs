using UnityEngine;

public class WhileDescription : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�ȳ��ϼ��並 3�� �ݺ� ���
        /* for ��
        for(int i = 0; i <3; i++)
        {
            Debug.Log("�ȳ��ϼ���");
        }
        */

        int i = 0; //�ʱ�� 
        while(i < 3)    //���ǽ� ���̸� ���๮�� �ݺ��ؼ� ����, �����̸� while�� ���� 
        {
            //�ݺ� ���๮
            Debug.Log("�ȳ��ϼ���");

            //������ (�ݺ� ���๮ ���ʿ��� �����ص� ���� ���� but ���� �޶��� �� ����)
            i++;
        }
    }
}
