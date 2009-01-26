using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace TravellingSalesman
{



    public static class Debug
    {

        public static void write(String err)
        {

            bool isOn = true;
            string path = "C:\\ludebug.txt";

            StackFrame CallStack = new StackFrame(1, true);

            string SourceFile = "";//CallStack.GetFileName();
            int SourceLine = CallStack.GetFileLineNumber();
            string method = CallStack.GetMethod().Name.ToString();


            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(SourceLine.ToString() + ":  " + "SRC   " + SourceFile + "| " + method + " | " + err);
                    sw.Close();
                }
            }
            catch { };
        }

        public static void div()
        {
            bool isOn = true;
            string path = "C:\\ludebug.txt";

            if (!File.Exists(path) && isOn)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("________________________________________________________________________");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.Close();
                }
            }

            if (File.Exists(path) && isOn)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("________________________________________________________________________");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.Close();
                }
            }
        }
        public static void pair(string val1, string val2)
        {
            string path = "C:\\ludebug.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(val1 + " = " + val2);
                sw.Close();
            }
        }

        public static void write2(String err)
        {

            bool isOn = true;
            string path = "C:\\ludebug2.txt";

            StackFrame CallStack = new StackFrame(1, true);

            string SourceFile = CallStack.GetFileName();
            int SourceLine = CallStack.GetFileLineNumber();
            String method = CallStack.GetMethod().ToString();


            if (!File.Exists(path) && isOn)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(SourceLine.ToString() + ":  " + "SRC   " + SourceFile + "|" + method + err);
                    sw.Close();
                }
            }

            if (File.Exists(path) && isOn)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(SourceLine.ToString() + ":  " + "SRC   " + SourceFile + "|" + method + err);
                    sw.Close();
                }
            }
        }
    }
}
