using Peak.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelismConcurrencyConsole
{
    class Program
    {
        #region Properties
        static StringBuilder result = new StringBuilder();
        #endregion

        static void Main(string[] args)
        {
            TestStringBuilder();
        }

        #region TestStringBuilder
        private static void TestStringBuilder()
        {
            int iteration = 100 * 1000;

            CodeTimer.Time("String  Concat", iteration,
                 () =>
                 {
                     var s = "1";
                     for (int i = 1; i < 10; i++)
                         s = s + "1";
                 }, Print);

            CodeTimer.Time("StringBuilder Concat", iteration,
                     () =>
                     {
                         var s = new StringBuilder();
                         for (int i = 1; i < 10; i++)
                             s.Append("1");
                     }, Print);

            ShowResult(result.ToString());
        }

        private static void ShowResult(string msg)
        {
            File.WriteAllText("result.txt", msg);
        }

        private static void Print(string msg)
        {
            result.AppendLine(msg);
        }
        #endregion

    }
}
