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


    //isOrder 1(true)로 시작, 1(true)은 흑돌, 0(false)은 백돌,
    //다른 Script에서 isOrder를 사용하기 위한 get
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
                if (hit.collider.gameObject.tag == "Stone") // 특정 위치 스톤 오브젝트 중복 생성 제한
                {
                    Debug.Log("이 자리에는 바둑돌이 있습니다.");
                }
                else if (hit.collider.gameObject.tag != "Stone")
                {
                    //isOrder가 true(1)일 때 흑돌, false(0)일 때 백돌
                    var obj = Instantiate(m_isOrder ? m_blackStonePrefabs : m_whiteStonePrefabs, hit.collider.bounds.center, Quaternion.identity);
                    obj.transform.SetParent(m_instantedStone.transform);
                    m_isOrder = m_isOrder ? m_isWhiteStone : m_isBlackStone;

                }
            }
        }
    }
}
