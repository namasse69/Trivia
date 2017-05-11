using System.Collections.Generic;

namespace Trivia
{
    public interface IQuestionRepository
    {
        LinkedList<string> GetQuestions(string category);
    }
}