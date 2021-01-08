using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chartDetails : MonoBehaviour
{
    // Start is called before the first frame update
    int[] bottleCountArray;
    GameObject[] obj;
    void Start()
    {
        bottleCountArray = new int[31];
        obj = new GameObject[31];
        readFromFiles(DateTime.Now.Year, DateTime.Now.Month);
        drawGraph();        
        GameObject.Find("Get Button").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Get Button").GetComponent<Button>().onClick.AddListener(doGraph);
    }
    void drawGraph()
    {
        float max = getMax(bottleCountArray);
        for (int i = 0; i < 31; i++)
        {
            obj[i] = (GameObject)Instantiate(Resources.Load("Set"), GameObject.Find("Canvas").transform);
            obj[i].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 360 - 32 * i, 0);
            obj[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "" + (i + 1);
            obj[i].transform.GetChild(1).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(bottleCountArray[i]*500f/max, 25f);
            obj[i].transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "" + bottleCountArray[i];
        }
    }
    void deleteSets()
    {
        for (int i = 0; i < 31; i++)
        {
            Destroy(obj[i]);
        }
    }
    float getMax(int[] a)
    {
        float max = a[0];
        for(int i=0;i<a.Length;i++)
        {
            if(max<a[i])
            {
                max = a[i];
            }
        }
        if(max==0f)
        {
            return 1f;
        }
        else    
        return max;
    }
    void readFromFiles(int year,int month)
    {
        DateTime date = new DateTime(year, month, 1);
        for(int i=0;i<31;i++)
        {
            if(File.Exists(Application.persistentDataPath+"/"+date.ToString("yyyy-MMM-")+getDate(i+1)+".txt"))
            {
                using (StreamReader sr = new StreamReader(Application.persistentDataPath + "/" + date.ToString("yyyy-MMM-") + getDate(i + 1) + ".txt"))
                {
                    string s;
                    while((s=sr.ReadLine())!=null)
                    {
                        bottleCountArray[i]++;
                    }
                }
            }
        }
    }
    string getDate(int i)
    {
        if(i<10)
        {
            return "0" + i;
        }
        else
        {
            return "" + i;
        }
    }
    void doGraph()
    {
        deleteSets();
        obj = new GameObject[31];
        int year;
        if(GameObject.Find("Year Input Text").GetComponent<Text>().text.Equals(""))
        {
            year = DateTime.Now.Year;
        }
        else
        {
            year = int.Parse(GameObject.Find("Year Input Text").GetComponent<Text>().text);
        }        
        int month = GameObject.Find("Month Dropdown").GetComponent<TMP_Dropdown>().value + 1;
        bottleCountArray = new int[31];
        readFromFiles(year,month);
        drawGraph();
    }
}
