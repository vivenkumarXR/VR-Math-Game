using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FlowManager : MonoBehaviour
{
    //TODO: Turn Private
    public int CubeA = 0;
    public int CubeB = 0;
    public int CubeC = 0;
    public int Result = 0;
    public List<GameObject> Sockets = new List<GameObject>();
    public GameObject Socket4;
    public GameObject HandAnimation;

    void Start()
    {
        // Initialize game elements and set the starting state of the UI and objects
        GameManager.Instance.UI_Messages.text = "Hi! Lets Calculate Numbers. Do a thums up  to move ahead.";
        GameManager.Instance.Timer.enabled = false;
        GameManager.Instance.MathematicsValues.gameObject.SetActive(false);
        GameManager.Instance.RightThumbsUp.gameObject.SetActive(true);
        GameManager.Instance.LeftThumbsUp.gameObject.SetActive(false);
        GameManager.Instance.RightShaka.gameObject.SetActive(false);
        DisableSockets();
        Socket4.SetActive(false);
        HandAnimation.SetActive(false);
    }

    public void RightHandThumpsUpPerformed()
    {
        // Triggered when the user performs a thumbs-up gesture with the right hand.
        // Updates UI messages, enables practice mode, and displays the hand animation.
        GameManager.Instance.RightShaka.gameObject.SetActive(true);
        GameManager.Instance.MathematicsValues.gameObject.SetActive(true);
        EnableSockets();
        Socket4.SetActive(true);
        GameManager.Instance.RightThumbsUp.gameObject.SetActive(false);
        GameManager.Instance.UI_Messages.text = "Place the cubes over the spheres below the correct numbers so that their sum equals the displayed result within 10 seconds. \n Let's practice by placing a cube in the highlighted sphere, as shown in the hand animation, \n or \n Perform a Shaka hand gesture with your right hand to <b>START</b>.";
        HandAnimation.SetActive(true);
    }

    public void RightShakaPerformed()
    {
        // Starts the countdown and disables the practice mode when a Shaka gesture is detected.
        GameManager.Instance.RightShaka.gameObject.SetActive(false);
        Socket4.SetActive(false);
        StartCountDown();
        HandAnimation.SetActive(false);
    }

    public void LeftHandThumpsUpPerformed()
    {
        // Restarts the scene when a left-hand thumbs-up gesture is detected.
        RestartScene();
    }

    public void StartCountDown()
    {
        // Starts the countdown timer and generates a random result value.
        GameManager.Instance.Timer.enabled = true;
        StartCountdown();
        GenerateResult();
    }

    public void GenerateResult()
    {
        // Generates a random result from predefined numbers and displays it on the screen.
        int[] numbers = { 3, 4, 5, 6 };
        int randomIndex = UnityEngine.Random.Range(0, numbers.Length);
        int selectedNumber = numbers[randomIndex];
        Result = selectedNumber;

        TextMeshPro resultText = GameManager.Instance.result.GetComponent<TextMeshPro>();
        resultText.text = selectedNumber.ToString();
    }

    public void StartCountdown()
    {
        // Starts the countdown coroutine to handle the timer.
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        // Counts down from 8 seconds and updates the UI each second.
        int countdownTime = 10;

        while (countdownTime >= 0)
        {
            Debug.Log("Countdown: " + countdownTime);
            GameManager.Instance.Timer.GetComponent<TextMeshProUGUI>().text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        OnCountdownFinished();
    }

    private void OnCountdownFinished()
    {
        // Handles logic when the countdown ends, such as checking the user's answer.
        GameManager.Instance.Timer.enabled = false;
        CalculateValue();
    }

    public void CalculateValue()
    {
        // Verifies if the sum of cubes matches the result and updates the UI accordingly.
        if (CubeA + CubeB + CubeC == Result)
        {
            GameManager.Instance.UI_Messages.text = "Congratulations! You are correct. Please raise your left hand and perform a left-hand thumbs-up gesture to play again.";
            GameManager.Instance.LeftThumbsUp.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.UI_Messages.text = "Sorry, your answer is incorrect. Please raise your left hand and perform a left-hand thumbs-up gesture to play again.";
            GameManager.Instance.LeftThumbsUp.gameObject.SetActive(true);
        }
    }

    public void RestartScene()
    {
        // Reloads the current scene to reset the game state.
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void CubeAFun(int value)
    {
        // Sets the value of CubeA.
        CubeA = value;
    }

    public void CubeBFun(int value)
    {
        // Sets the value of CubeB.
        CubeB = value;
    }

    public void CubeCFun(int value)
    {
        // Sets the value of CubeC.
        CubeC = value;
    }

    private void DisableSockets()
    {
        // Disables all socket interactors at the start of the game.
        foreach (var socket in Sockets)
        {
            if (socket != null)
            {
                socket.SetActive(false);
                socket.GetComponent<XRSocketInteractor>().enabled = false;
            }
        }
    }

    private void EnableSockets()
    {
        // Enables all socket interactors when practice mode or gameplay begins.
        foreach (var socket in Sockets)
        {
            if (socket != null)
            {
                socket.SetActive(true);
                socket.GetComponent<XRSocketInteractor>().enabled = true;
            }
        }
    }
}
