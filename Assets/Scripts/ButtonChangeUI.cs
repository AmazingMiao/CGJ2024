using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonChangeUI : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    //拖入想使用此方法的按钮
    public Button button;

    [Header("Button UI Info")]
    //按钮ui相关
    //普通的按钮图片 拖入设置
    public Sprite normalSprite;
    //长按的按钮图片 同上
    public Sprite pressedSprite;
    // Start is called before the first frame update
    void Start()
    {
        // 保存原始的按钮样式
        normalSprite = button.image.sprite;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        button.image.sprite = pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.image.sprite = normalSprite;
    }

}
