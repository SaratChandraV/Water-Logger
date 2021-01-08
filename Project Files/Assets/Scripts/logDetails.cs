using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logDetails : MonoBehaviour
{
    // Start is called before the first frame update
    DateTime todayDate;
    string logTimeDetails;
    int bottleCount;
    List<string> timeDetails;
    string line;
    void Start()
    {
        todayDate = DateTime.Now;
        logTimeDetails = "";
        timeDetails = new List<string>();
        if(File.Exists(Application.persistentDataPath + "/"+todayDate.ToString("yyyy-MMM-dd") + ".txt"))
        {
            readDetailsFromFile();
        }
        GameObject.Find("Today Label").GetComponent<TextMeshProUGUI>().text = "Today\n" + todayDate.ToString("dd MMMM yyyy");

        GameObject.Find("Log Button").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Log Button").GetComponent<Button>().onClick.AddListener(logTime);

        GameObject.Find("Menu Image").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Menu Image").GetComponent<Button>().onClick.AddListener(goToMenuScene);

        bottleCount = int.Parse(GameObject.Find("Number Label").GetComponent<TextMeshProUGUI>().text);
    }
    void logTime()
    {
        if(logTimeDetails.Equals(""))
        {
            logTimeDetails = "Time:\n";
        }
        logTimeDetails = logTimeDetails + DateTime.Now.ToString("hh:mm:ss tt") + "\n";
        timeDetails.Add(DateTime.Now.ToString("hh:mm:ss tt"));
        GameObject.Find("Details Label").GetComponent<TextMeshProUGUI>().text = logTimeDetails;
        bottleCount++;
        GameObject.Find("Number Label").GetComponent<TextMeshProUGUI>().text = "" + bottleCount;
        writeDetailsToFile();
    }
    void readDetailsFromFile()
    {
        bottleCount = 0;
        if (logTimeDetails.Equals(""))
        {
            logTimeDetails = "Time:\n";
        }
        using (StreamReader sr = new StreamReader(Application.persistentDataPath + "/" + todayDate.ToString("yyyy-MMM-dd") + ".txt"))
        {
            while((line = sr.ReadLine())!=null)
            {
                timeDetails.Add(line);
                logTimeDetails = logTimeDetails + line+"\n";
                bottleCount++;
            }
        }
        GameObject.Find("Details Label").GetComponent<TextMeshProUGUI>().text = logTimeDetails;
        GameObject.Find("Number Label").GetComponent<TextMeshProUGUI>().text = "" + bottleCount;
    }
    void writeDetailsToFile()
    {
        StreamWriter sr = new StreamWriter(Application.persistentDataPath + "/" + todayDate.ToString("yyyy-MMM-dd") + ".txt");
        foreach(string s in timeDetails)
        {
            sr.WriteLine(s);
        }
        sr.Close();
    }
    void goToMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
