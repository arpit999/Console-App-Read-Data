using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Movie : Media, IEncryptable
    {

        /// <summary>
        /// Director properties
        /// </summary>
        public string Director { get; protected set; }
        /// <summary>
        /// Summary properties
        /// </summary>
        public string Summary { get; protected set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="director"></param>
        /// <param name="summary"></param>
        public Movie(string title, int year, string director, string summary) : base(title, year)
        {
            Director = director;
            Summary = summary;
            Summary = Encrypt();
        }

        /// <summary>
        /// output string from movie object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Movie Title: {Title} ({Year})\nDirector: {Director}\n----------------------------";
        }

        /// <summary>
        /// Entripting summary and return string
        /// </summary>
        /// <returns></returns>
        public string Encrypt()
        {
            return !string.IsNullOrEmpty(Summary) ? new string(Summary.ToCharArray().Select(s => { return (char)((s >= 97 && s <= 122) ? ((s + 13 > 122) ? s - 13 : s + 13) : (s >= 65 && s <= 90 ? (s + 13 > 90 ? s - 13 : s + 13) : s)); }).ToArray()) : Summary;
        }

        /// <summary>
        /// decrypting summary
        /// </summary>
        /// <returns></returns>
        public string Decrypt()
        {
            return !string.IsNullOrEmpty(Summary) ? new string(Summary.ToCharArray().Select(s => { return (char)((s >= 97 && s <= 122) ? ((s + 13 > 122) ? s - 13 : s + 13) : (s >= 65 && s <= 90 ? (s + 13 > 90 ? s - 13 : s + 13) : s)); }).ToArray()) : Summary;
        }
    }
}
