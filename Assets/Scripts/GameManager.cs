using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int isCricleTurn; // X = 0 and O = 1;
    public ButtonController[] buttonControllers;
    GameObject[] cells  = new GameObject[9];
    public Button[] Spaces; // playable space for our game.
    public Sprite[] playerIcons; // Xicon = 0 and Oicon = 1
    public int[] ButtonIndex; // order our buttons
    public int  turnCount; // counts the number fo the turn played
    public Text winnerText; // hold the text compoent
    public GameObject[] winningLine; // hold all the line winner

    
    public void Awake()
    {

       ButtonControllerFiller();  

       for(int i = 0; i < ButtonIndex.Length; i++)

         {

            ButtonIndex[i] = -100;


         }

     
    }   

      // this function Fill the array with the scripts.
    public void ButtonControllerFiller()

    {
        
        cells = GameObject.FindGameObjectsWithTag ("Cells");

        buttonControllers = new ButtonController[cells.Length];

         for(int i = 0;  i < cells.Length; i++)

         {
           buttonControllers[i] = cells[i].GetComponent<ButtonController>();

         }            

    }
      public void Button(int WhichNumber)

   {


      //Give access to the button was clicked.
      Spaces[WhichNumber].image.sprite = playerIcons[isCricleTurn];
      //this do the button dont be click again.
      Spaces[WhichNumber].interactable = false;

      ButtonIndex[WhichNumber] = isCricleTurn+1;

      turnCount++;

      if(turnCount > 4)

      {
         WinnerCheck();

      }

      if(isCricleTurn == 0)

      {
           isCricleTurn = 1; 

      }
      else 
      {
         isCricleTurn = 0;

      }
   }

   // This function check who win.  
   public void WinnerCheck()

   {
      //horizontal
      int s1 = ButtonIndex[0] + ButtonIndex[1] + ButtonIndex[2];
      int s2 = ButtonIndex[3] + ButtonIndex[4] + ButtonIndex[5];
      int s3 = ButtonIndex[6] + ButtonIndex[7] + ButtonIndex[8];
      //vertical 
      int s4 = ButtonIndex[0] + ButtonIndex[3] + ButtonIndex[6];
      int s5 = ButtonIndex[1] + ButtonIndex[4] + ButtonIndex[7];
      int s6 = ButtonIndex[2] + ButtonIndex[5] + ButtonIndex[8];
      //diagonals
      int s7 = ButtonIndex[6] + ButtonIndex[4] + ButtonIndex[2];
      int s8 = ButtonIndex[0] + ButtonIndex[4] + ButtonIndex[8];

      var solution = new int[] {s1 , s2, s3, s4, s5, s6, s7, s8};

      for(int i = 0; i < solution.Length; i++)

      {

      if(solution[i] == 3 * (isCricleTurn+1))

      {

       WinnerDisplay(i);
       
       
      }

     
     }
   
   }   
     
    void WinnerDisplay(int index)

      {

      winnerText.gameObject.SetActive(true);


      if(isCricleTurn == 0)

       {

       winnerText.text = "Player X Wins!";
       

 
       }

      else if(isCricleTurn == 1)

      { 

      winnerText.text = "Player O wins!";
 
      }

      winningLine[index].SetActive(true);

      for(int i = 0; i < Spaces.Length; i ++)

      {

        Spaces[i].interactable = false;

      }

  }

      public void ChangeSence()

      {

         SceneManager.LoadScene(sceneBuildIndex: 1);  

         

      }



   public void Restart()


   {
      
   SceneManager.LoadScene(SceneManager.GetActiveScene().name);     
   
   }



public void Quit()


{


Application.Quit();

   Debug.Log("bye bye");

}




}
