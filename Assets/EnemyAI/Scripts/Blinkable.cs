using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blinkable : MonoBehaviour
{
    
    public SpriteRenderer Sprite;
    public Color fadedColor;
    public Color reappearColor;

    private void Start() {
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }
    

    public void StartBlinking( float blinkTime ){
        // Sprite.DOColor( fadedColor, 0.1f ) ;
        Sprite.DOColor( fadedColor, blinkTime )
        .SetEase(Ease.Flash, 16, 1)
        .OnComplete(EndBlinking);


    }

    public void EndBlinking(){
        Sprite.DOColor( reappearColor, 0.1f );
    }



}
