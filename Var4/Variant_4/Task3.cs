using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Task3
{
    public class Uniques
    {
        private string _input;
        private string[] _output;

        public string Input => _input;
        public string[] Output => _output;

        public Uniques(string input)
        {
            _input = input;
            if (string.IsNullOrEmpty(input))
            {
                _output = new string[0];
            }
            else
            {
                _output = FindUniques(input);
            }
        }

        private string[] FindUniques(string input)
        {
            var words = SplitString(input);
            var uniques = new List<string>();

            foreach (var word in words)
            {
                if (word.Length > 1 && IsUnique(word))
                {
                    uniques.Add(word);
                }
            }

            return uniques.ToArray();
        }

        private string[] SplitString(string input)
        {
            var words = new List<string>();
            var word = string.Empty;

            foreach (var c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        words.Add(word);
                        word = string.Empty;
                    }
                }
                else
                {
                    word += c;
                }
            }

            if (!string.IsNullOrEmpty(word))
            {
                words.Add(word);
            }

            return words.ToArray();
        }

        private bool IsUnique(string word)
        {
            var count = new int[256]; 

            foreach (var c in word.ToLowerInvariant())
            {
                if (count[c] > 0)
                {
                    return false;
                }
                count[c]++;
            }

            return true;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }

            var result = string.Empty;

            foreach (var word in _output)
            {
                result += word + "\n";
            }

            return result.Trim();
        }
    }
}