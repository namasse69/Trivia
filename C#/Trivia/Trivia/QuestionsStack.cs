using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsStack
    {
        private readonly LinkedList<string> _questions = new LinkedList<string>();

        public QuestionsStack(string category, Func<string, LinkedList<string>> getQuestions)
        {
            Category = category;
            _questions = getQuestions(Category);
        }

        public string Category { get; private set; }

        public void AskQuestionAndDiscard()
        {
            Console.WriteLine(_questions.First());
            _questions.RemoveFirst();
        }
    }
}