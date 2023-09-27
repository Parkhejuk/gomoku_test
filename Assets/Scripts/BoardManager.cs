using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject m_gridVertexPrefab;
    public GameObject m_goBoard;
    
    //����, ���� ũ�� & ������ ����
    int m_vertical = 13;
    int m_horizontal = 13;
    int m_GridVertexMax;

    //������ & ��ǥ�̵� & �� ĭ ���� ����
    const double m_cXPos = -2.735f; 
    const double m_cYPos = 2.73f;
    double m_xPos = m_cXPos;
    double m_yPos = m_cYPos;
    double m_sideLeng = 0.455f;

    int i, j;

    void GridVertexMax() // �������� ���� ���ϴ� �Լ�
    {
        m_GridVertexMax = m_vertical * m_horizontal;
    }
    void CreateGridVertex(int count) // �������� ��ǥ���� ���� ������Ʈ �����ϴ� �Լ�
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
        GridVertexMax(); // ��ǥ�� ���� ���ϴ� �Լ�


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
