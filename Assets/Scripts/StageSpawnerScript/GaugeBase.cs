using UnityEngine;
using UnityEngine.UI;

public class GaugeBase : MonoBehaviour
{
    private Image gauge => this.GetComponent<Image>();

    public void SetGauge(float HPRate){

        gauge.fillAmount = HPRate; //このfillAmountはspriteのfillで操作でき、色の割合を水平に変更できる。
    }
}
