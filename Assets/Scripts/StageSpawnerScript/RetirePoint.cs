using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class RetirePoint : MonoBehaviour
{
    [SerializeField]
    private GameObject TextModalPrefab;

    private int playerLayer = 0;

    private void Awake()
    {
        //TextModel用のPrefabを生成
        TextModalPrefab = Instantiate(TextModalPrefab);
        TextModalPrefab.SetActive(false);
        int layerNo = LayerMask.NameToLayer("Player");
        playerLayer = layerNo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == playerLayer)
        {
            TextModalPrefab.SetActive(true);
            var characters = FindObjectsOfType<CharacterBase>();
            foreach(var character in characters){
                //キャラクターの移動を不活性にする
                character.isActive = false;
            }
            var modal = TextModalPrefab.GetComponent<ModalBase>();

            modal.SetTwoButtonModal("RetirePoint", "do you want to retire?",
                () => {
                    SceneTransitionManager.Instance.SceneLoad("ResultScene");
                },
                () => { //NO
                    foreach(var character in characters)
                    {
                        //キャラクターの移動を活性化にする
                        character.isActive = true;
                    }
                    TextModalPrefab.SetActive(false);
                }
            );
        }
    }
}
