using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class calScene : MonoBehaviour
{
    private int bottleCount;
    private string timeString;

    // Start is called before the first frame update
    void Start()
    {
        bottleCount = 0;
        readFromFiles(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        GameObject.Find("Get Button").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Get Button").GetComponent<Button>().onClick.AddListener(getData);
        GameObject.Find("Month Dropdown").GetComponent<TMP_Dropdown>().value = DateTime.Now.Month - 1;
        GameObject.Find("Day Dropdown").GetComponent<TMP_Dropdown>().value = DateTime.Now.Day - 1;
        GameObject.Find("Year Input Text PlaceHolder").GetComponent<Text>().text = DateTime.Now.ToString("yyyy");
        GameObject.Find("Menu Image").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Menu Image").GetComponent<Button>().onClick.AddListener(goToMenuScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void readFromFiles(int year, int month, int date1)
    {
        timeString = "Time:\n";
        bottleCount = 0;
        DateTime date = new DateTime(year, month, date1);
        if (File.Exists(Application.persistentDataPath + "/" + date.ToString("yyyy-MMM-dd") + ".txt"))
        {
            using (StreamReader sr = new StreamReader(Application.persistentDataPath + "/" + date.ToString("yyyy-MMM-dd") + ".txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    timeString = timeString + "\n" + s;   
                    bottleCount++;
                }
            }
        }
        else
        {
            timeString = timeString + "No Records";
        }
        GameObject.Find("Number Label").GetComponent<TextMeshProUGUI>().text = "" + bottleCount;
        GameObject.Find("Details Label").GetComponent<TextMeshProUGUI>().text = "" + timeString;
    }
    void getData()
    {
        int year;
        if (GameObject.Find("Year Input Text").GetComponent<Text>().text.Equals(""))
        {
            year = DateTime.Now.Year;
        }
        else
        {
            year = int.Parse(GameObject.Find("Year Input Text").GetComponent<Text>().text);
        }
        int month = GameObject.Find("Month Dropdown").GetComponent<TMP_Dropdown>().value + 1;
        int day = GameObject.Find("Day Dropdown").GetComponent<TMP_Dropdown>().value + 1;
        readFromFiles(year, month, day);
    }
    void goToMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
