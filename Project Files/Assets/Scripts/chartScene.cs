using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class chartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Menu Image").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Menu Image").GetComponent<Button>().onClick.AddListener(goToMenuScene);
        GameObject.Find("Year Input Text PlaceHolder").GetComponent<Text>().text = DateTime.Now.ToString("yyyy");
        GameObject.Find("Month Dropdown").GetComponent<TMP_Dropdown>().value = int.Parse(DateTime.Now.ToString("MM")) - 1;
    }

    // Update is called once per frame
    
    void goToMenuScene()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
