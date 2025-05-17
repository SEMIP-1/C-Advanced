// See https://aka.ms/new-console-template for more information
namespace MathOperationGame
{ 
    public struct MathOperator
    {
        public int nFirstNumber;
        public int nSecondNumber;
        public int nOperator;
    }
    class Program
    {
        public static MathOperator GetNextNumber()
        {
            MathOperator CurrentNumbers;
            Random myRandom = new Random();
            CurrentNumbers.nFirstNumber= myRandom.Next(0,10);
            CurrentNumbers.nSecondNumber= myRandom.Next(0,10);
            CurrentNumbers.nOperator= myRandom.Next(1,4);
            return CurrentNumbers;
        }
        public static void PrintOperation(MathOperator CurrentNumbers)
        {
            switch(CurrentNumbers.nOperator)
                {
                    case 1:
                        Console.WriteLine("Operation is Sumation");
                        break;
                    case 2:
                        Console.WriteLine("Operation is Subtraction");
                        break;
                    case 3:
                        Console.WriteLine("Operation is Multiplication");
                        break;
                }
            Console.WriteLine("************************************************************");
        }
        public static bool CheckResult(MathOperator CurrentNumbers,int nResult)
        {
            bool isRightAnwer=false;
            switch(CurrentNumbers.nOperator)
                {
                    case 1:
                        isRightAnwer =(nResult==CurrentNumbers.nFirstNumber+CurrentNumbers.nSecondNumber);
                        break;
                    case 2:
                        isRightAnwer =(nResult==CurrentNumbers.nFirstNumber-CurrentNumbers.nSecondNumber);
                        break;
                    case 3:
                        isRightAnwer =(nResult==CurrentNumbers.nFirstNumber*CurrentNumbers.nSecondNumber);
                        break;
                }
            return isRightAnwer;    
        }
        public static void PrintResult(bool isRightAnwer,int nRightAnswerCount,int nWrongAnswerCount)
        {
            if (isRightAnwer)
                {    
                    Console.WriteLine("The answer is Correct");
                    nRightAnswerCount++;
                }
                else 
                {    
                    Console.WriteLine("The answer is Wrong");
                    nWrongAnswerCount++;
                }
        }
        public static void CheckAnswerCount(int nRightAnswerCount,int nWrongAnswerCount,out bool isBreak)
        {
            isBreak=false;
            if (nRightAnswerCount==5)
            {    
                Console.WriteLine("Level Promoted");
                isBreak=false;
            }
            else if(nWrongAnswerCount==3) 
            {    
                Console.WriteLine("Game Over");
                isBreak=true;
                //break ===> exit from loop / return ===> exit from function / contenue ===> exit from current ertation and move to next one 
            }
            Console.WriteLine("************************************************************");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Math Operations Game MOG");
            char exit = 'a';
            MathOperator CurrentNumbers=GetNextNumber();
            int nRightAnswerCount=0;
            int nWrongAnswerCount=0;
            while (exit!='e')
            {
                //Showing First and Second Number 
                Console.WriteLine($"First Number {CurrentNumbers.nFirstNumber}  Second Number {CurrentNumbers.nSecondNumber}");
                PrintOperation(CurrentNumbers);
                //***********************************************************   
                //Result Number Read from User 
                int nResult = Convert.ToInt32(Console.ReadLine());
                bool isRightAnwer=CheckResult(CurrentNumbers,nResult);
                //***********************************************************   
                //Result verifcation Process
                PrintResult( isRightAnwer, nRightAnswerCount, nWrongAnswerCount);
                //***********************************************************   
                bool isBreak=false;
                CheckAnswerCount(nRightAnswerCount, nWrongAnswerCount,out isBreak);
                if(isBreak)
                    break;
                //***********************************************************   
                Console.WriteLine("If You Want to Exit Press e");
                exit = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
