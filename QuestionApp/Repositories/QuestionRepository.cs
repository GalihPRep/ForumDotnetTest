using QuestionApp.Models;
using QuestionApp.Models.Entity;
using QuestionApp.Models.Requests.Entity;

namespace QuestionApp.Repositories
{
    public class QuestionRepository
    {
        private QuestionContext _context;
        public QuestionRepository(QuestionContext context) { _context = context; }

        public List<Question> FindAll()
        {
            List<Question> result = new List<Question>();
            var dataList = _context
                .Questions
                .ToList();
            dataList.ForEach(question => result.Add(new Question()
            {
                Id = question.Id,
                Place = question.Place,
                Created = question.Created,
                Description = question.Description,
                AuthorUsername = question.AuthorUsername
            }));
            return result;
        }

        public Question FindById(long id)
        {
            var result = new Question();
            var dataList = _context
                .Questions
                .ToList();
            dataList.ForEach(question =>
            {
                if (question.Id == id) { result = question; }
            });
            return result;
        }

        public List<Question> FindByKeyword(string keyword)
        {
            List<Question> result = new List<Question>();
            var dataList = _context
                .Questions
                .ToList();
            dataList.ForEach(question =>
            {
                if (
                    question.Place.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    question.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                )
                {
                    result.Add(new Question()
                    {
                        Id = question.Id,
                        Place = question.Place,
                        Created = question.Created,
                        Description = question.Description,
                        AuthorUsername = question.AuthorUsername
                    });
                }
            });
            return result;
        }

        public void Save(QuestionPost data)
        {
            Question question = new Question()
            {
                Created = DateTime.UtcNow,
                Description = data.Description,
                Place = data.Place,
                AuthorUsername= data.AuthorUsername
            };
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Update(QuestionPut data, long id) 
        {
            Question question = FindById(id);
            question.Place = data.Place;
            question.Description = data.Description;
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            _context.Questions.Remove(FindById(id));
            _context.SaveChanges();
        }
    }
}
