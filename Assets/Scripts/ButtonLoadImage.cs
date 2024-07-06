using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ButtonLoadImage : MonoBehaviour
{
    //拖入想使用此方法的按钮
    public Button button;

    [Header("Image Display Info")]
    //同上 image相关
    public Image displayImage;
    //储存调用image的字符串
    public string imageName;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        //imageName =  特写属性字符串;  ←没找到你的属性存在哪里的拿到的话稍微自己改一下
        // 调用输出字符串加载图片的方法
        LoadAndDisplayImage(imageName);
    }

    void LoadAndDisplayImage(string imageName)
    {

        Sprite loadedSprite = Resources.Load<Sprite>("特写资源文件夹" + imageName);


        if (loadedSprite != null)
        {
            // 将加载的图片显示在 Image 组件上
            displayImage.sprite = loadedSprite;
            Debug.Log("加载了image且显示了 " + imageName);
        }
        else
        {
            Debug.LogError("image未加载成功" + imageName);
        }
    }
}
