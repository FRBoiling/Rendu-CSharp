using System.Collections.Generic;
using System.Collections;
using System;

namespace UtilityLib
{
    public class WordChecker
    {
        private HashSet<string> _wordList = new HashSet<string>();
        private BitArray _firstCharCheck = new BitArray(char.MaxValue);
        private BitArray _allCharCheck = new BitArray(char.MaxValue);
        private int _maxLength = 0;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="badWords"></param>
        public WordChecker(string[] badWords)
        {
            if (badWords != null)
            {
                foreach (string word in badWords)
                {
                    if (string.IsNullOrEmpty(word))
                    {
                        continue;
                    }
                    _maxLength = Math.Max(_maxLength, word.Length);
                    _wordList.Add(word);
                    _firstCharCheck[word[0]] = true;
                    foreach (char c in word)
                    {
                        _allCharCheck[c] = true;
                    }
                }
            }
        }

        public void AddBadWords(string[] badWords)
        {
            if (badWords != null)
            {
                foreach (string word in badWords)
                {
                    _maxLength = Math.Max(_maxLength, word.Length);
                    _wordList.Add(word);
                    _firstCharCheck[word[0]] = true;
                    foreach (char c in word)
                    {
                        _allCharCheck[c] = true;
                    }
                }
            }
        }

        public bool HasBadWord(string text)
        {
            int index = 0;
            while (index < text.Length)
            {
                if (!_firstCharCheck[text[index]])
                {
                    while (index < text.Length - 1 && !_firstCharCheck[text[++index]]) ;
                }
                for (int j = 1; j <= Math.Min(_maxLength, text.Length - index); j++)
                {
                    if (!_allCharCheck[text[index + j - 1]])
                    {
                        break;
                    }

                    string sub = text.Substring(index, j);
                    if (_wordList.Contains(sub) == true)
                    {
                        return true;
                    }
                }
                index++;
            }
            return false;
        }

        public string FilterBadWord(string text)
        {
            List<string> badWords = new List<string>();
            int index = 0;
            while (index < text.Length)
            {
                if (!_firstCharCheck[text[index]])
                {
                    while (index < text.Length - 1 && !_firstCharCheck[text[++index]]) ;
                }
                for (int j = 1; j <= Math.Min(_maxLength, text.Length - index); j++)
                {
                    if (!_allCharCheck[text[index + j - 1]])
                    {
                        break;
                    }

                    string sub = text.Substring(index, j);
                    if (_wordList.Contains(sub) == true)
                    {
                        badWords.Add(sub);
                    }
                }
                index++;
            }

            foreach (var item in badWords)
            {
                text = text.Replace(item, "*");
            }
            badWords.Clear();
            return text;
        }


        public int GetWordLen(string word)
        {
            int len = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] > 127)
                {
                    len += 2;
                }
                else
                {
                    len += 1;
                }
            }
            return len;
        }

    }
}
