

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Book : Media, IEncryptable
    {

        // Author properties
        public string Author { get; protected set; }

        // Summary Properties
        public string Summary { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="author"></param>
        /// <param name="summary"></param>
        public Book(string title, int year, string author, string summary) : base(title, year)
        {
            Author = author;
            Summary = summary;
            Summary = Encrypt();
        }


        /// <summary>
        /// output string for Book object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Book Title: {Title} ({Year})\nAuthor: {Author}\n------------------------------";
        }

        /// <summary>
        /// encrypt Summary
        /// </summary>
        /// <returns></returns>
        public string Encrypt()
        {
            return !string.IsNullOrEmpty(Summary) ? new string(Summary.ToCharArray().Select(s => { return (char)((s >= 97 && s <= 122) ? ((s + 13 > 122) ? s - 13 : s + 13) : (s >= 65 && s <= 90 ? (s + 13 > 90 ? s - 13 : s + 13) : s)); }).ToArray()) : Summary;
        }

        /// <summary>
        /// Decrypt Summary
        /// </summary>
        /// <returns></returns>
        public string Decrypt()
        {
            return !string.IsNullOrEmpty(Summary) ? new string(Summary.ToCharArray().Select(s => { return (char)((s >= 97 && s <= 122) ? ((s + 13 > 122) ? s - 13 : s + 13) : (s >= 65 && s <= 90 ? (s + 13 > 90 ? s - 13 : s + 13) : s)); }).ToArray()) : Summary;
        }
    }
}
