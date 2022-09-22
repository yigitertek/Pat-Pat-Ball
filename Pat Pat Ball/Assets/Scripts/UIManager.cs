using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectcontrol = 0;

    public IEnumerator WhiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.01f); 
            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b,1))
            {
               effectcontrol = 1;
            }
        }
        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.01f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
        if (effectcontrol == 2)
        {
            Debug.Log("Efekt bitti");
        }
    }
        
}
