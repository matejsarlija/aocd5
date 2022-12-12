namespace aocd5;

using System.Text.RegularExpressions;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "/home/oxi/Downloads/input.txt";

        Stack<char>[] stacks = new Stack<char>[9];

        for (int i = 0; i < stacks.Length; i++)
        {
            stacks[i] = new Stack<char>();
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {

                if (Char.IsLetter(line[1]))
                {
                    stacks[0].Push(line[1]);
                }

                if (Char.IsLetter(line[5]))
                {
                    stacks[1].Push(line[5]);
                }

                if (Char.IsLetter(line[9]))
                {
                    stacks[2].Push(line[9]);
                }

                if (Char.IsLetter(line[13]))
                {
                    stacks[3].Push(line[13]);
                }

                if (Char.IsLetter(line[17]))
                {
                    stacks[4].Push(line[17]);
                }

                if (Char.IsLetter(line[21]))
                {
                    stacks[5].Push(line[21]);
                }

                if (Char.IsLetter(line[25]))
                {
                    stacks[6].Push(line[25]);
                }

                if (Char.IsLetter(line[29]))
                {
                    stacks[7].Push(line[29]);
                }

                if (Char.IsLetter(line[33]))
                {
                    stacks[8].Push(line[33]);
                }


                if (String.IsNullOrEmpty(line) || line[0] != '[')
                {
                    break;
                }

                WriteLine($"{line} {line.Length}");

            }


            for (int i = 0; i < stacks.Length; i++)
            {

                Stack<char> interimStack = new Stack<char>();

                while(stacks[i].Count > 0)
                {
                    interimStack.Push(stacks[i].Pop());
                }

                stacks[i] = interimStack;
            }

            foreach (var item in stacks)
            {
                foreach (var x in item)
                {
                    Write($"{x}");
                }

                WriteLine();
            }


            //možeš nastaviti dalje sa istom petljom
            while ((line = reader.ReadLine()) != null)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    WriteLine(line);
                    var numbers = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => int.Parse(m.Value)).ToArray();
                    Stackify(numbers[0], stacks[numbers[1]-1], stacks[numbers[2]-1]);

                }
            }

            foreach (var item in stacks)
            {
                foreach (var x in item)
                {
                    Write($"{x}");
                }

                WriteLine();
            }

        }

    }

    private static void Stackify(int x, Stack<char> outStack, Stack<char> inStack)
    {
        Stack<char> interim = new Stack<char>();

        for (int i = 0; i < x; i++)
        {
            var num = outStack.Pop();
            Write($"Pushing {num}");
            interim.Push(num);

        }

        for (int i = 0; i < x; i++)
        {
            var num = interim.Pop();
            Write($"Pushing {num}");
            inStack.Push(num);

        }

        WriteLine();
    }
}
