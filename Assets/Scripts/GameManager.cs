using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI UI_Messages;
    public TextMeshProUGUI Timer;
    public GameObject MathematicsValues;
    public GameObject RightThumbsUp;
    public GameObject LeftThumbsUp;
    public GameObject result;
    public GameObject RightShaka;


    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (result == null)
        {
            result = GameObject.FindGameObjectWithTag("result");
        }
        if (UI_Messages == null)
        {
            UI_Messages = GameObject.FindGameObjectWithTag("UI_Messages").GetComponent<TextMeshProUGUI>();
        }
        if (Timer == null)
        {
            Timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();

        }
        if (MathematicsValues == null)
        {
            MathematicsValues = GameObject.FindGameObjectWithTag("MathematicsValues");

        }
        if (RightThumbsUp == null) 
        {
            RightThumbsUp = GameObject.FindGameObjectWithTag("RightThumbsUp");

        }
        if (LeftThumbsUp == null)
        {
            LeftThumbsUp = GameObject.FindGameObjectWithTag("LeftThumbsUp");

        }
        if (RightShaka == null)
        {
            RightShaka = GameObject.FindGameObjectWithTag("RightShaka");

        }




    }

}
