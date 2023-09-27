using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject m_gridVertexPrefab;
    public GameObject m_goBoard;
    
    //가로, 세로 크기 & 교차점 개수
    int m_vertical = 13;
    int m_horizontal = 13;
    int m_GridVertexMax;

    //기준점 & 좌표이동 & 한 칸 변의 길이
    const double m_cXPos = -2.735f; 
    const double m_cYPos = 2.73f;
    double m_xPos = m_cXPos;
    double m_yPos = m_cYPos;
    double m_sideLeng = 0.455f;

    int i, j;

    void GridVertexMax() // 교차점의 개수 구하는 함수
    {
        m_GridVertexMax = m_vertical * m_horizontal;
    }
    void CreateGridVertex(int count) // 교차점의 좌표값을 담을 오브젝트 생성하는 함수
    {
        for(i = 0; i<m_horizontal; i++)
        {
            for (j = 0; j < m_vertical; j++)
            {
                var obj = Instantiate(m_gridVertexPrefab);
                obj.transform.SetParent(m_goBoard.transform);
                obj.transform.position = new Vector3((float)m_xPos,(float)m_yPos,0);
                m_xPos += m_sideLeng;
            }
            m_xPos = m_cXPos;
            m_yPos -= m_sideLeng;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GridVertexMax(); // 좌표의 개수 구하는 함수


        //for (i = 0; i < m_horizontal; i++)
        //{
        //    for (j = 0; j < m_vertical; j++)
        //    {

        //    }
        //}
        CreateGridVertex(m_GridVertexMax);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
