using Microsoft.AspNetCore.Authentication;

namespace MVC_Practice.Models
{
    public class Joke
    {
        public int Id { get; set; }

        public string? JokeQuestions { get; set; }

        public string? JokeAnswers { get; set; }

        public Joke()
        {
            
        }


    }
}
