using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizConsoleApp
{
    class Question
    {
        public string _question;
        public List<string> _answers;
        public int _correctAnswer;

        public Question(string question, List<string> answers, int correctAnswer)
        {
            _question = question;
            _answers = answers;
            _correctAnswer = correctAnswer;
        }
    }
}
