using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Song : Media
    {

        /// <summary>
        /// Album
        /// </summary>
        public string Album { get; protected set; }

        /// <summary>
        /// Artist
        /// </summary>
        public string Artist { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="album"></param>
        /// <param name="artist"></param>
        public Song(string title, int year, string album, string artist) : base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        /// <summary>
        /// output string for Song object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Song Title: {Title} ({Year})\nAlbum: {Album}   Artist: {Artist}\n----------------------------";
        }
    }
}
