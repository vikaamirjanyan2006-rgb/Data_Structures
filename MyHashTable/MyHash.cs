public class MyHash
{

    public static int AdditiveHash(string input)
    {
        int hashValue = 0;
        foreach (char c in input)
            hashValue += c;
        return hashValue;
    }


    public static int MyFoldingHash(string input)
    {
        int hashValue = 0;
        int startIndex = 0;
        int currentFourBytes;

        do
        {
            currentFourBytes = MyGetNextBytes(startIndex, input);
            unchecked
            {
                hashValue += currentFourBytes;
            }
            startIndex += 4;
        } while (currentFourBytes != 0);

        return hashValue;
    }


    public static int MyGetNextBytes(int startIndex, string str)
    {
        int result = 0;
        for (int i = 0; i < 4; i++)
        {
            int charIndex = startIndex + i;
            if (charIndex < str.Length)
                result |= MyGetByte(str, charIndex) << (i * 8);
        }
        return result;
    }

    public static int MyGetByte(string str, int index)
    {
        return str[index] & 0xFF;
    }


    public static int Djb2(string input)
    {
        int hashValue = 5381;
        foreach (char c in input)
            unchecked
            {
                hashValue = ((hashValue << 5) + hashValue) + c;
            }
        return hashValue;
    }
}