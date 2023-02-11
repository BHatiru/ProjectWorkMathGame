
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomEquationGenerator : MonoBehaviour
{
    public GameObject player; 
    public Text Question;
    public GameObject ChooseAnswer;
    public Button Ans1, Ans2, Ans3;
    public GameObject fireButton;
    int a, b, c;
    int d;
    int WrongAnswerCount;


    public void RandomEquiation()
    {      
        ChooseAnswer.SetActive(true);
        //Time.timeScale = 0.2f;
        a = Random.Range(1, 11);
        b = Random.Range(1, 11);
        d = Random.Range(1, 11);
        //
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            c = a + b;
            
            Question.text = a + " + " + b + " = ?";
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            c = a + b + d;
            
            Question.text = a + " + " + b + " + " + d + " = ?";
        } //changing the difficulty of the equation depending on the level
        string result = c.ToString();

        //generates wrong answers that do not differ too much from the true answer
        int wrongResult1, wrongResult2;
        do
        {
            wrongResult1 = Random.Range(c - 4, c + 4);
            wrongResult2 = Random.Range(c - 4, c + 4);
        } while (wrongResult1 == c || wrongResult2 == c || wrongResult1 == wrongResult2 || wrongResult1 < 0 || wrongResult2 < 0); //prevents identical answer options and negative values from appearing 

        //assigns the correct answer to a random answer selection button.
        int ans = Random.Range(0,3);
        if (ans == 0)
        {
            Ans1.GetComponentInChildren<Text>().text = result;
                     
            Ans2.GetComponentInChildren<Text>().text = wrongResult1+"";
            Ans3.GetComponentInChildren<Text>().text = wrongResult2+"";

            Ans1.onClick.RemoveAllListeners();
            Ans1.onClick.AddListener(player.GetComponent<Shooting>().Shoot);            

            Ans2.onClick.RemoveAllListeners();
            Ans2.onClick.AddListener(WrongButtonAction);

            Ans3.onClick.RemoveAllListeners();
            Ans3.onClick.AddListener(WrongButtonAction);
        }
        else if (ans == 1)
        {
            Ans2.GetComponentInChildren<Text>().text = result;
            
            Ans1.GetComponentInChildren<Text>().text = wrongResult1 + "";            
            Ans3.GetComponentInChildren<Text>().text = wrongResult2 + "";

            Ans2.onClick.RemoveAllListeners();
            Ans2.onClick.AddListener(player.GetComponent<Shooting>().Shoot);          

            Ans1.onClick.RemoveAllListeners();
            Ans1.onClick.AddListener(WrongButtonAction);

            Ans3.onClick.RemoveAllListeners();
            Ans3.onClick.AddListener(WrongButtonAction);
        }           
        else if (ans == 2)
        {
            Ans3.GetComponentInChildren<Text>().text = result;
           
            Ans1.GetComponentInChildren<Text>().text = wrongResult1 + "";
            Ans2.GetComponentInChildren<Text>().text = wrongResult2 + "";

            Ans3.onClick.RemoveAllListeners();
            Ans3.onClick.AddListener(player.GetComponent<Shooting>().Shoot);            

            Ans1.onClick.RemoveAllListeners();
            Ans1.onClick.AddListener(WrongButtonAction);

            Ans2.onClick.RemoveAllListeners();
            Ans2.onClick.AddListener(WrongButtonAction);
        }                
    }

    void WrongButtonAction()// method for wrong choise
    {
        WrongAnswerCount++;
        player.GetComponent<PlayerHealth>().DamageIfWrongAnswer();
        ChooseAnswer.SetActive(false);
        Time.timeScale = 1f;
        
    }

}
