using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    //this is the scoresheet class which inherits from the globals class
    class ScoreSheet : Globals
    {
        //static declarations
        static string _fileLoc = AppDomain.CurrentDomain.BaseDirectory + "Scoresheet.txt"; // this declares a static string which will store the location of the file
        static List<string> _namesandScores = new List<string>(); // this declares a list of strings which will be used to store both the name and score of the player

        //public delcarations
        public List<int> _scores = new List<int>(); //this is a list of integres
        public List<string> _names = new List<string>(); // this is a list of strings
        
        //this is the constructor for the scoresheet class
        public ScoreSheet()
        {
            Read(); // this will call the public read method and will be called when a instance of the object has been created
        }

        //this is a public method that will take two arguments name and score
        public void Write(string name, int score)
        {
            _names.Add(name);//this will add the name paramater that will be passed to the names list
            _scores.Add(score);//this will add the score paramater that will be passed to the scores list
            StreamWriter writer = new StreamWriter(_fileLoc); // this opens the streamreader at the passed location
            for (int i = 0; i < _names.Count; i++) // this will loop over until it meets the count of the names list
            {
                writer.WriteLine(_names[i]); // this will add a name to the list
                writer.WriteLine(_scores[i].ToString());// this will add a score to the list and convert it to a string
            }

            writer.Close(); // this will close the writer
        }

        //this will read the exising names and scores in the text file
        public void Read()
        {
            StreamReader reader = new StreamReader(_fileLoc); // this open a new reader using the file that is passed
            int lines = File.ReadLines(_fileLoc).Count(); // this declares a variable which will get how many lines there are in the file that is passed
            for (int i = 0; i < lines * 0.5; i++) // this will loop until it has met half the value of the lines int
            {
                _names.Add(reader.ReadLine()); // this will add a name to the score reading from the file
                _scores.Add(int.Parse(reader.ReadLine())); // this will add a score and parse it which is read from the file
            }

            reader.Close(); // this will close the reader
        }

        //this will get the list that can be displayed in the highscore screen it will return a list
        public List<string> GetList()
        {

            for (int i = 0; i < _names.Count; i++) // this will loop until it has met the count of the names list
            {
                _namesandScores.Add("    "+_names[i] + " " + _scores[i]); // this will add the names and scores to the list with spaces
            }

            return _namesandScores; // this will return the names and scores list
        }
    }
}
