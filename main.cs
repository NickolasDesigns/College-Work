

using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
//namespace MineSweep
//{
static class main
{

    public static void PrintBoard()
    {
        int numTests = Convert.ToInt32(Console.ReadLine());
        for (int t = 0; t < numTests; t++)
        {
            string[] nums = Console.ReadLine().Split(' '); //reading text document and getting stats of the board in the form of an array
            int numRows = Convert.ToInt32(nums[0]);
            int numCols = Convert.ToInt32(nums[1]);
            int numMines = Convert.ToInt32(nums[2]);
            // create the board
            string[,] board = new string[numRows, numCols];
            string[,] dispBoard = new string[numRows, numCols];
            for (int i = 0; i < numCols; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    dispBoard[j, i] = "- ";   //creating a board with dashes, later will assign these placeholders to actual board pieces. 
                }
            }

            //assigning the mine locations
            for (int m = 0; m < numMines; m++)
            {
                string[] coords = Console.ReadLine().Split(' '); //reading coords, sticking them into and array then assigning variables to coords.
                int row = Convert.ToInt32(coords[0]);
                int col = Convert.ToInt32(coords[1]);
                // add mine at [row,col] to the board
                dispBoard[row, col] = "M ";
            }
        
      //assigning the number of neighboring mines to each cell. 
            for (int i = 0; i < numCols; i++)
            {
                int count = 0; //initialize the count variable, which will represent neighboring mines.

                for (int j = 0; j < numRows; j++)
                {
                    //series of if statements to get the proper number of neighboring mines.

                   if (i == 0 && j == 0) // top left corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i+1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }
                        if (dispBoard[i+1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                   else if (i == numCols-1 && j == 0) // bottom left corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ") //top right
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                    }
                   else if (i == numCols - 1 && j == numRows-1) // bottom right corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j - 1] == "M ") //top left
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                    }
                   else if (i == 0 && j == numRows - 1) // top right corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                   else if (j != 0 && j != numRows-1 && i == numCols - 1) // bottom row works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i -1 , j + 1] == "M ") //top right
                        {
                            count++;
                        }
                        if (dispBoard[i-1, j] == "M ") //top 
                        {
                            count++;
                        }
                        if (dispBoard[i-1, j - 1] == "M ") //top left
                        {
                            count++;
                        }
                    }
                    else if (j != 0 && j != numRows - 1 && i == 0) // top row works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i+1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }
                        if (dispBoard[i+1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                        if (dispBoard[i+1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                    else if (i!= 0 && i!= numRows-1 && j==0) // left edge of board works
                    {
                        count = 0;
                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                       
                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ") //top right
                        {
                            count++;
                        }
                        
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }
                        
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                    else if (i != 0 && i != numRows - 1 && j == numRows -1) // right edge of board works
                    {
                        count = 0;
                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }

                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j -1] == "M ") //top left
                        {
                            count++;
                        }

                        if (dispBoard[i, j - 1] == "M ")//left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }

                        if (dispBoard[i + 1, j-1] == "M ") //bottom left
                        {
                            count++;
                        }
                    }
                    else if(i>0 && i<numCols-1 && j>0 && j<numRows-1)//middle of board WORKS
                    {
                        count = 0;
                        if (dispBoard[i, j] == "M ")   //checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i - 1, j - 1] == "M ")  //top left
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ")   //top
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ")   //top right
                        {
                            count++;
                        }
                        if (dispBoard[i, j - 1] == "M ")   //left
                        {
                            count++;
                        }
                        if (dispBoard[i, j + 1] == "M ")   // right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j + 1] == "M " ) //bottom right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }

                    dispBoard[i, j] = count.ToString() + " "; //adding correct number of neighbors to the cell. 

                }
            }

       // print the board created above
            Console.WriteLine("********* Mine Sweeper Board *********");
            for (int i = 0; i < numCols; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    Console.Write(dispBoard[i, j]); //printing the cell into the console for the player to view. 
                }
                Console.WriteLine(); //make new line on console to represent the board correctly. 
            }
        }
        }



        public static void PlayGame()
        {
        //play the game
        int numTests = Convert.ToInt32(Console.ReadLine());
        for (int t = 0; t < numTests; t++)
        {
            string[] nums = Console.ReadLine().Split(' '); //reading text document and getting stats of the board in the form of an array
            int numRows = Convert.ToInt32(nums[0]);
            int numCols = Convert.ToInt32(nums[1]);
            int numMines = Convert.ToInt32(nums[2]);
            // create the board
            string[,] board = new string[numRows, numCols];
            string[,] dispBoard = new string[numRows, numCols];
            for (int i = 0; i < numCols; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    board[j, i] = "- ";  //this board will change when user interacts with board.
                    dispBoard[j, i] = "- ";   //creating a board with dashes, later will assign these placeholders to actual board pieces. 
                }
            }
            //assigning the mine locations
            for (int m = 0; m < numMines; m++)
            {
                string[] coords = Console.ReadLine().Split(' '); //reading coords, sticking them into and array then assigning variables to coords
                int row = Convert.ToInt32(coords[0]);
                int col = Convert.ToInt32(coords[1]);
                // add mine at [row,col] to the board
                dispBoard[row, col] = "M ";

            }


            //assigning the number of neighboring mines to each cell. 
            for (int i = 0; i < numCols; i++)
            {
                int count = 0; //initialize the count variable, which will represent neighboring mines.

                for (int j = 0; j < numRows; j++)
                {
                    //series of if statements to get the proper number of neighboring mines.

                    if (i == 0 && j == 0) // top left corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                    else if (i == numCols - 1 && j == 0) // bottom left corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ") //top right
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                    }
                    else if (i == numCols - 1 && j == numRows - 1) // bottom right corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j - 1] == "M ") //top left
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                    }
                    else if (i == 0 && j == numRows - 1) // top right corner of board works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                    else if (j != 0 && j != numRows - 1 && i == numCols - 1) // bottom row works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ") //top right
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ") //top 
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j - 1] == "M ") //top left
                        {
                            count++;
                        }
                    }
                    else if (j != 0 && j != numRows - 1 && i == 0) // top row works
                    {
                        count = 0;

                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i, j - 1] == "M ") //left
                        {
                            count++;
                        }
                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                    else if (i != 0 && i != numRows - 1 && j == 0) // left edge of board works
                    {
                        count = 0;
                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }

                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ") //top right
                        {
                            count++;
                        }

                        if (dispBoard[i, j + 1] == "M ") //right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }

                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }
                    else if (i != 0 && i != numRows - 1 && j == numRows - 1) // right edge of board works
                    {
                        count = 0;
                        if (dispBoard[i, j] == "M ")//checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }

                        if (dispBoard[i - 1, j] == "M ") //top
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j - 1] == "M ") //top left
                        {
                            count++;
                        }

                        if (dispBoard[i, j - 1] == "M ")//left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }

                        if (dispBoard[i + 1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                    }
                    else if (i > 0 && i < numCols - 1 && j > 0 && j < numRows - 1)//middle of board WORKS
                    {
                        count = 0;
                        if (dispBoard[i, j] == "M ")   //checking current index, making sure we dont accidentally delete the mine
                        {
                            continue;
                        }
                        if (dispBoard[i - 1, j - 1] == "M ")  //top left
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j] == "M ")   //top
                        {
                            count++;
                        }
                        if (dispBoard[i - 1, j + 1] == "M ")   //top right
                        {
                            count++;
                        }
                        if (dispBoard[i, j - 1] == "M ")   //left
                        {
                            count++;
                        }
                        if (dispBoard[i, j + 1] == "M ")   // right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j + 1] == "M ") //bottom right
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j - 1] == "M ") //bottom left
                        {
                            count++;
                        }
                        if (dispBoard[i + 1, j] == "M ") //bottom
                        {
                            count++;
                        }
                    }

                    dispBoard[i, j] = count.ToString() + " "; //adding correct number of neighbors to the indexed cell. 

                }
            }



            int num = Convert.ToInt32(Console.ReadLine()); //getting number of clicks
            for (int r = 0; r < num; r++)
            {
                string[] coords = Console.ReadLine().Split(' '); //reading coords, sticking them into and array then assigning variables to coords.

                string select = coords[0]; //finding out if the coords are a flag or a click. 
                    int row = Convert.ToInt32(coords[1]);
                    int col = Convert.ToInt32(coords[2]);
                    if (select == "M")
                    {
                        board[row, col] = "F ";
                    }
                if (select == "R")
                    {
                                  List<int[]> list = new List<int[]>(); //create list of int[]. 
                                      int[] array = new int[2];
                                      array[0] = row;
                                      array[1] = col;
                                      list.Add(array); //insert inital click coords into the list

                                    if(dispBoard[row, col] == "M ")
                                      {
                                         Console.WriteLine("You chose a mine, GAME OVER");
                                      }

                            if(dispBoard[row, col] == "0 ")
                             {
                                 board[row, col] = "0 ";

                                int i = 0;
                                int nummy = list.Count;
                        Console.WriteLine("Test case:" );
                        while (i<nummy)  { //iterating through the list
                                 
                                  int[] arr = list[i]; 
                                  row = arr[0];
                                  col = arr[1];
                                  i++;
                            Console.WriteLine("index:" + i + " list size: " + nummy);
                                         if ( row-1 >= 0 && row+1 < numRows && col-1 >= 0 && col+1 < numCols && dispBoard[row - 1, col - 1] == "0 ")  //top left
                                          {
                                         //   dispBoard[row - 1, col - 1] == "1 "
                                             board[row-1, col-1] = dispBoard[row-1, col-1];
                                             array[0] = row-1;
                                             array[1] = col-1;
                                                 
                                                        list.Add(array);
                                                     
                                          }
                                          if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row - 1, col] == "0 ")   //top
                                          {
                                          board[row-1, col] = dispBoard[row-1, col];
                                          array[0] = row-1;
                                          array[1] = col;
                                            
                                                list.Add(array);
                                             
                                           }
                                         if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row - 1, col + 1] == "0 ")   //top right
                                          {
                                          board[row-1, col+1] = dispBoard[row-1, col+1];
                                          array[0] = row-1;
                                          array[1] = col+1;
                                             
                                                   list.Add(array);
                                              

                                             }
                                          if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row, col - 1] == "0 ")   //left
                                           {
                                           board[row, col-1] = dispBoard[row, col-1];
                                             array[0] = row;
                                             array[1] = col-1;
                                                 
                                                         list.Add(array);
                                                     
                                             }
                                          if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row, col + 1] == "0 ")   // right
                                           {
                                           board[row, col+1] = dispBoard[row, col+1];
                                           array[0] = row;
                                           array[1] = col+1;
                                              
                                                    list.Add(array);
                                                
                                             }
                                          if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row + 1, col + 1] == "0 ") //bottom right
                                           {
                                           board[row+1, col+1] = dispBoard[row+1, col+1];
                                           array[0] = row+1;
                                           array[1] = col+1;
                                              
                                                     list.Add(array);
                                                  
                                             }
                                          if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row + 1, col - 1] == "0 ") //bottom left
                                              {
                                           board[row+1, col-1] = dispBoard[row+1, col-1];
                                           array[0] = row+1;
                                           array[1] = col-1;
                                                 
                                                         list.Add(array);
                                                     
                                              }
                                          if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row + 1, col] == "0 ") //bottom
                                           {
                                           board[row+1, col] = dispBoard[row+1, col];
                                           array[0] = row+1;
                                           array[1] = col;
                                                 
                                                      list.Add(array);
                                                      
                                             }
                                //DISPLAYING THE neighbors of the 0's
                                if(row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && dispBoard[row-1, col] != "0 ")
                            {
                                board[row-1, col] = dispBoard[row-1, col];
                            }
                                if(row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols &&col + 1 < numCols && dispBoard[row-1, col-1] != "0 ")
                            {
                                board[row - 1, col-1] = dispBoard[row - 1, col-1];
                            }
                            if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && col + 1 < numCols && dispBoard[row - 1, col + 1] != "0 ")
                            {
                                board[row - 1, col+1] = dispBoard[row - 1, col+1];
                            }
                            if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && col + 1 < numCols && dispBoard[row, col + 1] != "0 ")
                            {
                                board[row, col + 1] = dispBoard[row, col + 1];
                            }
                            if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && col + 1 < numCols && dispBoard[row, col - 1] != "0 ")
                            {
                                board[row, col - 1] = dispBoard[row, col - 1];
                            }
                            if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && col + 1 < numCols && dispBoard[row+1, col + 1] != "0 ")
                            {
                                board[row+1, col + 1] = dispBoard[row+1, col + 1];
                            }
                            if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && col + 1 < numCols && dispBoard[row + 1, col - 1] != "0 ")
                            {
                                board[row + 1, col - 1] = dispBoard[row + 1, col - 1];
                            }
                            if (row - 1 >= 0 && row + 1 < numRows && col - 1 >= 0 && col + 1 < numCols && col + 1 < numCols && dispBoard[row + 1, col] != "0 ")
                            {
                                board[row + 1, col] = dispBoard[row + 1, col];
                            }

                            nummy = list.Count;
                        }
                    }

                               else if(dispBoard[row, col] != "0 ")
                                  {
                                     board[row, col] = dispBoard[row, col];
                                  }
                                     

                            }

                       
            }


            // print the board created above
            Console.WriteLine("********* Mine Sweeper Board *********");
            for (int i = 0; i < numCols; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    Console.Write(board[i, j]); //printing the cell into the console for the player to view. 
                }
                Console.WriteLine(); //make new line on console to represent the board correctly. 
            }

        }
    }



    public static void Main(string[] args)
        {
            // This redirects the program to read standard in (i.e. the Console, 
            // which is equivalent to System.in in Java) from the given file.
            // This is one of a *very few* places where it's actually OK to catch
            // and ignore an exception
            try
            {
                Console.SetIn(new StreamReader("/Users/nickolas_whitman/Projects/MineSweep/MineSweep/printboard1.txt"));
                //Console.SetIn(new StreamReader("minegame1.txt"));
            }
            catch (Exception e)
            {
                // ignore!
                // We will just read from standard in if the file cannot be found and read
            }

            string inputType = Console.ReadLine();
            if (inputType == "print_board")
            {
                PrintBoard();
            }
            else if (inputType == "play_game")
            {
                PlayGame();
            }
            else
            {
                throw new System.InvalidOperationException($"{inputType} is not a valid Minesweeper input file type");
            }

        }
    }

