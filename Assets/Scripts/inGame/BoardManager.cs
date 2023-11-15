using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȭ�鿡 ��µ� �ٵ��� ������Ʈ ���� Ŭ����
public class BoardManager : MonoBehaviour
{
    [SerializeField] GameObject m_gridVertexPrefab; //��ǥ������ ���� GameObject Prefabs, �Ʒ� Board Coordinate ������Ʈ�� ��ƾ� ��
    [SerializeField] GameObject m_boardCoordinate; // GoBoard ������Ʈ�� ������ �ִ� Board Coordinate ������Ʈ
    GameObject m_gridVertexObj;

    //����, ���� ũ�� & ������ ����
    const int m_boardSize = 15;
    int m_GridVertexMax = m_boardSize * m_boardSize;

    const float m_cXPos = 0f;
    const float m_cYPos = 0f;
    //m_boardCoordinate�� ������ & ��ǥ�̵� & �� ĭ ���� ����

    float m_xPos = m_cXPos;
    float m_yPos = m_cYPos;

    const float m_sideLeng = 0.3925f;

    //�ٸ� ��ũ��Ʈ���� ������ ����� �� �ֵ��� ������Ƽ ����
    public int m_BoardSize { get { return m_boardSize; } }
    public float m_SideLeng { get { return m_sideLeng; } }

    void CreateGridVertex(int count) // �������� ��ǥ���� ���� ������Ʈ �����ϴ� �Լ�
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