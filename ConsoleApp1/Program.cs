MyArrayMath myArrayMath = new MyArrayMath();

int[] ArrTest = new int[20];
for (int i = 0; i < 20; i++)   
    ArrTest[i] = i;

Console.WriteLine("Work with arrays regular way");
Console.Write("Even numbers: ");
myArrayMath.Print(myArrayMath.getEven(ArrTest));

Console.Write("Odd numbers: ");
myArrayMath.Print(myArrayMath.getOdd(ArrTest));

Console.Write("Simple numbers: ");
myArrayMath.Print(myArrayMath.getSimpleNumbers(ArrTest));

Console.Write("Fibonacci numbers: ");
myArrayMath.Print(myArrayMath.getFibonacci(ArrTest));



Console.WriteLine("\nWork with arrays by delegates");
Console.Write("Even numbers: ");
MyDelegate myDelegate = myArrayMath.getEven;
myArrayMath.Print(myDelegate(ArrTest));

Console.Write("Odd numbers: ");
myDelegate = myArrayMath.getOdd;
myArrayMath.Print(myDelegate(ArrTest));

Console.Write("Simple numbers: ");
myDelegate = myArrayMath.getSimpleNumbers;
myArrayMath.Print(myDelegate(ArrTest));

Console.Write("Fibonacci numbers: ");
myDelegate = myArrayMath.getFibonacci;
myArrayMath.Print(myDelegate(ArrTest));


public delegate int[] MyDelegate(int[] arr);

internal class MyArrayMath
{
    public int[] getEven(int[] arr)
    {
        List<int> temp = new List<int>(arr.Length);
        foreach (int i in arr)
            if (i % 2 == 0) temp.Add(i);
        temp.TrimExcess();
        return temp.ToArray();
    }
    public int[] getOdd(int[] arr)
    {
        List<int> temp = new List<int>(arr.Length);
        foreach (int i in arr)
            if (i % 2 == 1) temp.Add(i);
        temp.TrimExcess();
        return temp.ToArray();
    }
    public int[] getSimpleNumbers(int[] arr)
    {
        List<int> temp = new List<int>(arr.Length);
        bool isSimple = true;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] <= 1) continue;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isSimple = false;
                    break;
                }
            }
            if (isSimple) temp.Add(arr[i]);
            isSimple = true;
        }
        temp.TrimExcess();
        return temp.ToArray();
    }
    public int[] getFibonacci(int[] arr)
    {
        List<int> temp = new List<int>(arr.Length);
        if (arr.Length < 3) return new int[0];
        if (arr[2] == arr[0] + arr[1])
        {
            temp.Add(arr[0]);
            temp.Add(arr[1]);
            temp.Add(arr[2]);
        }

        for (int i = 2; i < arr.Length; i++)
        {
            if (arr[i] == (arr[i - 1] + arr[i - 2]))
            {
                temp.Add(arr[i]);
            }
        }
        temp.TrimExcess();
        return temp.ToArray();
    }

    public void Print(int[] arr)
    {
        String temp = "";
        foreach (int i in arr)
            temp += Convert.ToString(i) + "  ";
        Console.WriteLine(temp);
    }
}















