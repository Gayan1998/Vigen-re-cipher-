//Store alphabet in a char dictonary
Dictionary<char, int> alphabet = new Dictionary<char, int>() { { 'a', 0 },{'b',1 },{ 'c', 2 },
    { 'd', 3 }, { 'e', 4 }, { 'f', 5 },{ 'g', 6 },{ 'h', 7 },{ 'i', 8 },{ 'j', 9 },{ 'k', 10 },{ 'l', 11},
    { 'm', 12},{ 'n', 13 },{ 'o', 14 },{ 'p', 15 },{ 'q', 16 },{ 'r', 17 },{ 's', 18 },{ 't', 19 },{ 'u', 20 },
    { 'v', 21 },{ 'w', 22 },{ 'x', 23 },{ 'y', 24 },{ 'z', 25 }
};
Console.WriteLine("Do you want to encrypt or decrypt ?");
Console.WriteLine("press 1 to encrypt. Press 2 to decrypt.");
int res = int.Parse(Console.ReadLine());

if (res == 1)
{
    encrypt();
}
else if (res == 2)
{
    decrypt();
}

void decrypt()
{
    // get user input
    Console.WriteLine("Enter the encrypted message : ");
    string message = Console.ReadLine();
    // convert user message to a char array
    char[] messageArry = message.ToCharArray();

    // get key from user
    Console.WriteLine("Enter the key : ");
    string key = Console.ReadLine();
    // convert key to a char array
    char[] keyArray = key.ToCharArray();

    // make second dictionary for store message with key
    char[] keyArry = new char[messageArry.Length];

    int count = keyArray.Length;
    int incriment = 0;
    for (int i = 0; i < messageArry.Length; i++)
    {
        if (alphabet.ContainsKey(messageArry[i]))
        {
            if (incriment == count)
            {
                incriment = 0;
            }
            char keyChar = keyArray[incriment];
            keyArry[i] = keyChar;
            incriment++;
        }
    }

    for (int i =0; i<messageArry.Length;i++)
    {
        if (alphabet.ContainsKey(messageArry[i]))
        {
            int val1 = alphabet[messageArry[i]];
            int val2 = alphabet[keyArry[i]];
            int sum = val1 - val2;
            if (sum < 0)
            {
                sum = 26 - Math.Abs(sum);
            }
            char encryptedChar = alphabet.FirstOrDefault(x => x.Value == sum).Key;
            Console.Write(encryptedChar);
        }
        else
        {
            Console.Write(messageArry[i]);
        }
    }
}

void encrypt()
{
    // get user input
    Console.WriteLine("Enter the message : ");
    string message = Console.ReadLine();
    // convert user message to a char array
    char[] messageArry = message.ToCharArray();

    // get key from user
    Console.WriteLine("Enter the key : ");
    string key = Console.ReadLine();
    // convert key to a char array
    char[] keyArray = key.ToCharArray();

    // make second dictionary for store message with key
    char[] keyArry = new char[messageArry.Length];

    int count = keyArray.Length;
    int incriment = 0;
    for (int i = 0; i < messageArry.Length; i++)
    {
        if (alphabet.ContainsKey(messageArry[i]))
        {
            if (incriment == count)
            {
                incriment = 0;
            }
            char keyChar = keyArray[incriment];
            keyArry[i] = keyChar;
            incriment++;
        }
    }


    for (int i = 0; i < messageArry.Length; i++)
    {
        if (alphabet.ContainsKey(messageArry[i]))
        {
            int val1 = alphabet[messageArry[i]];
            int val2 = alphabet[keyArry[i]];
            int sum = val1 + val2;
            if (sum > 26)
            {
                sum = sum - 26;
            }
            char encryptedChar = alphabet.FirstOrDefault(x => x.Value == sum).Key;
            Console.Write(encryptedChar);
        }
        else
        {
            Console.Write(messageArry[i]);
        }
    }
}