using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public GameObject m_gridVertexPrefab;
    public GameObject m_instantedStone;
    public GameObject m_blackStonePrefabs;
    public GameObject m_whiteStonePrefabs;
    public GameObject m_AlphaStonePool;


    //isOrder 1(true)�� ����, 1(true)�� �浹, 0(false)�� �鵹,
    //�ٸ� Script���� isOrder�� ����ϱ� ���� get
    bool m_isOrder = true;
    static bool m_isBlackStone = true;
    static bool m_isWhiteStone = false;

    //Ray
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Stone") // Ư�� ��ġ ���� ������Ʈ �ߺ� ���� ����
                {
                    Debug.Log("�� �ڸ����� �ٵϵ��� �ֽ��ϴ�.");
                }
                else if (hit.collider.gameObject.tag != "Stone")
                {
                    //isOrder�� true(1)�� �� �浹, false(0)�� �� �鵹
                    var obj = Instantiate(m_isOrder ? m_blackStonePrefabs : m_whiteStonePrefabs, hit.collider.bounds.center, Quaternion.identity);
                    obj.transform.SetParent(m_instantedStone.transform);
                    m_isOrder = m_isOrder ? m_isWhiteStone : m_isBlackStone;

                }
            }
        }
    }
}
