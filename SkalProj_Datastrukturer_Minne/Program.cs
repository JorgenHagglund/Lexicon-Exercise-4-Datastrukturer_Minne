using System;

namespace SkalProj_Datastrukturer_Minne
{
    /*
     * Answer 1: The stack is a FILO, alternative LIFO (Last In First Out) data structure, While the heap
     *  is a Random Access Memory (RAM) data structure.
     *  
     * Answer 2: Value types are stored on the stack, while reference types are stored on the heap.
     *  Reference types are practically pointers.
     *  
     * Answer 3: First example is using value types, Assignment of value types copies the value,
     *  The second expample is using reference types, Assignment of reference types copies the pointer value,
     *  which means both x and y points to the same location in memory (the heap)..
     */
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Reverse string using Stack"
                    + "\n5. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        ReverseString();
                        break;  
                    case '5':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static void ReverseString()
        {
            do
            {
                Console.WriteLine("Please enter a string to reverse");
                Console.WriteLine("To exit to the main menu, please enter an empty line");
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                    break;

                // Need to use string here, since the DisplayEnumerable method takes an IEnumerable<string>
                Stack<string> theStack = new Stack<string>();
                foreach (char c in input)
                {
                    theStack.Push(c.ToString());
                    DisplayEnumerable("The Stack", theStack);
                    Thread.Sleep(35);
                }
                Thread.Sleep(1000);
                Console.WriteLine("The reversed string is: ");
                while (theStack.Count > 0)
                {
                    char c = theStack.Pop()[0];
                    Console.Write(c);
                    DisplayEnumerable("The Stack", theStack);
                    Thread.Sleep(35);
                }
                Console.WriteLine();
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            Console.WriteLine("Please enter +<value> to add to the list or -<value> to remove from the list");
            Console.WriteLine("To exit to the main menu, please enter an empty line");
            List<string> theList = new List<string>();
            do
            {
                string input = Console.ReadLine();
                string[] action = new string[2];
                char nav;
                try
                {
                    nav = input[0];
                    input = input.Substring(1);
                } catch (IndexOutOfRangeException)
                {
                    break;  // Exit do..While loop
                }

                switch (nav) 
                {
                    case '+':
                        theList.Add(input);
                        action = ["Added", "to"];
                        break;
                    case '-':
                        if (theList.Contains(input))
                        {
                            theList.Remove(input);
                            action = ["Removed", "from"];
                        }
                        else
                        {
                            Console.WriteLine($"The list does not contain {input}");
                            continue; // Skip to the next iteration of the loop
                        }
                        break;
                    default:
                        Console.WriteLine("Please use + or - to add or remove from the list");
                        continue; // Skip to the next iteration of the loop
                }
                Console.WriteLine($"{action[0]} {input} {action[1]} the list");
                Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
            } while (true);
            /************************************************************************************
             * Conclution; 
             * 2) As the initial Capacity seems to be 4 (four), the List will expand
             *      as the fifth element is added.
             * 3) The Capacity will double as the list expands, so the next time the capacity is 8 (eight),
             *      then 16 (sixteen), 32 (thirty-two) and so on.
             * 4) Expanding the underlying array at every insertion would not be efficient, since
             *      the array would have to be recreated and copied every time.
             * 5) No, the easiest way to modify the capacity, is the use of List.TrimExcess()
             * 6) It is prefered to use an array when the number of elements is fixed, and no 
             *      resizing will be needed.
             **************************************************************************************/
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Console.WriteLine("Please enter +<value> to add to the queue or - to remove from the queue");
            Console.WriteLine("To exit to the main menu, please enter an empty line");
            Queue<string> theQueue = new Queue<string>();
            char nav;
            string input;
            string[] action = new string[2];
            do
            {
                input = Console.ReadLine();
                try
                {
                    nav = input[0];
                    input = input.Substring(1);
                }
                catch (IndexOutOfRangeException)
                {
                    break;  // Exit do..While loop  
                }
                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(input);
                        action = ["Enqueued", "to"];    
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                        {
                            input = theQueue.Dequeue();
                            action = ["Dequeued", "from"];  
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty, nothing to dequeue");
                            continue; // Skip to the next iteration of the loop
                        }
                        break;  
                }
                Console.WriteLine($"{action[0]} {input} {action[1]} the queue");
                DisplayEnumerable("The Queue", theQueue);
            } while (true);
        }

        static void DisplayEnumerable(string Title, IEnumerable<string> theList)
        {
            Console.Write("\u001b[s");
            for (int i = 0; i < theList.Count() + 4; i++)
            {
                Console.Write($"\u001b[{5+i};48H\u001b[0K");
            }
            Console.WriteLine($"\u001b[5;50H{Title}");
            Console.WriteLine("\u001b[6;50H===================================");
            int line = 7;
            foreach (string item in theList)
            {
                Console.WriteLine($"\u001b[{line++};50H{item}");
            }
            Console.Write("\u001b[u"); // Reset the cursor position
        }       

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Console.WriteLine("Please enter +<value> to add to the stack or - to remove from the stack");
            Console.WriteLine("To exit to the main menu, please enter an empty line");
            Stack<string> theStack = new Stack<string>();
            char nav;
            string input;
            string[] action = new string[2];
            do
            {
                input = Console.ReadLine();
                try
                {
                    nav = input[0];
                    input = input.Substring(1);
                }
                catch (IndexOutOfRangeException)
                {
                    break;  // Exit do..While loop  
                }
                switch (nav)
                {
                    case '+':
                        theStack.Push(input);
                        action = ["Pushed", "onto"];
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            input = theStack.Pop();
                            action = ["Popped", "from"];
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty, nothing to pop");
                            continue; // Skip to the next iteration of the loop
                        }
                        break;
                }
                Console.WriteLine($"{action[0]} {input} {action[1]} the stack");
                DisplayEnumerable("The Stack", theStack);
            } while (true);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            List<char> Opening = new() { '(', '{', '[' };
            List<char> Closing = new() { ')', '}', ']' };

            Console.WriteLine("Please enter a string to check for correct paranthesis");
            string input = Console.ReadLine();
            Stack<char> theStack = new Stack<char>();
            foreach (char c in input)
            {
                if (Opening.Contains(c))
                {
                    theStack.Push(c);
                }
                else if (Closing.Contains(c))
                {
                    if (theStack.Count == 0)
                    {
                        Console.WriteLine("Incorrect paranthesis");
                        return;
                    }
                    char last = theStack.Pop();
                    if (Opening.IndexOf(last) != Closing.IndexOf(c))
                    {
                        Console.WriteLine("Incorrect paranthesis");
                        return;
                    }
                }
            }
            Console.WriteLine("Correct paranthesis");
        }

    }
}

