namespace week4
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;

    public class Book
    {
        private Dictionary<string, int> words;

        public Book(string text)
        {
            Text = new List<string>();
            string[] cleanedText;
            cleanedText = Regex.Replace(text, @"[^\w\'\s\n]", "").Split(null);
            for (int x = 0; x < cleanedText.Length; ++x)
            {
                cleanedText[x] = Regex.Match(cleanedText[x], @"[^\W\d]([\w'-]{1,3}(?=))*", RegexOptions.None).Value;
                if (!string.IsNullOrEmpty(cleanedText[x]))
                {
                    Text.Add(cleanedText[x]);
                }
            }
        }

        private List<string> Text { get; set; }

        private Dictionary<string, int> Words
        {
            get
            {
                if (words == null)
                {
                    words = new Dictionary<string, int>();

                    foreach (var word in Text)
                    {
                        if (word == "")
                            continue;
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                        else
                        {
                            words.Add(word, 1);
                        }
                    }
                }

                return words;
            }
        }

        public string Serialize()
        {
            var sb = new StringBuilder("{");
            
            foreach (var key in Words.Keys)
            {
                sb.Append(string.Format("'{0}' : '{1}',\r\n", key, Words[key]));
            }

            sb.Append("}");

            return sb.ToString();
        }

    }

    /// <summary>
    /// Main entry point
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]))
            {
                return;
            }
            else if (!args[0].Contains(".txt"))
            {
                return;
            }

            try
            {
                if (!File.Exists(args[0]))
                {
                    return;
                }
            }
            catch (Exception)
            {
                // Was in a bad format, handle later
                return;
            }
            
            var fInfo = new FileInfo(args[0]);
            
            // So, now that we know we have a file...

            string text = string.Empty;

            using (var reader = new StreamReader(fInfo.FullName))
            {
                text = reader.ReadToEnd();
            }

            Book b = new Book(text);
            
            using (var writer = new StreamWriter(string.Format("{0}/output.txt", fInfo.Directory)))
            {
                writer.Write(b.Serialize());
            }
        }
    }
}
