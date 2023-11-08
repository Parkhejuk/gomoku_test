using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 물림수 관련 클래스
public class StoneBacksies : MonoBehaviour
{
    CurrentBoardStateInit m_currentBoardStateInit;

    //전수의 GameObject 데이터를 저장할 변수
    GameObject m_obj1;
    GameObject m_obj2;

    //전수의 행렬값를 저장할 변수;
    public int[] m_stoneBacksies1 { get; set; }
    public int[] m_stoneBacksies2 { get; set; }

    //물림수를 저장하는 함수 (최대 1회까지);
    public void SetBacksies1(int row, int col, GameObject obj)
    {
        if (m_stoneBacksies1[0] == 0)
        {
            m_stoneBacksies1[0] = row;
            m_stoneBacksies1[1] = col;
        }
        else
        {
            SetBacksies2();
            m_stoneBacksies1[0] = row;
            m_stoneBacksies1[1] = col;
        }
        m_obj1 = obj;
    }
    void SetBacksies2()
    {
        m_stoneBacksies2[0] = m_stoneBacksies1[0];
        m_stoneBacksies2[1] = m_stoneBacksies1[1];
        m_obj2 = m_obj1;
    }

    //Backsies 버튼을 누르면 실행되는 함수
    public void BacksiesButtonDown()
    {
        if (m_obj1 != null && m_obj2 != null) //최초 검은색 하나 있을 때 삭제 불가능. 게임 룰 구현 후 이부분 다시 확인
        {
            m_currentBoardStateInit.m_CurrentBoardState[m_stoneBacksies1[0], m_stoneBacksies1[1]] = -1;
            m_currentBoardStateInit.m_CurrentBoardState[m_stoneBacksies2[0], m_stoneBacksies2[1]] = -1;

            Destroy(m_obj1);
            Destroy(m_obj2);

            Debug.Log("수를 물렸습니다.");
        }
        else
        {
            Debug.Log("수를 물릴 수 없습니다.");
        }
    }

    //일단 만들어둔 Debug함수 적절하게 복붙해서 쓸것
    void GetBacksiesData()
    {
        Debug.Log("1: " + m_stoneBacksies1[0] + ", " + m_stoneBacksies1[1]);
        Debug.Log("2: " + m_stoneBacksies2[0] + ", " + m_stoneBacksies2[1]);
        Debug.Log("1: " + m_obj1.transform.position);
        Debug.Log("2" + m_obj2.transform.position);
    }

    void Start()
    {
        m_currentBoardStateInit = FindAnyObjectByType<CurrentBoardStateInit>();

        m_stoneBacksies1 = new int[2];
        m_stoneBacksies2 = new int[2];
    }
}
