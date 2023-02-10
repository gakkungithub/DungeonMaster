using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStagePos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //侵入してきたgameObjectのlayerがPlayerなら
        /*ここで、Tagではなくlayerにした理由は、Tag == Playerにしてしまうと、他のTag == Playerでこの挙動をしてほしく
        ないObjがこの挙動をしてしまうからである。*/
        if(collision.gameObject.layer == 3)
        {
            //同じsampleSceneを読み込めばもう一度mapgeneratorが読みだされて次のマップが生成される。
            DungeonScoreManager.Instance.AddDungeonScore(5);
            DungeonMemoryManager.Instance.SetPlayerParameter(collision.gameObject.GetComponent<CharacterParameterBase>());
            DungeonHierarchyCounter.Instance.DungeonHierarchyCountUp();
            //DungeonSoundManager.Instance.PlaySE(DungeonSoundManager.SETType.NextStagePosSE);
            SceneTransitionManager.Instance.SceneLoad("SampleScene");
        }
    }
}
