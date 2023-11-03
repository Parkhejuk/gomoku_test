using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    const int m_boardSize = 15;
    const float m_sideLeng = 0.3925f;


    //보드의 현재상태를 저장하는 배열변수 & 교차점들에 부여한 행열 번호를 저장할 변수
    public int[,] m_CurrentBoardState { get; set; }

    int m_row, m_col;
    StoneManager m_stoneManager;

    // 바둑판의 현재상태를 저장할 바둑판 배열을 생성하는 함수 
    // -1: 비어있음, 0: 백돌, 1: 흑돌
    public void BoardStateArrInit()
    {
        m_CurrentBoardState = new int[m_boardSize, m_boardSize];
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                m_CurrentBoardState[i, j] = -1;
            }
        }
    }

    // 바둑판의 현재 상태를 Log에 띄우는 함수
    void GetCurrenBoardStateArr()
    {
        string s = null;
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                s += m_CurrentBoardState[j, 14 - i] + " ";
            }
            s += "\n";
        }
        Debug.Log(s);
    }

    //생성한 바둑돌 오브젝트(바둑판 위에 둔 바둑돌)의 행렬값을 구하는 함수
    void GetMatrixNum(Vector3 StoneWorldPoint)
    {
        m_row = Mathf.RoundToInt(StoneWorldPoint.x / m_sideLeng);
        m_col = Mathf.RoundToInt(StoneWorldPoint.y / m_sideLeng);
    }
    // m_CurrentBoardState 배열에 1, 0 을 넣는 함수
    public void UpdateBoardState()
    {
        GetMatrixNum(m_stoneManager.hit.point);
        m_CurrentBoardState[m_row, m_col] = m_stoneManager.m_IsOrder ? 0 : 1;

        GetCurrenBoardStateArr();
    }

    void Start()
    {
        m_stoneManager = FindObjectOfType<StoneManager>();
        BoardStateArrInit();

    }
}