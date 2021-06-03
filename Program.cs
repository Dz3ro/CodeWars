using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class Program
    {
        private static void Main(string[] args)
        {
            
        }

        #region CoderByte

        public static string CodelandUsernameValidation(string str)
        {
            var lngthMin = 4;
            var lngthMax = 25;

            var isCorrectLngth = str.Length >= lngthMin && str.Length <= lngthMax;
            var startsWithLetter = Char.IsLetter(str[0]);
            var containsRightMarks = true;

            foreach (var mark in str)
            {
                if (!Char.IsLetterOrDigit(mark) && mark != '_')
                    containsRightMarks = false;
            }
            var notEndsWithUnderscore = str[str.Length - 1] != '_';

            var validated = isCorrectLngth && startsWithLetter && containsRightMarks
                && notEndsWithUnderscore;

            return validated ? "true" : "false";
        }

        public static string FindIntersection(string[] strArr)
        {
            var strElem1 = strArr[0].Split(',');
            var strElem2 = strArr[1].Split(',');

            var intersections = new List<string>();

            foreach (var elem1 in strElem1)
            {
                foreach (var elem2 in strElem2)
                {
                    var el1 = elem1.Trim();
                    var el2 = elem2.Trim();

                    if (el1 == el2)
                        intersections.Add(el1);
                }
            }

            var returnString = String.Join(",", intersections);

            return intersections.Count == 0 ? "false" : returnString;
        }

        public static string QuestionsMarks(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 2 > str.Length)
                    break;

                if (i > str.Length - 3)
                    break;

                if (str[i] == '?' && str[i + 1] == '?' && str[i + 2] == '?')
                {
                    var digitLeft = 'a';
                    var digitRight = 'a';
                    var posFirst = i;
                    var posLast = i + 2;

                    for (int j = posFirst; j >= 0; j--)
                    {
                        if (Char.IsDigit(str[j]))
                        {
                            digitLeft = str[j];
                            break;
                        }
                    }

                    for (int k = posLast; k < str.Length; k++)
                    {
                        if (Char.IsDigit(str[k]))
                        {
                            digitRight = str[k];
                            break;
                        }
                    }

                    if (digitLeft == 'a' || digitRight == 'a')
                        continue;

                    if (Convert.ToByte(digitLeft.ToString()) + Convert.ToInt16(digitRight.ToString()) <= 10)
                        return "true";
                }
            }
            return "false";
        }

        public static string LongestWord(string sen)
        {
            var longestWordLength = 0;
            var longestWordPos = 0;
            for (int i = 0; i < sen.Length; i++)
            {
                var wordLength = 0;
                if (Char.IsLetter(sen[i]) || Char.IsDigit(sen[i]))
                    for (int j = i; j < sen.Length; j++)
                    {
                        if (Char.IsLetter(sen[j]) || Char.IsDigit(sen[j]))
                        {
                            wordLength++;
                        }
                        if (!Char.IsLetter(sen[j]) && !Char.IsDigit(sen[j]))
                            break;
                    }
                if (wordLength > longestWordLength)
                {
                    longestWordLength = wordLength;
                    longestWordPos = i;
                }
            }

            return sen.Substring(longestWordPos, longestWordLength);
        }

        public static int FirstFactorial(int num)
        {
            var myNum = 1;

            for (int i = num; i > 0; i--)
                myNum *= i;

            return myNum;
        }

        public static string FirstReverse(string str)
        {
            var myString = "";

            for (int i = str.Length - 1; i >= 0; i--)
                myString += str[i];

            return myString;
        }

        #endregion CoderByte

        #region CodeWars

        public static int DigitalRoot(long n)
        {
            var str = n.ToString();
            var total = 0;

            do
            {
                if (total != 0)
                {
                    str = total.ToString();
                    total = 0;
                }
                foreach (var x in str)
                {
                    total += Convert.ToByte(x.ToString());
                }
            } while (total > 9);

            return total;
        }

        public static bool IsIsogram(string str)
        {
            str = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (str[i] == str[j])
                        return false;
                }
            }
            return true;
        }

        public static int find_it(int[] seq)
        {
            var dist = seq.Distinct();

            foreach (var nr in dist)
            {
                var counter = seq.Count(a => a == nr);
                if (counter % 2 != 0)
                    return nr;
            }
            return -1;
        }

        public static string SongDecoder(string input)
        {
            var key = "WUB";
            var notDecoded = input.Contains(key);

            while (notDecoded)
            {
                var pos = input.IndexOf(key);
                input = input.Insert(pos, " ");
                input = input.Remove(pos + 1, key.Length);
                notDecoded = input.Contains(key);
            }
            input = input.Trim();
            while (input.Contains("  "))
            {
                var pos = input.IndexOf("  ");
                input = input.Remove(pos, 1);
            }
            return input;
        }

        public int GetSum(int a, int b)
        {
            if (a == b)
                return a;

            var min = Math.Min(a, b);
            var max = Math.Max(a, b);
            var value = 0;

            for (int i = min; i <= max; i++)
                value += i;

            return value;
        }

        public static int DuplicateCount(string str)
        {
            str = str.ToLower();
            var duplicates = new List<char>();
            var counter = 0;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i == j)
                        continue;

                    if (str[i] == str[j] && !duplicates.Contains(str[i]))
                    {
                        counter++;
                        duplicates.Add(str[i]);
                    }
                }
            }
            return counter;
        }

        public static int DuplicateCount2(string str)
        {
            str = str.ToLower();
            var duplicates = str.GroupBy(c => c).Where(g => g.Count() > 1);
            return duplicates.Count();
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var list = iterable.ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                if (i >= list.Count() - 1)
                    break;
                if (list[i].Equals(list[i + 1]))
                {
                    list.RemoveAt(i + 1);
                    i--;
                }
            }

            return list;
        }

        public static IEnumerable<T> UniqueInOrder2<T>(IEnumerable<T> iterable)
        {
            T previous = default(T);

            foreach (var current in iterable)
            {
                if (!current.Equals(previous))
                {
                    previous = current;
                    yield return current;
                }
            }
        }

        public static bool comp(int[] a, int[] b)
        {
            if (a == null || b == null)
                return false;

            var orderedA = a.OrderByDescending(x => x).ToList();
            var orderedB = b.OrderByDescending(x => x);
            var counter = 0;

            foreach (var numB in orderedB)
            {
                foreach (var numA in orderedA)
                {
                    if (Math.Sqrt(numB) == numA)
                    {
                        counter++;
                        orderedA.Remove(numA);
                        break;
                    }
                }
            }
            return counter == orderedB.Count();
        }

        public static bool comp2(int[] a, int[] b)
        {
            if ((a == null) || (b == null))
                return false;

            int[] copy = a.Select(x => x * x).ToArray();
            Array.Sort(copy);
            Array.Sort(b);

            return copy.SequenceEqual(b);
        }

        public static int GetUnique(IEnumerable<int> numbers)
        {
            var z = numbers.GroupBy(x => x).Where(a => a.Count() == 1).First();
            return z.Key;
        }

        public static int GetUnique2(IEnumerable<int> numbers)
        {
            return numbers.GroupBy(x => x).Single(x => x.Count() == 1).Key;
        }

        public static bool IsValidWalk(string[] walk)
        {
            var w = walk.Where(x => x == "w").Count();
            var n = walk.Where(x => x == "n").Count();
            var e = walk.Where(x => x == "e").Count();
            var s = walk.Where(x => x == "s").Count();

            var value = n == s && w == e;
            return walk.Count() == 10 && value;
        }

        public static string Order(string words)
        {
            var arr = words.Split(' ');
            var arrOrdered = new string[arr.Length];

            foreach (var word in arr)
            {
                foreach (var letter in word)
                {
                    if (Char.IsDigit(letter))
                    {
                        var num = byte.Parse(letter.ToString());
                        arrOrdered[num - 1] = word;
                    }
                }
            }
            var value = String.Join(" ", arrOrdered);

            return value;
        }

        public static string Order2(string words)
        {
            var arr = words.Split(' ')
                .OrderBy(x => x.ToList().Find(z => Char.IsDigit(z)));

            return String.Join(" ", arr);
        }

        public static List<string> Wave(string str)
        {
            var list = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                var x = str.ToCharArray();
                if (Char.IsWhiteSpace(x[i]))
                    continue;

                x[i] = Char.ToUpper(x[i]);
                var joined = String.Join("", x);
                list.Add(joined);
            }
            return list;
        }

        public static int[] Snail(int[][] array)
        {
            var dir = 0;
            var len = array.Length;
            bool[,] intAdded = new bool[len, len];
            var posX = 0;
            var posY = 0;
            var list = new List<int>();
            var amount = Math.Pow(len, 2);

            for (int i = 0; i < amount; i++)
            {
                list.Add(array[posY][posX]);
                intAdded[posX, posY] = true;

                if ((dir == 0 && posX == len - 1) || (dir == 0 && intAdded[posX + 1, posY]))
                    dir = 1;
                else if ((dir == 1 && posY == len - 1) || (dir == 1 && intAdded[posX, posY + 1]))
                    dir = 2;
                else if ((dir == 2 && posX == 0) || (dir == 2 && intAdded[posX - 1, posY]))
                    dir = 3;
                else if ((dir == 3 && posY == 0) || (dir == 3 && intAdded[posY - 1, posY]))
                    dir = 0;

                if (dir == 0) posX++;
                else if (dir == 1) posY++;
                else if (dir == 2) posX--;
                else if (dir == 3) posY--;
            }

            return list.ToArray();
        }

        public static int SumIntervals((int, int)[] intervals)
        {
            if (intervals.Length == 0)
                return 0;

            var value = 0;
            var maxTop = intervals.OrderByDescending(x => x).Last().Item2;
            intervals = intervals.OrderBy(x => x.Item1).ToArray();

            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i].Item2 < maxTop)
                    continue;
                if (i == intervals.Length - 1)
                {
                    value += intervals[i].Item2 - intervals[i].Item1;
                    break;
                }
                var x = intervals[i].Item2;
                var ahead = 1;
                var z = intervals[i + ahead].Item1;

                while (x > z && intervals[i + ahead].Item2 > x && i + ahead < intervals.Length && intervals[i].Item1 < intervals[i + ahead].Item2)
                {
                    intervals[i].Item2 = intervals[i + ahead].Item2;
                    intervals[i + ahead].Item1 = 0;
                    intervals[i + ahead].Item2 = 0;
                    x = intervals[i].Item2;
                    ahead++;
                    if (i + ahead > intervals.Length - 1)
                        ahead = 1;
                    z = intervals[i + ahead].Item1;
                }
                maxTop = intervals[i].Item2 > maxTop ? intervals[i].Item2 : maxTop;
                value += intervals[i].Item2 - intervals[i].Item1;
            }
            return value;
        }

        public static string FirstNonRepeatingLetter(string s)
        {
            if (s.Length == 0) return String.Empty;
            if (s.Length == 1) return s;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    var let1 = s[i].ToString().ToLower();
                    var let2 = s[j].ToString().ToLower();

                    if (j == i) continue;
                    if (let1 == let2) break;
                    if (let1 != let2 && j == s.Length - 1)
                        return s[i].ToString();
                }
            }
            return String.Empty;
        }

        public static string FirstNonRepeatingLetter2(string s)
        {
            if (s.Length == 0) return String.Empty;
            if (s.Length == 1) return s;

            var x = s.GroupBy(char.ToLower).Where(g => g.Count() == 1);

            if (x.Count() == 0) return String.Empty;

            var letter = x.FirstOrDefault().Key;
            var has = s.Contains(letter);
            letter = has ? letter : Char.ToUpper(letter);

            return letter.ToString();
        }

        public static string DoneOrNot(int[][] board)
        {
            var boardRows = new List<int[]>();
            var boardCols = new List<int[]>();
            var boardRegs = new List<int[]>();

            for (int i = 0; i < 9; i++)
                boardRows.Add(board[i]);

            for (int i = 0; i < 9; i++)
            {
                var col = new int[9];
                for (int j = 0; j < 9; j++)
                    col[j] = board[j][i];
                boardCols.Add(col);
            }

            var startX = 0;
            var startY = 0;

            for (int l = 0; l < 9; l++)
            {
                var reg = new int[9];
                var h = 0;

                for (int i = 0 + startX; i < 3 + startX; i++)
                {
                    for (int j = 0 + startY; j < 3 + startY; j++)
                    {
                        reg[h] = boardRows[i][j];
                        h++;
                    }
                }

                boardRegs.Add(reg);
                startX += 3;

                if (startX > 6)
                {
                    startX = 0;
                    startY += 3;
                }
            }

            foreach (var x in boardRows)
                if (x.Count() != x.Distinct().Count())
                    return "Try again!";

            foreach (var x in boardCols)
                if (x.Count() != x.Distinct().Count())
                    return "Try again!";

            foreach (var x in boardRegs)
                if (x.Count() != x.Distinct().Count())
                    return "Try again!";

            return "Finished!";
        }

        public static string WhoIsNext3(string[] names, long n)
        {
            var list = names.ToList();
            var name = "";
            for (int i = 0; i < n; i++)
            {
                name = list[0];
                list.Add(list[0]);
                list.Add(list[0]);
                list = list.Skip(1).ToList();
            }
            return name;
        }

        public static string WhoIsNext2(string[] names, long n)
        {
            var list = names.ToList();

            for (int i = 0; i < n; i++)
            {
                list.Add(list[0]);
                list.Add(list[0]);

                for (int j = 0; j < names.Length; j++)
                {
                    if (j + 1 == names.Length)
                        break;

                    names[j] = names[j + 1];
                }
                list.RemoveAt(list.Count() - 1);
            }
            return list[0];
        }

        public static string WhoIsNext4(string[] names, long n)
        {
            var list = names.ToList();
            var name = "";
            for (int i = 0; i < n; i++)
            {
                name = list[0 + i];
                list.Add(name);
                list.Add(name);
            }
            return list[-1 + (int)n];
        }

        public static string WhoIsNext(string[] names, long n)
        {
            n -= 1;
            while (n > names.Length)
                n = (long)Math.Floor((float)(n - names.Length) / 2);
            return names[n];
        }

        public static string Mix(string s1, string s2)
        {
            var groupedS1 = s1.GroupBy(x => x).Where(x => x.Count() > 1 &&
            Char.IsLetterOrDigit(x.Key)).OrderByDescending(x => x.Count());
            var groupedS2 = s2.GroupBy(x => x).Where(x => x.Count() > 1 &&
            Char.IsLetterOrDigit(x.Key)).OrderByDescending(x => x.Count());

            var str = String.Empty;
            var maxCount = groupedS1.First().Count() > groupedS2.First().Count() ?
                groupedS1.First().Count() : groupedS2.First().Count();
            var minCount = groupedS1.Last().Count() > groupedS2.Last().Count() ?
                groupedS2.Last().Count() : groupedS1.Last().Count();

            var lis1 = groupedS1.ToList();
            var lis2 = groupedS2.ToList();

            for (int i = maxCount; i >= minCount; i--)
            {
                while (lis1.Where(x => x.Count() == i).Count() > 0 || lis2.Where(x => x.Count() == i).Count() > 0)
                {
                    var z1 = lis1.FirstOrDefault(x => x.Count() == i);
                    var z2 = lis2.FirstOrDefault(x => x.Count() == i);

                    var l1 = z1 == null ? String.Empty : z1.Key.ToString();
                    var l2 = z2 == null ? String.Empty : z2.Key.ToString();

                    if (lis2.Exists(x => x.Key.ToString() == l1 && x.Count() == i))
                    {
                        z2 = lis2.First(x => x.Key.ToString() == l1);
                        l2 = z2.Key.ToString();
                    }

                    if (lis1.Exists(x => x.Key.ToString() == l2 && x.Count() == i))
                    {
                        z1 = lis1.First(x => x.Key.ToString() == l1);
                        l1 = z1.Key.ToString();
                    }

                    var strX = String.Empty;
                    var lX = String.Empty;

                    if (l1 != String.Empty && l1 == l2)
                    {
                        strX += "=:";
                        lX = l1;
                        lis1.Remove(z1);
                        lis2.Remove(z2);
                    }
                    else if (l1 != String.Empty)
                    {
                        strX += "1:";
                        lX = l1;
                        lis1.Remove(z1);

                        if (lis2.Exists(x => x.Key.ToString() == l1))
                            lis2.Remove(lis2.First(x => x.Key.ToString() == l1));
                    }
                    else if (l2 != String.Empty)
                    {
                        strX += "2:";
                        lX = l2;
                        lis2.Remove(z2);

                        if (lis1.Exists(x => x.Key.ToString() == l2))
                            lis1.Remove(lis1.First(x => x.Key.ToString() == l2));
                    }
                    str += strX;
                    for (int j = 0; j < i; j++)
                        str += lX;
                    str += "/";
                }
            }
            str = str.Remove(str.Length - 1);

            var hmm = str.Split('/');
            hmm = hmm.OrderByDescending(x => x.Length)
                .ThenBy(x => x.Substring(0, 1)).ThenBy(x => x.Substring(x.Length - 1, 1)).ToArray();

            var ordered = false;

            while (!ordered)
            {
                for (int i = 0; i < hmm.Length - 1; i++)
                {
                    if (hmm[i].Length == hmm[i + 1].Length &&
                        (hmm[i].Substring(0, 1) == "=" && hmm[i + 1].Substring(0, 1) == "1") ||
                        (hmm[i].Substring(0, 1) == "=" && hmm[i + 1].Substring(0, 1) == "2"))
                    {
                        var temp = hmm[i];
                        hmm[i] = hmm[i + 1];
                        hmm[i + 1] = temp;
                    }
                }

                for (int i = 0; i < hmm.Length - 1; i++)
                {
                    if (hmm[i].Length == hmm[i + 1].Length &&
                        (hmm[i].Substring(0, 1) == "=" && hmm[i + 1].Substring(0, 1) == "1") ||
                        (hmm[i].Substring(0, 1) == "=" && hmm[i + 1].Substring(0, 1) == "2"))
                    {
                        ordered = false;
                        break;
                    }
                    if (i == hmm.Length - 2)
                        ordered = true;
                }
            }
            var str2 = String.Join("/", hmm);
            return str2;
        }

        public static List<string> Top3(string s)
        {
            s = s.Trim();
            var arr = s.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                if (!arr[i].Any(char.IsLetterOrDigit))
                {
                    arr[i] = null;
                    continue;
                }

                arr[i] = arr[i].ToLower();
                var lastMark = arr[i].Substring(arr[i].Length - 1);
                var lastChar = lastMark.ToCharArray()[0];
                var firstMark = arr[i].Substring(0, 1);
                var firstChar = firstMark.ToCharArray()[0];

                while (!Char.IsLetterOrDigit(lastChar) || !Char.IsLetterOrDigit(firstChar))
                {
                    if (!Char.IsLetterOrDigit(lastChar))
                    {
                        arr[i] = arr[i].Substring(0, arr[i].Length - 1);
                        lastMark = arr[i].Substring(arr[i].Length - 1);
                        lastChar = lastMark.ToCharArray()[0];
                    }

                    if (!Char.IsLetterOrDigit(firstChar))
                    {
                        arr[i] = arr[i].Substring(1, arr[i].Length - 1);
                        firstMark = arr[i].Substring(0, 1);
                        firstChar = firstMark.ToCharArray()[0];
                    }
                }
            }

            var grouped = arr.GroupBy(x => x);
            var filtered = grouped.Where(x => x.Key != null).OrderByDescending(x => x.Count()).Take(3);
            var value = new List<string>();

            foreach (var word in filtered)
                value.Add(word.Key);

            return value;
        }

        public static string FormatDuration(int seconds)
        {
            if (seconds == 0)
                return "now";

            var data = new Tuple<int, string>[5];

            var years = (int)Math.Floor((float)seconds / 31536000);
            seconds -= years * 31536000;
            var days = (int)Math.Floor((float)seconds / 86400);
            seconds -= days * 86400;
            var hours = (int)Math.Floor((float)seconds / 3600);
            seconds -= hours * 3600;
            var minutes = (int)Math.Floor((float)seconds / 60);
            seconds -= minutes * 60;
            var str = String.Empty;
            data[0] = new Tuple<int, string>(years, "year");
            data[1] = new Tuple<int, string>(days, "day");
            data[2] = new Tuple<int, string>(hours, "hour");
            data[3] = new Tuple<int, string>(minutes, "minute");
            data[4] = new Tuple<int, string>(seconds, "second");

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Item1 == 0)
                    continue;

                if (str != String.Empty)
                    str += ", ";
                str += data[i].Item1 + " ";
                str += data[i].Item2;

                if (data[i].Item1 > 1)
                    str += "s";
            }

            var pos = str.LastIndexOf(",");

            if (pos == -1)
                return str;

            str = str.Insert(pos, " and");
            str = str.Remove(pos + 4, 1);

            return str;
        }

        public static bool ValidateSudokuSolution(int[][] board)
        {
            var rows = new List<int[]>();
            var columns = new List<int[]>();
            var grids = new List<int[]>();

            for (int i = 0; i < 9; i++)
                rows.Add(board[i]);
            for (int i = 0; i < 9; i++)
            {
                var arr = new int[9];
                for (int j = 0; j < 9; j++)
                    arr[j] = board[j][i];
                columns.Add(arr);
            }

            var startPointX = 0;
            var startPointY = 0;

            for (int k = 0; k < 9; k++)
            {
                var arr = new int[9];
                var nr = 0;
                for (int i = 0 + startPointX; i < 3 + startPointX; i++)
                {
                    for (int j = 0 + startPointY; j < 3 + startPointY; j++)
                    {
                        arr[nr] = board[i][j];
                        nr++;
                    }
                }
                grids.Add(arr);
                startPointX += 3;

                if (startPointX > 6)
                {
                    startPointX = 0;
                    startPointY += 3;
                }
            }
            var zeroExists = false;
            var numsRepeat = false;

            foreach (var row in rows)
            {
                if (row.Where(x => x == 0).Count() > 0)
                    zeroExists = true;
                if (row.Distinct().Count() != 9)
                    numsRepeat = true;
            }

            foreach (var col in columns)
            {
                if (col.Where(x => x == 0).Count() > 0)
                    zeroExists = true;
                if (col.Distinct().Count() != 9)
                    numsRepeat = true;
            }

            foreach (var gr in grids)
            {
                if (gr.Where(x => x == 0).Count() > 0)
                    zeroExists = true;
                if (gr.Distinct().Count() != 9)
                    numsRepeat = true;
            }
            var ahi = "ahi";
            return !(zeroExists || numsRepeat);
        }

        public static int TrailingZeros(int n)
        {
            var x = 1;

            for (int i = 1; i <= n; i++)
                x *= i;

            var amount = 0;
            var str = x.ToString();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] != '0')
                    break;
                amount++;
            }
            return amount;
        }

        public static string OrderWeight(string strng)
        {
            var numbers = strng.Split(' ');
            var arr = new Tuple<string, int>[numbers.Length];
            var str = String.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                var weight = numbers[i];
                var weightStr = weight.ToString();
                var weightCoded = 0;

                foreach (var x in weightStr)
                {
                    var nr = Convert.ToInt16((x.ToString()));
                    weightCoded += nr;
                }
                arr[i] = Tuple.Create(weight, weightCoded);
            }

            var ordered = arr.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToArray();

            for (int i = 0; i < ordered.Count(); i++)
                str += ordered[i].Item1 + " ";

            var final = str.Substring(0, str.Length - 1);

            return final;
        }

        public static double Evaluate(string expression)
        {
            expression = expression.Replace(" ", String.Empty);
            Console.WriteLine(expression);

            while (expression.Contains('*') || expression.Contains('/'))
            {
                for (int i = 1; i < expression.Length - 1; i++)
                {
                    var nr1 = expression[i - 1];
                    var nr2 = expression[i + 1];

                    if (expression[i] == '*')
                    {
                        var value1 = Convert.ToInt16(nr1.ToString()) * Convert.ToInt16(nr2.ToString());
                        expression = expression.Insert(i - 1, value1.ToString());
                        expression = expression.Remove(i, 3);
                        break;
                    }
                    else if (expression[i] == '/')
                    {
                        var value1 = Convert.ToDouble(nr1.ToString()) / Convert.ToInt16(nr2.ToString());
                        expression = expression.Insert(i - 1, value1.ToString());
                        expression = expression.Remove(i, 3);
                        break;
                    }
                }
            }

            var value = (int)expression[0];
            var sign = '+';

            for (int i = 1; i < expression.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var nr = Convert.ToInt16(expression[i].ToString());
                    if (sign == '+')
                    {
                        value += nr;
                    }
                    else if (sign == '+')
                    {
                        value -= nr;
                    }
                }
                if (i % 2 == 1)
                    sign = expression[i];
            }

            Console.WriteLine(expression);
            Console.WriteLine(value);
            return 0.0;
        }

        public static string Tickets(int[] peopleInLine)
        {
            var bills25 = 0;
            var bills50 = 0;
            var bills100 = 0;

            for (int i = 0; i < peopleInLine.Length; i++)
            {
                var bill = peopleInLine[i];

                if (bill == 100) bills100++;
                else if (bill == 50) bills50++;
                else if (bill == 25) bills25++;

                bill -= 25;

                while (bill > 0)
                {
                    if (bill >= 50 && bills50 > 0)
                    {
                        bills50--;
                        bill -= 50;
                    }
                    else if (bill >= 25)
                    {
                        bills25--;
                        bill -= 25;
                    }
                }
                if (bills25 < 0)
                    return "NO";
            }
            return "YES";
        }

        public static long NextSmaller(long n)
        {
            var str = n.ToString().ToArray();

            if (n >= 0 && n <= 20)
                return -1;

            var x = 0;
            var y = 0;
            var largestY = 0;

            for (int i = str.Length - 2; i >= 0; i--)
            {
                if (str[i] > str[i + 1])
                {
                    x = i;
                    break;
                }
            }
            for (int i = x + 1; i < str.Length - 1; i++)
            {
                if (str[i] < str[x] && str[i] > largestY)
                {
                    y = i;
                    largestY = str[i];
                }
            }
            var temp = str[x];
            str[x] = str[y];
            str[y] = temp;

            for (int i = y + 1; i < str.Length - 1; i++)
            {
                for (int j = y + 1; j < str.Length - 1; j++)
                {
                    if (i == j) continue;
                    if (str[i] < str[j])
                    {
                        var temp1 = str[i];
                        str[i] = str[j];
                        str[j] = temp1;
                    }
                }
            }

            var finalStr = "";

            foreach (var c in str)
                finalStr += c;

            if (finalStr[0] == '0')
                return -1;

            return Convert.ToInt64(finalStr);
        }

        public static string Encode(string s, int n)
        {
            var arr = new char[s.Length, n];
            var str = "";
            var goingDown = true;
            var curX = 0;
            var curY = 0;

            for (int i = 0; i < s.Length; i++)
            {
                arr[curX, curY] = s[i];

                if (curY + 1 == n)
                    goingDown = false;
                else if (curY == 0)
                    goingDown = true;

                curX++;

                if (goingDown)
                    curY++;
                else if (!goingDown)
                    curY--;
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < s.Length; j++)
                    str += arr[j, i];

            str = str.Replace("\0", string.Empty);
            return str;
        }

        public static string Decode(string s, int n)
        {
            var arr = new char[s.Length, n];
            var str = "";
            var goingDown = true;
            var curX = 0;
            var curY = 0;

            for (int i = 0; i < s.Length; i++)
            {
                arr[curX, curY] = s[i];

                if (curY + 1 == n)
                    goingDown = false;
                else if (curY == 0)
                    goingDown = true;

                curX++;

                if (goingDown)
                    curY++;
                else if (!goingDown)
                    curY--;
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < s.Length; j++)
                    str += arr[j, i];

            str = str.Replace("\0", string.Empty);
            return str;
        }

        #endregion CodeWars
    }
}