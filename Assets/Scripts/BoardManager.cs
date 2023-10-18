using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject m_gridVertexPrefab; //��ǥ������ ���� GameObject Prefabs, �Ʒ� Board Coordinate ������Ʈ�� ��ƾ� ��
    public GameObject m_boardCoordinate; // GoBoard ������Ʈ�� ������ �ִ� Board Coordinate ������Ʈ
    GameObject m_gridVertexObj;

    //����, ���� ũ�� & ������ ����
    int m_vertical = 15;
    int m_horizontal = 15;

    int m_GridVertexMax;

    //m_boardCoordinate�� ������ & ��ǥ�̵� & �� ĭ ���� ����
    const double m_cXPos = -2.75f; 
    const double m_cYPos = 2.75f;

    double m_xPos = m_cXPos;
    double m_yPos = m_cYPos;

    double m_sideLeng = 0.3925f;

    //������ �����¿� ������ǥ & ���� ũ��
    Vector3 m_boardUp;
    Vector3 m_boardDown;
    Vector3 m_boardLeft;
    Vector3 m_boardRight;

    // �׳� i, j
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
                m_gridVertexObj = Instantiate(m_gridVertexPrefab);
                m_gridVertexObj.transform.SetParent(m_boardCoordinate.transform);
                m_gridVertexObj.transform.position = new Vector3((float)m_xPos, (float)m_yPos, 0);

                m_xPos += m_sideLeng;
            }
            m_xPos = m_cXPos;
            m_yPos -= m_sideLeng;
        }
    }

    //public Vector3 SettoPoint(Vector3 m_mousePos)
    //{
    //    return 
    //}

    void Start()
    {

        GridVertexMax();
        CreateGridVertex(m_GridVertexMax);
    }
}
