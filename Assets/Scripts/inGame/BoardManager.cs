using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 화면에 출력될 바둑판 오브젝트 관리 클래스
public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject m_gridVertexPrefab; //좌표값만을 담은 GameObject Prefabs, 아래 Board Coordinate 오브젝트에 담아야 함
    [SerializeField] GameObject m_boardCoordinate; // GoBoard 오브젝트의 하위에 있는 Board Coordinate 오브젝트
    GameObject m_gridVertexObj;

    //가로, 세로 크기 & 교차점 개수
    const int m_boardSize = 15;
    int m_GridVertexMax = m_boardSize * m_boardSize;

    const float m_cXPos = 0f;
    const float m_cYPos = 0f;
    //m_boardCoordinate의 기준점 & 좌표이동 & 한 칸 변의 길이

    float m_xPos = m_cXPos;
    float m_yPos = m_cYPos;

    const float m_sideLeng = 0.3925f;

    //다른 스크립트에서 변수를 사용할 수 있도록 프로퍼티 생성
    public int m_BoardSize { get { return m_boardSize; } }
    public float m_SideLeng { get { return m_sideLeng; } }

    void CreateGridVertex(int count) // 교차점의 좌표값을 담을 오브젝트 생성하는 함수
    {
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                m_gridVertexObj = Instantiate(m_gridVertexPrefab);
                m_gridVertexObj.transform.SetParent(m_boardCoordinate.transform);
                m_gridVertexObj.transform.position = new Vector3(m_xPos, m_yPos, 0);

                m_xPos += m_sideLeng;
            }
            m_xPos = m_cXPos;
            m_yPos += m_sideLeng;
        }
    }

    void Start()
    {
        CreateGridVertex(m_GridVertexMax);
    }
}