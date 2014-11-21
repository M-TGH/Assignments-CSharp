using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizConsoleApp
{
    class CalcQuestion
    {
        public string _question;
        public int _correctAnswer;

        public CalcQuestion(string question, int correctAnswer)
        {
            _question = question;
            _correctAnswer = correctAnswer;
        }
    }
}
