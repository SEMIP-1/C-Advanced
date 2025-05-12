// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Math Operations Game MOG");
char exit = 'a';
Random myRandom = new Random();
int nRightAnswerCount=0;
int nWrongAnswerCount=0;
int nFirstNumber= 0;
int nSecondNumber= 0;
int nOperator= 0;
while (exit!='e')
{
    //Random Number Initiation 
    bool isRightAnwer = false;
    nFirstNumber= myRandom.Next(0,10);
    nSecondNumber= myRandom.Next(0,10);
    nOperator= myRandom.Next(1,3);
    //Showing First and Second Number 
    Console.WriteLine($"First Number {nFirstNumber}  Second Number {nSecondNumber}");
    switch(nOperator)
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
    //Result Number Read from User 
    int nResult = Convert.ToInt32(Console.ReadLine());
    switch(nOperator)
    {
        case 1:
            isRightAnwer =(nResult==nFirstNumber+nSecondNumber);
            break;
        case 2:
            isRightAnwer =(nResult==nFirstNumber-nSecondNumber);
            break;
        case 3:
            isRightAnwer =(nResult==nFirstNumber*nSecondNumber);
            break;
    }    
    //Result verifcation Process
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
    if (nRightAnswerCount==5)
    {    
        Console.WriteLine("Level Promoted");
    }
    else if(nWrongAnswerCount==3) 
    {    
        Console.WriteLine("Game Over");
        break;//break ===> exit from loop / return ===> exit from function / contenue ===> exit from current ertation and move to next one 
    }
    Console.WriteLine("************************************************************");
    Console.WriteLine("If You Want to Exit Press e");
    exit = Convert.ToChar(Console.ReadLine());
}
