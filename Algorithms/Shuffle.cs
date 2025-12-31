public class Shuffle
{   

    public static void FisherYates(int[] array)
    {
        Random random = new Random();

        // start at the highest index value and work backwards
        for (int i = array.Length - 1; i > 0; i--)
        {
            // get a random number from 0 - i
            int j = random.Next(i + 1);

            int k = array[i];
            array[i] = array[j];
            array[j] = k;
        }

    }

public static void ShuffleTest()
{
    int[] array = {1,2,3,4,5,6,7,8,9,10};
    int[,] grid = new int[10,10];
    int runs = 1000;

    for(int i = 0; i < runs; i++)
    {
        FisherYates(array);
        for(int k = 0; k < array.Length; k++)
        {
            grid[k, array[k] - 1] += 1;
        }
    }
    
    for(int pos = 0; pos < 10; pos++)
    {
        Console.Write($"{pos}: ");
        for(int val = 0; val < 10; val++)
        {
            Console.Write($"{grid[pos, val],5}");
        }
        Console.WriteLine();
    }
}
}