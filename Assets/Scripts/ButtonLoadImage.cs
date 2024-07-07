using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class ButtonLoadImage : MonoBehaviour
{
    //拖入想使用此方法的按钮
    public RandomCharcterCreater randomCharcterCreater;
    public GameManager gameManager;
    public TextMeshProUGUI characterTextBoxPanel;
    public TextMeshProUGUI playerTextBoxPanel;
    public Button button;

    [Header("Image Display Info")]
    //同上 image相关
    public Image displayImage;
    //储存调用image的字符串
    public string imageName;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        displayImage = GameObject.Find("characterImage").GetComponent<Image>();
        displayImage.enabled = false;
        randomCharcterCreater = GameObject.Find("Character Generator").GetComponent<RandomCharcterCreater>();
        button = GetComponent<Button>();
        characterTextBoxPanel = GameObject.Find("characterText").GetComponent<TextMeshProUGUI>();
        playerTextBoxPanel = GameObject.Find("playerText").GetComponent<TextMeshProUGUI>();
    }
    public void OnButtonClick()
    {
        GetComponent<AudioSource>().Play();
        gameManager.AP--;
        GameObject.Find("censer").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Props/censer_" + gameManager.AP);
        //imageName =  特写属性字符串;  ←没找到你的属性存在哪里的拿到的话稍微自己改一下
        // 调用输出字符串加载图片的方法
        imageName = randomCharcterCreater.characterContent[0].Remove(0,2);
        imageName = imageName.Replace(".png","");
        StartCoroutine(LoadAndDisplayImage(imageName));
        button.interactable = false;
    }

    IEnumerator LoadAndDisplayImage(string imageName)
    {
        yield return new WaitForSeconds(1);
        characterTextBoxPanel.enabled = false;
        playerTextBoxPanel.enabled = false;
        displayImage.enabled = true;
        displayImage.gameObject.GetComponent<AudioSource>().Play();

        // Sprite loadedSprite = Resources.Load<Sprite>("CloseUp/" + imageName);
        Debug.Log("" + imageName);
        displayImage.sprite = Resources.Load<Sprite>("CloseUp/" + imageName);

        // if (loadedSprite != null)
        // {
        //     // 将加载的图片显示在 Image 组件上
        //     displayImage.sprite = loadedSprite;
        //     Debug.Log("加载了image且显示了" + imageName);
        // }
        // else
        // {
        //     Debug.LogError("image未加载成功" + imageName);
        // }
    }

    void Update()
    {
        if(gameManager.AP<=0)
        {
            button.interactable = false;
        }
    }
}
