
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            Console.ForegroundColor = ConsoleColor.Green;

            bool flag = true;
            string StringInput;
            char input;
            List<int> MyList = new List<int>();

            do
            {
                DrawMenu();
                Console.SetCursorPosition(40, Console.CursorTop);

                StringInput = Console.ReadLine().ToLower();

                input = StringInput.Length==0? 't' : StringInput[0];

                switch (input)
                {
                    case 'a':
                        Add(MyList);
                        break;
                    case 'o':
                        Sort(MyList);
                        break;
                    case 'r':
                        Remove(MyList);
                        break;
                    case 'm':
                        DisplayMean(MyList);
                        break;
                    case 'l':
                        DisplayLargest(MyList);
                        break;
                    case 's':
                        DisplaySmallest(MyList);
                        break;
                    case 'f':
                        FindInList(MyList);
                        break;
                    case 'c':
                        ClearList(MyList);
                        break;
                    case 'u':
                        Sum(MyList);
                        break;
                    case 'd':
                        RemoveDuplicates(MyList);
                        break;
                    case 'v':
                        ReverseList(MyList);
                        break;
                    case 'p':
                        PrintList(MyList);
                        break;
                    case 'n':
                        PrintCount(MyList);
                        break;
                    case 't':
                        ListStatus(MyList);
                        break;
                    case 'q':
                        flag = false;
                        break;
                    default:
                        PrintMSG("please enter a valid choice...", true);
                        break;
                }

            } while (flag);


            #endregion

        }


        #region printing
        public static void PrintList(List<int> list)
        {
            if (!Validate(list)) return;

            string result = "[ ";

            foreach (var item in list)
            {
                result += item + " ";
            }
            result += " ]";

            PrintCenter("===========================\n");
            PrintCenter(result + "\n");
            PrintCenter("===========================\n");
        }
        public static void DrawMenu()
        {
            PrintCenter("+-----------------------------------------+\n");
            PrintCenter("|                Main Menu                |\n");
            PrintCenter("+-----------------------------------------+\n");
            PrintCenter("P - Print numbers      A - Add a number\n");
            PrintCenter("O - Sort The List      M - Display mean\n");
            PrintCenter("C - Clear list         L - Display largest\n");
            PrintCenter("F - Find a Number      S - Display smallest\n");
            PrintCenter("R - Remove a Number    U - Sum All Numbers\n");
            PrintCenter("D - Remove Duplicates  V - Reverse List\n");
            PrintCenter("N - List Count         T - List Status\n");
            PrintCenter("Q - Quit\n");

            PrintCenter("Enter choice: \n");
        }
        public static void PrintMSG(string msg, bool IsError)
        {
            if (IsError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            PrintCenter("========================\n");
            PrintCenter($"{msg}...\n");
            PrintCenter("========================\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void PrintCenter(string text)
        {
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.Write(text);
        }

        #endregion

        #region sorting
        public static void Sort(List<int> list)
        {
            if (!Validate(list)) return;

            List<int> sorted = MergeSort(list, 0, list.Count - 1);
            list.Clear();
            list.AddRange(sorted);

            PrintMSG("list sorted successfully...", false);
        }
        public static List<int> Merge(List<int> arr1, List<int> arr2)
        {
            List<int> temp = new List<int>();

            int i = 0, j = 0;

            while (i < arr1.Count && j < arr2.Count)
            {
                if (arr1[i] <= arr2[j])
                {
                    temp.Add(arr1[i]);
                    i++;
                }
                else
                {
                    temp.Add(arr2[j]);
                    j++;
                }
            }

            while (i < arr1.Count)
            {
                temp.Add(arr1[i]);
                i++;
            }
            while (j < arr2.Count)
            {
                temp.Add(arr2[j]);
                j++;

            }


            return temp;
        }
        public static List<int> MergeSort(List<int> arr, int start, int end)
        {
            if (start == end)
            {
                return new List<int> { arr[start] };
            }

            int mid = start + (end - start) / 2;

            List<int> left = MergeSort(arr, start, mid);
            List<int> right = MergeSort(arr, mid + 1, end);

            return Merge(left, right);
        }
        #endregion

        #region listmethods
        public static bool Validate(List<int> list)
        {
            if (list.Count == 0)
            {
                PrintMSG("list is empty...", true);
                return false;
            }
            return true;
        }
        public static void Add(List<int> list)
        {
            PrintCenter("please enter a value to add...\n");
            Console.SetCursorPosition(40, Console.CursorTop);


            int? TemPValue = ReadNumber();
            if (TemPValue == null) return;
            int value = (int)TemPValue;


            list.Add(value);
            PrintMSG($"{value} added successfully...", false);
        }
        public static void ClearList(List<int> list)
        {
            if (!Validate(list)) return;

            list.Clear();
            PrintMSG("list is cleared successfully...", false);
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void FindInList(List<int> list)
        {
            if (!Validate(list)) return;

            PrintCenter("enter a number to find...\n");
            Console.SetCursorPosition(40, Console.CursorTop);

            int? TemPValue = ReadNumber();
            if (TemPValue == null) return;
            int value = (int)TemPValue;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value)
                {
                    PrintMSG($"{value} found in index {i}", false);
                    return;
                }
            }
            PrintMSG($"{value} not found", true);
        }
        public static void DisplayLargest(List<int> list)
        {
            if (!Validate(list)) return;

            int max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }
            PrintMSG($"the largest value is {max}", false);
        }
        public static void DisplaySmallest(List<int> list)
        {
            if (!Validate(list)) return;

            int min = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < min)
                {
                    min = list[i];
                }
            }
            PrintMSG($"the smallest value is {min}", false);
        }
        public static void DisplayMean(List<int> list)
        {
            if (!Validate(list)) return;

            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
            }
            double Avg = (double)result / list.Count;

            PrintMSG($"the average is {Avg} ", false);
        }
        public static void Remove(List<int> list)
        {
            if (!Validate(list)) return;

            PrintCenter("enter a number to remove...\n");
            Console.SetCursorPosition(40, Console.CursorTop);

            int? TemPValue = ReadNumber();
            if (TemPValue == null) return;
            int value = (int)TemPValue;

            if (list.Remove(value))
                PrintMSG($"{value} removed successfully", false);
            else
                PrintMSG($"{value} not found in list", true);
        }
        public static void Sum(List<int> list)
        {
            if (!Validate(list)) return;

            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
            }
            PrintMSG($"sum of list is {result}", false);
        }
        public static void RemoveDuplicates(List<int> list)
        {
            if (!Validate(list)) return;

            HashSet<int> set = new HashSet<int>(list);
            List<int> uniqueList = set.ToList();
            list.Clear();
            list.AddRange(uniqueList);
            PrintMSG("duplicates removed succssefully.. ", false);

        }
        public static void ReverseList(List<int> list)
        {
            if (!Validate(list)) return;

            int temp;
            int i = 0, j = list.Count - 1;

            while (i < j)
            {
                temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                i++;
                j--;

            }
            PrintMSG("list reversed successfully", false);
        }
        public static void PrintCount(List<int> list)
        {
            if (!Validate(list)) return;

            PrintMSG($"list count is {list.Count}", false);
        }

        public static int? ReadNumber()
        {
            bool isValue = int.TryParse(Console.ReadLine(), out int value);

            if (isValue)
                return value;

            PrintMSG("invalid number", true);
            return null;
        }

        public static void ListStatus(List<int> list)
        {
            PrintMSG($"list is empty: {list.Count == 0}", false);
            PrintMSG($"list count: {list.Count}", false);

            if (list.Count > 0)
            {
                PrintMSG($"first item: {list[0]}", false);
                PrintMSG($"last item: {list[list.Count - 1]}", false);
            }

        }




        #endregion



    }

}

