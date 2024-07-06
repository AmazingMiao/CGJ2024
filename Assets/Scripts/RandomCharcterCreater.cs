using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class RandomCharcterCreater : MonoBehaviour
{
    public CSVReader cSVReader;
    public SpriteRenderer characterSr;
    private System.Random random = new System.Random();
    public bool result;
    public bool richment;
    public int nLine;
    public int count;
    public int[] nLines;
    public string characterSpriteName;

    // Start is called before the first frame update
    void Start()
    {
        cSVReader = GetComponent<CSVReader>();
        characterSr = GameObject.Find("Character").GetComponent<SpriteRenderer>();

        // int resultValue = random.Next(0,1); // 随机生成0或1决定结果
        int resultValue = Random.Range(0,2);

        Debug.Log($"吉凶: {resultValue}");
        //吉为真凶为假
        if ( resultValue == 0)
        {
            result = false;
        }
        else result = true;

        // int richmentValue = random.Next(0,1);// 随机生成0或1决定贫富
        int richmentValue = Random.Range(0,2);

        Debug.Log($"贫富: {richmentValue}");
        //贫为真富为假
        if( richmentValue == 0 )
        {
            richment = false;
        }
        else richment = true;

        

        if(cSVReader.csvFile.name.Equals("money_list"))
        {
            characterSpriteName = "char_money_";
        }
        else if(cSVReader.csvFile.name.Equals("love_list"))
        {
            characterSpriteName = "char_love_";
        }
        else if(cSVReader.csvFile.name.Equals("ambition_list"))
        {
            characterSpriteName = "char_ambition_";
        }

        if(richment)
        {
            characterSpriteName += "poor_";
        }
        else
        {
            characterSpriteName += "rich_";
        }

        characterSpriteName += Random.Range(0,3);

        characterSr.sprite = Resources.Load<Sprite>("Characters/"+characterSpriteName);

        AttributeGenerater();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //根据吉凶贫富生成CSV行序号
    public int MoneylistGenerator(bool rs, bool rc, int i)
    {
        int row;
        if( rs == true) 
        {
         if( rc == false ) 
            row = random.Next(1,3);
         else row = random.Next(4,6);
        }
        else
        {
            if( rc == false && i == 0) 
            row = random.Next(1,3);
            else if(i == 0)
            {
                row = random.Next(4,6);
            }
            else row = random.Next(1,6);
        }

        return row;
    }
    public void AttributeGenerater()
    {
        Debug.Log("Start Generating " + cSVReader.grid.GetLength(1));
        // nLines = new int[count]; // 初始化数组，count为属性数

        for (int i = 0; i < cSVReader.grid.GetLength(1)-1; i++)
        {
            // MoneylistGenerator();
            // nLines[i] = nLine; // 将生成的行数存入数组，之后在CSVUser中调用为行数查找属性
            cSVReader.CSVUser(MoneylistGenerator(result, richment, i), i);
        }

    }
}
