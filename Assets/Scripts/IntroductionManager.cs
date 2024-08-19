using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionManager : MonoBehaviour
{
    public GameObject quizBtn;
    // Start is called before the first frame update
    void Start()
    {
        quizBtn.SetActive(false);
    }

    public void WalletConnected() {
        quizBtn.SetActive(true);
    }

    public void StartQuiz() {
        SceneManager.LoadScene(1);//1
    }
}
