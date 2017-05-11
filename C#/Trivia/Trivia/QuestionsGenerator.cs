using System.Collections.Generic;

namespace Trivia
{
    public class QuestionsGenerator : IQuestionRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            LinkedList<string> listeQuestion = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                listeQuestion.AddLast(category + " Question " + i);
            }

            return listeQuestion;
        }
    }
}