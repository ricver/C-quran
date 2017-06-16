using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ReadQuran
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            
            string fileName = "Arabic-1.xml";
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\XMLQuran\", fileName);

            doc.Load(path);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("Chapter");

            List<HolyQuranChapter> HolyQuran = new List<HolyQuranChapter>();

            foreach (XmlNode node in nodes)
            {
                HolyQuranChapter Chapter = new HolyQuranChapter();

                //book.Chapter = node.SelectSingleNode("Chapter").InnerText;
                //book.title = node.SelectSingleNode("title").InnerText;
                Chapter.ChapterName = node.Attributes["ChapterName"].Value;
                Chapter.ChapterID = node.Attributes["ChapterID"].Value;

                HolyQuran.Add(Chapter);
            }

            System.Console.WriteLine("Total books: " + HolyQuran.Count);
            System.Console.ReadLine();
        }
    }
    class HolyQuranChapter
    {
        public string ChapterID;
        //public string Chapter;
        public string ChapterName;
    }
}
