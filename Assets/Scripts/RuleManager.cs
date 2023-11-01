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
    bool m_isOrder = true;
    StoneManager m_stoneManager;

    Ray ray;
    RaycastHit hit;

    // 바둑판의 현재상태를 저장할 바둑판 배열을 생성하는 함수 
    // -1: 비어있음, 0: 백돌, 1: 흑돌
    void BoardArrStateInit()
    {
        Debug.Log("짜잔");
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                m_CurrentBoardState[i, j] = -1;
            }
        }
    }

    //생성한 바둑돌 오브젝트(바둑판 위에 둔 바둑돌)의 행렬값을 구하는 함수
    public void GetMatrixNum(Vector3 StoneWorldPoint, int row, int col)
    {

        m_row = Mathf.RoundToInt(StoneWorldPoint.x / m_sideLeng);
        m_col = Mathf.RoundToInt(StoneWorldPoint.y / m_sideLeng);
    }
    private void Start()
    {
        m_CurrentBoardState = new int[m_boardSize, m_boardSize];
        BoardArrStateInit();
        m_stoneManager = GetComponent<StoneManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag != "Stone")
                {
                    // CurrentBoardState에 
                    GetMatrixNum(hit.point, m_row, m_col);
                    m_CurrentBoardState[m_row, m_col] = m_stoneManager.m_IsOrder ? 1 : 0;

                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            Debug.Log("Element " + i + ", " + j + ": " + m_CurrentBoardState[i, j]);
                        }
                    }

                }
            }
        }
    }
}