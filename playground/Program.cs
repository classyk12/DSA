using NUnit.Framework;
using System;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.ConstrainedExecution;


public class Program
{
    public static void Main(string[] args)
    {

        Array array = new(Length: 3);
        array.Insert(10);
        array.Insert(20);
        array.Insert(30);
        array.Insert(40);
        array.Remove(20);
        // Console.WriteLine(array.IndexOf(40));
        array.Print();

        // array.Insert(20);
        // array.Insert(30);
        // array.Remove(10);

        // Console.WriteLine(array);
        // Console.WriteLine(array.IndexOf(20));


        // var cb = new CodeBuilder("Person")
        //   .AddField("Name", "string")
        //   .AddField("Age", "int");

        // Console.WriteLine(cb);
        // double speed = CalculateFinalSpeed(60, [0, 30, 0, -45, 0]);
        // // Console.WriteLine(GetDiscountedPrice(12.0, 100.0, DiscountType.Weight));
        // Console.WriteLine(speed);
        // Console.WriteLine(SortedSearch.CountNumbers([1, 3, 5, 7], 4));

        // Console.WriteLine(Access.Writer.HasFlag(Access.Delete));
        // Song first = new Song("Hello");
        // Song second = new Song("Eye of the tiger");

        // first.NextSong = second;
        // second.NextSong = first;

        //  Console.WriteLine(first.IsInRepeatingPlaylist());

        // ConstructionGame game = new ConstructionGame(2, 2);

        // game.AddCubes(new bool[,]
        // {
        //     { true, true },
        //     { false, false }
        // });
        // game.AddCubes(new bool[,]
        // {
        //     { true, true },
        //     { false, true }
        // });
        // Console.WriteLine(game.GetHeight()); // should print 2

        // game.AddCubes(new bool[,]
        // {
        //     { false, false },
        //     { true, true }
        // });
        // Console.WriteLine(game.GetHeight()); // should print 1
    }

    public class ConstructionGame
    {
        private int[,] _cubes;
        private int Length;
        private int Width;
        public ConstructionGame(int length, int width)
        {
            Length = length;
            Width = width;
            _cubes = new int[length, width];
        }

        public void AddCubes(bool[,] cubes)
        {
            int cubeRows = cubes.GetLength(0);
            int cubeCols = cubes.GetLength(1);

            int[] columnHeights = new int[Width];

            for (int j = 0; j < Width; j++)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (cubes[i, j])
                    {
                        columnHeights[j]++;
                    }
                }
            }

            for (int j = 0; j < Width; j++)
            {
                for (int i = 0; i < Length; i++)
                {
                    _cubes[i, j] = columnHeights[j];
                }

            }
        }

        public int GetHeight()
        {
            int maxHeight = 0;
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_cubes[i, j] > maxHeight)
                    {
                        maxHeight = _cubes[i, j];
                    }
                }
            }
            return maxHeight;
        }
    }





    public class Song
    {
        private string name;
        public Song NextSong { get; set; }

        public Song(string name)
        {
            this.name = name;
        }

        public bool IsInRepeatingPlaylist()
        {
            var visitedSongs = new HashSet<Song>();
            Song current = this;

            while (current != null)
            {
                if (visitedSongs.Contains(current))
                {
                    return true;
                }
                visitedSongs.Add(current);
                current = current.NextSong;
            }
            return false;
        }
    }


    public static class UserAccount
    {
        [Flags]
        public enum Access
        {
            Delete = 1 << 0, // 1 (00001)
            Publish = 1 << 1, // 2 (00010)
            Submit = 1 << 2,  // 4 (00100)
            Comment = 1 << 3, // 8 (01000)
            Modify = 1 << 4,  // 16 (10000)

            Writer = Submit | Modify, // 4 | 16 = 20 (10100)
            Editor = Delete | Comment | Publish, // 1 | 8 | 2 = 11 (01011)
            Owner = Writer | Editor  // 20 | 11 = 31 (11111)
        }
    }

    public class SortedSearch
    {
        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            int left = 0;
            int right = sortedArray.Length;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (sortedArray[mid] < lessThan)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }

    [TestFixture]
    public class Tester
    {
        private double epsilon = 1e-6;

        [Test]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            Account account = new(-20);
            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }

        [Test]
        public void WithdrawAndDepositMethodMustAcceptOnlyPositiveNumbers()
        {
            Account account = new(100);
            bool depositresult = account.Deposit(50);
            bool withdrawresult = account.Withdraw(50);
            Assert.True(depositresult);
            Assert.True(withdrawresult);
            Assert.AreEqual(0, account.Balance, epsilon);
        }

        [Test]
        public void AccountCannotOverstepOverdraftLimit()
        {
            Account account = new(100);
            bool result = account.Withdraw(150);
            Assert.AreEqual(false, result);
            Assert.AreEqual(0, account.Balance, epsilon);
        }

        [Test]
        public void WithdrawAndDepositRejectNegetiveNumbers()
        {
            Account account = new(100);
            bool depositresult = account.Deposit(-100);
            bool withdrawalresult = account.Withdraw(-50);
            Assert.AreEqual(false, depositresult);
            Assert.AreEqual(false, withdrawalresult);
            Assert.AreEqual(0, account.Balance, epsilon);
        }

    }


    public class Account
    {
        public double Balance { get; private set; }
        public double OverdraftLimit { get; private set; }

        public Account(double overdraftLimit)
        {
            OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
            Balance = 0;
        }

        public bool Deposit(double amount)
        {
            if (amount >= 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount)
        {
            if ((Balance - amount) >= -OverdraftLimit && amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }


    public static string[] UniqueNames(string[] names1, string[] names2)
    {
        return names1.Concat(names2).Distinct().ToArray();
    }

    public enum DiscountType
    {
        Standard,
        Seasonal,
        Weight
    }

    public static double GetDiscountedPrice(double cartWeight,
                                          double totalPrice,
                                          DiscountType discountType)
    {
        switch (discountType)
        {
            case DiscountType.Standard:
                return totalPrice -= totalPrice * 0.06;

            case DiscountType.Seasonal:
                return totalPrice -= totalPrice * 0.12;

            default:
                if (cartWeight <= 10)
                {
                    return totalPrice -= totalPrice * 0.06;
                }

                return totalPrice -= totalPrice * 0.18;
        }
    }

    public static double CalculateFinalSpeed(double initialSpeed, int[] inclinations)
    {
        double speed = initialSpeed;

        foreach (int angle in inclinations)
        {
            if (angle == 0)
                continue;

            speed = speed -= angle;

            if (speed <= 0)
                return 0;

        }
        return speed;
    }





    public class CodeBuilder
    {
        private readonly string _className;
        private readonly List<(string Type, string Name)> _fields = new();

        public CodeBuilder(string className)
        {
            _className = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            _fields.Add((type, name));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {_className}");
            sb.AppendLine("{");

            foreach (var field in _fields)
            {
                sb.AppendLine($"  public {field.Type} {field.Name};");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}









