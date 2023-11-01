using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    const int m_boardSize = 15;
    const float m_sideLeng = 0.3925f;


    //������ ������¸� �����ϴ� �迭���� & �������鿡 �ο��� �࿭ ��ȣ�� ������ ����
    public int[,] m_CurrentBoardState { get; set; }

    int m_row, m_col;
    bool m_isOrder = true;
    StoneManager m_stoneManager;

    Ray ray;
    RaycastHit hit;

    // �ٵ����� ������¸� ������ �ٵ��� �迭�� �����ϴ� �Լ� 
    // -1: �������, 0: �鵹, 1: �浹
    void BoardArrStateInit()
    {
        Debug.Log("¥��");
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                m_CurrentBoardState[i, j] = -1;
            }
        }
    }

    //������ �ٵϵ� ������Ʈ(�ٵ��� ���� �� �ٵϵ�)�� ��İ��� ���ϴ� �Լ�
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
                    // CurrentBoardState�� 
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