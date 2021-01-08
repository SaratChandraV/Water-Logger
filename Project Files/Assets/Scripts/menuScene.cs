using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Log").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Log").GetComponent<Button>().onClick.AddListener(goToLogScene);
        GameObject.Find("Chart").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Chart").GetComponent<Button>().onClick.AddListener(goToChartScene);
        GameObject.Find("Cal").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("Cal").GetComponent<Button>().onClick.AddListener(goToCalScene);
    }
    void goToLogScene()
    {
        SceneManager.LoadScene("LogScene", LoadSceneMode.Single);
    }
    void goToChartScene()
    {
        SceneManager.LoadScene("ChartScene", LoadSceneMode.Single);
    }
    void goToCalScene()
    {
        SceneManager.LoadScene("CalScene", LoadSceneMode.Single);
    }
}
