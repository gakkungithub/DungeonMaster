using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterBase : CharacterBase
{

    private bool isChase = false;

    private int chaseDirection = 0;
    float playerDiff = 10f;
    //float enemyDiff = 10f;

    private bool isLeft = false, isRight = false, isUp = false, isDown = false;

    private int enemyActionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.isEnemy = true;

        this.enemyActionCount = GameTurnManager.playerActionCount;

        this.transform.position = MapGenerator.Instance.EnemyPos[0];
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = true;
            Vector3 v = (collision.transform.position - this.transform.position).normalized;
            playerDiff = (collision.transform.position - this.transform.position).magnitude;
            var face = Vector3Int.zero;
            //自分より左側にプレイヤーがいる
            if(v.x < 0)
            {
                chaseDirection = (int)Arrow.Left;
                face = Vector3Int.left;
            }
            if(v.x > 0)
            {
                chaseDirection = (int)Arrow.Right;
                face = Vector3Int.right;
            }
            if(v.y > 0)
            {
                chaseDirection = (int)Arrow.Up;
                face = Vector3Int.up;
            }
            if(v.y < 0)
            {
                chaseDirection = (int)Arrow.Down;
                face = Vector3Int.down;
            }
            if(playerDiff <= 2)
            {
                base.LookToDirection(face);
            }
        }

        /*else if(collision.gameObject.GetComponent<EnemyCharacterBase>())
        {
            Vector3 v1 = (collision.transform.position - this.transform.position).normalized;
            enemyDiff = (collision.transform.position - this.transform.position).magnitude;
            if(enemyDiff == 1 || enemyDiff == 2)
            {
                var rand = Random.Range(0,3);
                if(v1.x < 0)
                {
                    isLeft = true;
                }
                if(v1.x > 0)
                {
                    isRight = true;
                }
                if(v1.y > 0)
                {
                    isUp = true;
                }
                if(v1.y < 0)
                {
                    isDown = true;
                }
            }
        }*/
    }

    //索敵範囲からでた場合は追随モードを外す
    private void OnTriggerExit2D(Collider2D collision) //これはExitなので外す。
    {
        if(collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = false;
        }
    }

    public override void Update()
    {
        if (GameTurnManager.playerActionCount != enemyActionCount) {
            enemyActionCount++;
            if(isChase)
            {
                //プレイヤーと自分との距離が近ければ攻撃する
                if(playerDiff <= 2)
                {
                    base.IsAttack = true;
                }
                //そうでなければプレイヤーを追う
                else
                {
                    base.SetArrowState((Arrow)chaseDirection);
                }
            }
            else
            {
                var rand = Random.Range(0,4);
                switch (rand) {
                case 0:
                    if(isLeft)
                    break;
                    base.SetArrowState(Arrow.Left);
                    break;
                case 1:
                    if(isUp)
                    break;
                    base.SetArrowState(Arrow.Up);
                    break;

                case 2:
                    if(isDown)
                    break;
                    base.SetArrowState(Arrow.Down);
                    break;

                case 3:
                    if(isRight)
                    break;
                    base.SetArrowState(Arrow.Right);
                    break;
                }
            }
        }
        isLeft = false;
        isUp = false;
        isDown = false;
        isRight = false;
        base.Update();
    }
}
