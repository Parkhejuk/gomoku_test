using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public GameObject m_stoneManager;
    public GameObject m_blackStonePrefabs;
    public GameObject m_whiteStonePrefabs;

    BoardManager m_gridVertex;

    //isOrder 1로 시작
    //1은 흑돌, 0은 백돌
    bool m_isOrder = true;
    bool m_blackStone = true;
    bool m_whiteStone = false;

    //int[,] m_boardCoordinate;

    // Start is called before the first frame update
    void Start()
    {
        m_gridVertex = GetComponent<BoardManager>();
        //for (i = 0; i < m_horizontal; i++)
        //{
        //    for (j = 0; j < m_vertical; j++)
        //    {
        //        m_boardCoordinate[i, j] = -1;
        //    }
        //}
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {            
            if (m_isOrder) //isOrder가 1일 때 흑돌, 0일 때 백돌
            {
                var obj = Instantiate(m_blackStonePrefabs);
                obj.transform.SetParent(m_stoneManager.transform);
                obj.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                m_isOrder = m_whiteStone;
            }
            else
            {
                var obj = Instantiate(m_whiteStonePrefabs);
                obj.transform.SetParent(m_stoneManager.transform);
                obj.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                m_isOrder = m_blackStone;
            }
            
        }
    }
}
