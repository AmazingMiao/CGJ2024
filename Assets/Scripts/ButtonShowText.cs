using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class ButtonShowText : MonoBehaviour
{
    //拖入想使用此方法的按钮
    public Button button;
    public RandomCharcterCreater randomCharcterCreater;

    [Header("Text Info")]
    //同上上  文本框相关
    public int textTypeID;
    public TextMeshProUGUI characterTextBoxPanel;
    public TextMeshProUGUI playerTextBoxPanel;
    // public Text playerTextBoxText;
    // 要轮播显示的文本数组
    public string[] playerTexts;
    // private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        randomCharcterCreater = GameObject.Find("Character Generator").GetComponent<RandomCharcterCreater>();
        button = GetComponent<Button>();
        HideText();
        // button.onClick.AddListener(OnButtonClick);
    }

    public void ShowText()
    {
        // 将文本框面板由隐藏改为显示
        
        
        if(textTypeID == 1)
        {
            characterTextBoxPanel.enabled = true;
            playerTextBoxPanel.enabled = false;
            characterTextBoxPanel.text = randomCharcterCreater.characterContent[textTypeID].Remove(0,2);
        }
        else if(textTypeID == 2)
        {
            StartCoroutine(ShowType2Text());
            // playerTextBoxPanel.enabled = true;
            // 设置文本框中的文本
            // playerTextBoxPanel.text = playerTexts[Random.Range(0,7)];
            // 轮播至下一个文本
            // currentIndex = (currentIndex + 1) % playerTexts.Length;
            //更改currentIndex控制轮播组数
            // characterTextBoxPanel.text = randomCharcterCreater.characterContent[textTypeID].Remove(0,2);
        }
        else if(textTypeID == 3)
        {
            characterTextBoxPanel.enabled = true;
            playerTextBoxPanel.enabled = false;
            characterTextBoxPanel.text = randomCharcterCreater.characterContent[textTypeID].Remove(0,2);
        }
        
        button.interactable = false;
    }

    public void HideText()
    {
        //将文本框ui隐藏
        characterTextBoxPanel.enabled = false;
        playerTextBoxPanel.enabled = false;
    }

    IEnumerator ShowType2Text()
    {
        playerTextBoxPanel.enabled = true;
        playerTextBoxPanel.text = playerTexts[Random.Range(0,7)];
        yield return new WaitForSeconds(1);
        characterTextBoxPanel.enabled = true;
        characterTextBoxPanel.text = randomCharcterCreater.characterContent[textTypeID].Remove(0,2);
    }
}
