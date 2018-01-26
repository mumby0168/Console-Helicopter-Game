using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCopterGameFinal.Classes
{
    class ScoreSheet : Globals
    {
        static string _fileLoc = AppDomain.CurrentDomain.BaseDirectory + "Scoresheet.txt";
        public List<int> _scores = new List<int>();
        public List<string> _names = new List<string>();
        private static List<string> _namesandScores = new List<string>();


        public ScoreSheet()
        {
            Read();
        }
        public void Write(string name, int score)
        {
            _names.Add(name);
            _scores.Add(score);
            StreamWriter writer = new StreamWriter(_fileLoc);
            for (int i = 0; i < _names.Count; i++)
            {
                writer.WriteLine(_names[i]);
                writer.WriteLine(_scores[i].ToString());
            }

            writer.Close();
        }

        public void Read()
        {
            StreamReader reader = new StreamReader(_fileLoc);
            int lines = File.ReadLines(_fileLoc).Count();
            for (int i = 0; i < lines * 0.5; i++)
            {
                _names.Add(reader.ReadLine());
                _scores.Add(int.Parse(reader.ReadLine()));
            }

            reader.Close();
        }

        public List<string> GetList()
        {

            for (int i = 0; i < _names.Count; i++)
            {
                _namesandScores.Add("    "+_names[i] + " " + _scores[i]);
            }

            return _namesandScores;
        }
    }
}
