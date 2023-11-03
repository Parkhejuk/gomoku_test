using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    [SerializeField] GameObject m_gridVertexPrefab;
    [SerializeField] GameObject m_instantedStone;
    [SerializeField] GameObject m_blackStonePrefabs;
    [SerializeField] GameObject m_whiteStonePrefabs;
    [SerializeField] GameObject m_AlphaStonePool;

    //isOrder 1(true)로 시작, 1(true)은 흑돌, 0(false)은 백돌
    //다른 Script에서 isOrder를 사용하기 위한 프로퍼티
    bool m_isOrder = true;
    static bool m_isBlackStone = true;
    static bool m_isWhiteStone = false;

    public bool m_IsOrder { get { return m_isOrder; } set { m_isOrder = value; } }

    public RaycastHit hit;
    RuleManager m_ruleManager;

    private void Start()
    {
        m_ruleManager = FindObjectOfType<RuleManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (RayCastUtil.RaycastFromMouse(out hit))
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

                    m_ruleManager.UpdateBoardState();

                }
            }
        }
    }
}
