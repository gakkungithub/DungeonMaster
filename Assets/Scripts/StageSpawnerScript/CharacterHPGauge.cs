using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHPGauge : GaugeBase
{
    public CharacterParameterBase CharacterParameter;

    private float hpRate = 0f;

    private RectTransform gaugeRectTransform;

    private void Start()
    {
        hpRate = CharacterParameter.GetHitPoint / CharacterParameter.GetMaxHitPoint;
        SetGauge(hpRate);
        gaugeRectTransform = this.transform.parent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        //gaugeRectTransformをcharacterParameterの位置として追従する
        gaugeRectTransform.position 
           = RectTransformUtility.WorldToScreenPoint(Camera.main,
           CharacterParameter.gameObject.transform.position + new Vector3(0,1));　/*ある座標(world)を画面のある一点として表示させることが出来る。
                                                                                    つまり三次元を疑似二次元にすることが可能。逆もある。*/
        //現状のhpRateと計算結果が一緒なら早期リターン
        if(hpRate == CharacterParameter.GetHitPoint / CharacterParameter.GetMaxHitPoint)
        {
            return;
        }
        hpRate = CharacterParameter.GetHitPoint / CharacterParameter.GetMaxHitPoint;
        SetGauge(hpRate);
    }
}
