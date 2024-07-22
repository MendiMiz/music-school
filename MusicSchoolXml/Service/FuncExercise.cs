using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolXml.Service
{
    internal static class FuncExercise
    {
        public static Func<List<string>, bool> OneInTheListStartingWithA = (stringList) => stringList.Any(w => w.StartsWith("a"));

        public static Func<List<string>, bool> OneInTheListIsAnEmptyString = (stringList) => stringList.Any(w => string.IsNullOrEmpty(w));

        public static Func<List<string>, bool> AllListIncludesA = (stringList) => stringList.All(w => w.Contains("a"));

        public static Func<List<string>, List<string>> NewListToUpper = (stringList) => stringList.Select(w => w.ToUpper()).ToList();

        public static Func<List<string>, List<string>> myToUpper = list => (from str in list select str.ToUpper()).ToList();

        public static Func<List<string>, List<string>> ToUpTo3List = (list) => list.Where(w => w.Length > 3).ToList();

        public static Func<List<string>, List<string>> ToUpTo3ListLinq = list => (from str in list where str.Length > 3 select str).ToList();

        public static Func<List<string>, string> listToString = list => list.Aggregate(string.Empty, (s, w) => $"{s} {w}");

        public static Func<List<string>, int> listCount = list => list.Aggregate(0, (res, w) => res + w.Length);


    }
}
