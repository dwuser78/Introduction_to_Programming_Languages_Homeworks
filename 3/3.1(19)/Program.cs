bool IsPalindrome(string chkStr)
{
    int front_index = 0;
    int back_index = chkStr.Length - 1;

    while(front_index < back_index)
    {
        if (Convert.ToInt32(chkStr[front_index]) != 
            Convert.ToInt32(chkStr[back_index]))
        {
            return false;
        }
   
        front_index++;
        back_index--;
    }
  
    return true;
}

Console.Write("Enter a number: ");
string chkStr = new string(Console.ReadLine());
 
if (IsPalindrome(chkStr))
    Console.WriteLine("Current number is palindrome");
else
    Console.WriteLine("Current number is not a palindrome");