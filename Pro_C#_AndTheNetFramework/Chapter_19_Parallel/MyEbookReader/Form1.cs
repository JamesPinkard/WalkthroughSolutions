﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace MyEbookReader
{
    public partial class MyForm : Form
    {

        public MyForm()
        {
            InitializeComponent();
        }


        private string theEBook;

        private void btnDownload_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();

            // Register Download Event
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                theEBook = eArgs.Result;
                txtBook.Text = theEBook;
            };

            // The Project gutenberg EBook of A Tale of Two Cites, by Charles Dickens
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            // Get the words from the e-book.
            string[] words = theEBook.Split(new char[] { ' ', '\u000A', ',', ';', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    // Now, find the ten most commmon words.
                    tenMostCommon = FindTenMostCommon(words);
                },
                () =>
                {
                    // Get the longest word.
                    longestWord = FindFormLongestWord(words);
                });
            

            // Now that all tasks are complete, build a string to show all
            // stats in a message box.
            StringBuilder bookStats = new StringBuilder("ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book info");
        }

        private void GetStatsWithThread(string[] words, out string[] tenMostCommon, out string longestWord)
        {
            // Now, find the ten most common words.
            tenMostCommon = FindTenMostCommon(words);

            // get the longest word
            longestWord = FindFormLongestWord(words);
        }

        private string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            string[] commonwords = (frequencyOrder.Take(10)).ToArray();
            return commonwords;
        }

        private string FindFormLongestWord(string[] words)
        {
            return (from w in words
                    orderby w.Length descending
                    select w).FirstOrDefault();
        }


    }
}
