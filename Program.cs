using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

static class Extend
{
    public static Tres MostCommon<Tsrc, Tres>(this IEnumerable<Tsrc> source, Func<Tsrc, Tres> transform)
    {
        return source.GroupBy(s => transform(s)).OrderByDescending(g => g.Count()).First().Key;
    }
}

class Team
{
    public virtual string? Name { get; set; }
    public virtual int TotalMambers { get; set; }
    public Team(int totalMambers, string name)
    {
        TotalMambers = totalMambers;
        Name = name;
    }
    public Team() { }
    public int AddMember(int NewMmebers)
    {
        return NewMmebers + this.TotalMambers;
    }
}
class SubTeam : Team
{
    public override string? Name { get; set; }
    public override int TotalMambers { get; set; }
    public SubTeam()
    {
        Name = base.Name;
        TotalMambers = base.TotalMambers;
    }
    public string ChangeName(string name)
    {
        return this.Name = name;
    }
}

public class wordplayer
{
    /// <summary>
    /// Serialize from Json -> "Student":"{"Name":"Austin","Level":"Senior Developer"}","Department":"Optimization"
    /// </summary>
    public static void ParsejsonFile(string[] args)
    {

    }

    /// <summary>
    /// HighestOccuring digit saved in 2 dmesional Array sorted by no. of occcurences
    /// </summary>
    public static void HighestOccuringdigitSimplified(int[] TestArr)
    {
        int N = TestArr.Length; int DistinctLength = TestArr.Distinct().ToArray().Length;
        int[] DistinctArr = TestArr.Distinct().ToArray();
        int[,] TwoDArr = new int[DistinctLength, 2];
        //Test: a = {4,3,2,1,1,1,1,1,1,1,4}; Result: [0,0] -> [1,7], [1,0] -> [4,2], [2,0] -> [3,1], [3,0] -> [2,1].
        TestArr = TestArr.OrderByDescending(s => s).ToArray();
        for (int i = 0; i < DistinctLength; i++)
        {
                TwoDArr[i, 0] = DistinctArr[i];
                TwoDArr[i, 1] = TestArr.ToString()!.Split(DistinctArr[i].ToString().Trim()).Length;
        }
        //sort second column...
    }

    public static int JaggedArrayGeneration(List<int> a)
    {
        //Test: a = {4,3,2,1}
        int N = a.Count(); int[,] s = new int[N, N]; int result = 0;
        int[,] p = new int[N, N];
        int[] final = new int[N];
        int[] multiplyArr = new int[N];

        for (int i = 0; i < N; i++)
        {
            multiplyArr[i] = i + 1;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                //[0,j] -> [4,0,0,0]; [1,j] -> [4,3,0,0] etc; [2,j] -> [4,3,2,0] etc
                s[i, j] = a[j]; //s[i, j] = (i - j >= 0) ? a[i - j] : 0; -> this method creates a reverse order
            }
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                //[0] -> [4 * 1, 0 * 2, 0 * 3, 0 * 4],[1] -> [4 * 1, 3 * 2, 0 * 3, 0 * 4] etc
                s[i, j] = s[i, j] * multiplyArr[j];

                //1 dimesional row aggregate
                final[i] = s[i, j] + final[i];
            }
        }

        for (int i = 0; i < N; i++)
        {
            result = final.Aggregate(func: (a, b) => a + b);  //final column aggregate 
        }
        return result;
    }

    //public static void CalculateSpeedDownload(Stream b, char[] buffer)
    //{
    //    StreamWriter fs = new StreamWriter(b);
    //    StreamReader ns = new StreamReader(b);
    //    while (true)
    //    {
    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        int n = ns.Read(buffer, 0, buffer.Length);
    //        sw.Stop();
    //        var Speed = (float)n / sw.Elapsed.TotalSeconds;

    //        if (n == 0)
    //            break;

    //        fs.Write(buffer, 0, n);

    //        BytesRead += n; //TODO: Persist the bytesRead object somewhere, so that it can be taken back for resumes
    //        bytesToRead -= n;
    //        OnProgress(this, new System.EventArgs());
    //        if (Status == DownloadStatusEnum.Paused) break;
    //    }

    public static int ClosestAbsolute(int[] OdiaArr)//checks the closest negative number to 0
    {
        int result1 = 0; int result2 = 0; int result = 0;
        if (OdiaArr.Length != 0)
        {
            int[] Pve = OdiaArr.Where(str => str > 0).ToArray();
            int[] Nve = OdiaArr.Where(str => str < 0).ToArray();
            result1 = (Pve.Length != 0) ? Pve.Min() : 0;
            result2 = (Nve.Length != 0) ? Nve.Max() : 0;
            int r = result1 - 0; int s = 0 - result2;
            result = (r > s) ? result2 : (s > r) ? result1
            : (r == s && result1 > result2) ? result1 : result2;
        }
        return result;
    }

    public static int[] IthPoduct(int[] args)
    {
        //[1,2,3,4] -> [24,12,8,6]
        int[] args2 = new int[args.Length];
        for (int i = 0; i < args2.Length; i++)
        {
            args2[i] = args.Where(s => s != args[i]).ToArray().Aggregate(func: (result, item) => result * item);
        }
        return args2;
    }

    public static string[] AlphabetsSolution(string s)
    {
        string group = "";
        List<string> checklist = new();
        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] alpha = alphabet.ToCharArray();
        for (int i = 0; i < alpha.Length; i++)
        {
            checklist.Add(alpha[i].ToString());
        }
        List<string> arr = new();
        arr.Add(s[0].ToString());
        for (int i = 1; i < s.Length - 1; i++)
        {
            if ((checklist.IndexOf(s[i - 1].ToString()) + 1) == checklist.IndexOf(s[i].ToString()))
            {
                //string groupinitial = group.Remove(group.Length - 1);
                group = arr[arr.Count - 1] + s[i].ToString();
                arr[arr.Count - 1] = group;
            }
            else
            {
                arr.Add(s[i].ToString());
                group = String.Empty;
            }
        }
        return arr.ToArray();
    }

    public static int HighestOccuringdigit(int[] numberArr)
    {
        int maxcount = 0; int n = numberArr.Length;
        int element_having_max_freq = 0;
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (numberArr[i] == numberArr[j])
                {
                    count++;
                }
            }
            if (count > maxcount)
            {
                maxcount = count;
                element_having_max_freq = numberArr[i];
            }
        }
        return element_having_max_freq;
        // return numberArr.GroupBy(s => transform(s)).OrderByDescending(g => g.Count()).First().Key;
    }

    public static string SML(string T)
    {
        int Scount = T.Split('S').Length - 1;
        int Mcount = T.Split('M').Length - 1;
        int Lcount = T.Split('L').Length - 1;
        string a = new string('S', Scount);
        string b = new string('M', Mcount);
        string c = new string('L', Lcount);
        return a + b + c;
    }

    /// <summary>
    /// / Going further count the number of character in any unspecified string...
    /// </summary>
    public static void AlphabetRandom(string T)
    {
        char[] alpha = T.ToCharArray();
        char[] alpha2 = alpha.Distinct().ToArray();
        int[] alphaCounter = new int[alpha2.Length]; ;
        object[,] Superarr = new object[2, alpha.Length];
        var parts = Regex.Split(T, "aa", RegexOptions.IgnoreCase);
        for (int i = 0; i < alpha2.Length; i++)
        {
            alphaCounter[i] = T.Split(alpha2[i]).Length - 1;
            Superarr[0, i] = alpha2[i]; //Superarray.Rank = 2
            Superarr[1, i] = alphaCounter[i];
            System.Console.WriteLine("{0} equals {1}", Superarr[0, i].ToString(), Superarr[1, i].ToString());
            //sortung
            //Superarr = Superarr[0,*].((a, b) => a[1] - b[1]);
        }
    }

    public static char CompareOverflow(string s, string t)
    {
        var a = s.ToCharArray().Select(s => s.ToString()).ToArray();
        var b = t.ToCharArray().Select(s => s.ToString()).ToArray();
        var result = b.Except(a);
        return char.Parse(string.Join("", result));
    }

    public static void ReadCSV(string path)
    {

        using (var reader = new StreamReader(path))
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = (line != null) ? line.Split(';') : Array.Empty<string>();

                listA.Add(values[0]);
                listB.Add(values[1]);
            }
        }
    }

    public static int BaseballScore(string[] ops)
    {
        int a = 0; int l = ops.Length;
        for (int i = 0; i < l; i++)
        {
            switch (ops[i])
            {
                case "+":
                    ops[i] = (int.Parse(ops[i - 1]) + int.Parse(ops[i - 2])).ToString();
                    a += int.Parse(ops[i]);
                    break;

                case "D":
                    ops[i] = (int.Parse(ops[i - 1]) * 2).ToString();
                    a += int.Parse(ops[i]);
                    break;

                case "C":
                    string b = ops[i - 1];
                    string c = ops[i];
                    a -= int.Parse(ops[i - 1]);
                    ops = ops.Where(val => val != b).Where(val => val != c).ToArray();
                    i -= 2; l = ops.Length;//aways re-declare length on Array modification.
                    break;

                default:
                    a += int.Parse(ops[i]);
                    break;
            }
            //int.Parse(ops[i].Aggregate());
        }
        return a;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        //string test = "ABCDEFiooheyrjiopqrs";
        //string[] arr = wordplayer.solution(test);
        //Console.WriteLine(arr);

        //string[] test = { "5", "2", "C", "D", "+" };
        //Console.WriteLine(wordplayer.BaseballScore(test));

        // Console.WriteLine(wordplayer.SML("LLLSSMSLM"));

        // wordplayer.AlphabetRandom("xbmnnnndlmppmmmo");

        //string s = "opqrs";
        //string t = "opqrst";
        //Console.WriteLine(wordplayer.CompareOverflow(s, t));

        //int[] numArray = { 4, 5, 5, 6, 4, 4, 4, 4, 1, 3, 4, 4 };
        //Console.WriteLine(wordplayer.HighestOccuringdigit(numArray));

        //int[] arr = { -99, -97, -98 - 43, -56, -98, 93, 60, 68, -13, 84, 57, 39, 57, -49, -56, -45, -12, 3, 4, 5, 6, 3, -1, 78, 45, 2, 23 };
        //Console.WriteLine(wordplayer.ClosestAbsolute(arr));

        //int[] arr = { 1, 2, 3, 4 }; int[] arr1 = wordplayer.IthPoduct(arr);
        //for (int i = 0; i < arr.Length; i++)
        //{
        //    Console.WriteLine(arr1[i]);
        //}

        //List<int> a = new List<int> { 4, 3, 2, 1 };
        //Console.WriteLine(wordplayer.JaggedArrayGeneration(a));

        int[] Test = { 4, 3, 2, 1, 1, 1, 1, 1, 1, 1, 4 };
        wordplayer.HighestOccuringdigitSimplified(Test);
    }
}


//function solution(n= 0)
//{
//    let numstring = n.toString();
//    let arr =[...numstring]
//    let result = 0;
//    arr.forEach((item) => result = result + parseInt(item));
//    return result;
//    // return arr.reduce((total)=>{parseInt(total+0)})
//}
