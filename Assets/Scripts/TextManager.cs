using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TypingGame
{
    public class TextManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI targetText;
        [SerializeField] TextMeshProUGUI userInputText;

        [SerializeField] int timeToWin = 10;
        [SerializeField] int timeToLose = 3;

        char targetChar;

        int numOfCorrect = 0;
        int numOfWrong = 0;
        bool isEnded = false;

        //Function call when program start. This function will run once.
        private void Start()
        {
            targetChar = GetRandomCharAToZ();

            if (targetText != null)
            {
                targetText.SetText(targetChar.ToString());
            }
        }

        // Neu nhap dung 10 lan lien tiep thi => se pha dao game
        // Neu nhap sai thi reset so lan nhap dung ve 0
        // Neu nhap sai 3 lan lien tiep thi => game over

        // Neu da ket thuc game. Hien thi UI huong dan user bam nut ESC.
        // Neu da ket thuc game. Bam Nut ESC de bat dau lai.
        void Update()
        {
            RestartGame();

            CheckLogicWhenWinning(timeToWin);

            CheckLogicWhenLosing(timeToLose);

            GetUserInput();

        }

        /// <summary>
        /// Get user input and caculate game logic
        /// </summary>
        private void GetUserInput()
        {
            for (int i = 0; i < Input.inputString.Length; i++)
            {
                if (Input.inputString == targetChar.ToString())
                {
                    userInputText.SetText("Correct");
                    targetChar = GetRandomCharAToZ();
                    targetText.SetText(targetChar.ToString());
                    numOfCorrect++;
                }
                else
                {
                    userInputText.SetText("Wrong");
                    numOfCorrect = 0;
                    numOfWrong++;
                }
            }
        }
        
        /// <summary>
        /// Get input to restart game
        /// </summary>
        private void RestartGame()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isEnded == true)
            {
                numOfCorrect = 0;
                numOfWrong = 0;
                targetChar = GetRandomCharAToZ();
                userInputText.SetText("");
                targetText.SetText(targetChar.ToString());
                isEnded = false;
            }
        }
        
        /// <summary>
        /// Check condition when user typing correct enough to win.
        /// </summary>
        private void CheckLogicWhenWinning(int timeToWin)
        {
            if (numOfCorrect == timeToWin)
            {
                targetText.SetText("You win");
                userInputText.SetText("Enter ESC to restart");
                isEnded = true;
                return;
            }
        }

        /// <summary>
        /// Check condition when user typing wrong enough to lose.
        /// </summary>
        private void CheckLogicWhenLosing(int timeToLose)
        {
            if (numOfWrong == timeToLose)
            {
                targetText.SetText("You lost");
                userInputText.SetText("Enter ESC to restart");
                isEnded = true;
                return;
            }
        }

        /// <summary>
        /// Get one random character from A to Z when called.
        /// </summary>
        /// <returns></returns>
        private char GetRandomCharAToZ()
        {
            return(char)Random.Range('a', 'z');
        }
    }

}
