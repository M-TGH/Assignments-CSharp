
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                //Get arg and check if it exists, if it's big enough, etc.
                string path = Directory.GetCurrentDirectory() + "/" + arg;
                if(File.Exists(path) && path.Contains(".txt")){
                    string[] fileLines = File.ReadAllLines(path);
                    if(fileLines.Length < 10){
                        Console.WriteLine("File is not big enough, good bye");
                    }
                    else
                    {
                        //Add questions to List
                        Console.WriteLine("What is your name?");
                        string name = Console.ReadLine();
                        List<Question> questions = new List<Question>();
                        int currentQuestion = 0;
                        int currentAnswer = 0;
                        foreach(string line in fileLines){
                            if(line.Contains("Question:")){
                                questions.Add(new Question(line, new List<string>(), 0));
                                currentQuestion++;
                                currentAnswer = 0;
                            }
                            else
                            {
                                if (line.IndexOf("*") == 0)
                                {
                                    questions[currentQuestion - 1]._correctAnswer = currentAnswer;
                                    questions[currentQuestion - 1]._answers.Add(currentAnswer.ToString() + ". " + line.Substring(1));
                                }
                                else
                                {
                                    questions[currentQuestion - 1]._answers.Add(currentAnswer.ToString() + ". " + line);
                                }
                                currentAnswer++;
                            }
                        }
                        int correctAnswers = 0;
                        foreach(Question curQuestion in questions){
                            Console.WriteLine(curQuestion._question);
                            Console.WriteLine("Choose one (Type 1,2,3, etc):");
                            foreach(string answer in curQuestion._answers){
                                Console.WriteLine(answer);
                            }
                            string input = Console.ReadLine();
                            int givenAnswer = 0;
                            bool parseableNow = int.TryParse(input, out givenAnswer);
                            if(!parseableNow){
                                Console.WriteLine("That was not a number now was it?");
                            } 
                            else if(givenAnswer == curQuestion._correctAnswer){
                                correctAnswers++;
                                Console.WriteLine("Good job that was the correct answer." + Environment.NewLine);
                            }
                            else
                            {
                                Console.WriteLine("That was the wrong answer, better luck next question." + Environment.NewLine);
                            }

                            CalcQuestion curCalcQuestion = RandomCalc();
                            Console.WriteLine("Please give your answer in the form of a number:");
                            Console.Write(curCalcQuestion._question);
                            string calcInput = Console.ReadLine();
                            int calcGivenAnswer = 0;
                            bool parseable = int.TryParse(calcInput, out calcGivenAnswer);
                            if(!parseable){
                                Console.WriteLine("Not a number.");
                            }
                            else
                            {
                                if(calcGivenAnswer == curCalcQuestion._correctAnswer){
                                    correctAnswers++; 
                                    Console.WriteLine("Good job that was the correct answer." + Environment.NewLine);
                                }
                                else
                                {
                                    Console.WriteLine("That was the wrong answer, better luck next question." + Environment.NewLine);
                                }
                            }

                        }
                        Console.WriteLine("You answered " + correctAnswers.ToString() + " questions correctly.");
                        Console.WriteLine("Do you want to save your score to .txt?");
                        string save = Console.ReadLine();
                        if (save.ToUpper().Equals("YES"))
                        {
                            using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "/" + name + DateTime.Now.ToString("yyyyMMdd HH_mm_ss") + ".txt"))
                            {
                                sw.WriteLine("Correct Answers: " + correctAnswers.ToString() + "/" + (questions.Count() * 2) + " Percentage: " + (Convert.ToDouble(correctAnswers) / (questions.Count() * 2f) * 100f).ToString());
                            }
                        }
                        Console.WriteLine("App will shut down in 5 seconds.");
                        

                    }
                }
                else
                {
                    Console.WriteLine("Didn't find file, closing app");
                }
            }
        }

        static CalcQuestion RandomCalc()
        {
            //Make a random calculation questions and return it.
            Random random = new Random();
            int oper = random.Next(4);
            int num1 = random.Next(198) - 99;
            int num2 = random.Next(198) - 99;
            string questionTxt = "";
            int correctAnswer = 0;
            switch(oper){
                case 0:
                    correctAnswer = num1 + num2;
                    questionTxt = num1.ToString() + "+" + num2.ToString() + "=";
                    break;
                case 1:
                    correctAnswer = num1 - num2;
                    questionTxt = num1.ToString() + "-" + num2.ToString() + "=";
                    break;
                case 2:
                    correctAnswer = num1 * num2;
                    questionTxt = num1.ToString() + "*" + num2.ToString() + "=";
                    break;
                case 3: 
                    if(num1 > num2){
                        correctAnswer = num1 / num2;
                        questionTxt = num1.ToString() + "/" + num2.ToString() + "=";
                    }
                    else
                    {
                        correctAnswer = num2 / num1;
                        questionTxt = num2.ToString() + "/" + num1.ToString() + "=";
                    }
                    break;
            }


            CalcQuestion question = new CalcQuestion(questionTxt, correctAnswer);
            return question;
        }
    }
}
