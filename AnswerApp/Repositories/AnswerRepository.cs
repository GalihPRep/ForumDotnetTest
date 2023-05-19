using AnswerApp.Models;
using AnswerApp.Models.Entity;
using AnswerApp.Models.Requests;

namespace AnswerApp.Helper
{
    public class AnswerRepository
    {
        private AnswerContext _context;
        public AnswerRepository(AnswerContext context) { _context = context; }

        public List<Answer> FindAll()
        {
            List<Answer> result = new List<Answer>();
            var dataList = _context.Answers.ToList();
            dataList.ForEach(row => result.Add(new Answer()
            {
                Id = row.Id,
                Created = row.Created,
                Content = row.Content,
                AuthorUsername = row.AuthorUsername,
                QuestionId = row.QuestionId
            }));
            return result;
        }
        public Answer FindById(string id)
        {
            var result = new Answer();
            var dataList = _context.Answers.ToList();
            dataList.ForEach(row =>
            {
                if (row.Id == id) { result = row; }
            });
            return result;
        }
        public List<Answer> FindByKeyword(string keyword)
        {
            List<Answer> result = new List<Answer>();
            var dataList = _context
                .Answers
                .ToList();
            dataList.ForEach(answer =>
            {
                if (
                    answer.Content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    answer.AuthorUsername.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                )
                {
                    result.Add(new Answer()
                    {
                        Id = answer.Id,
                        Created = answer.Created,
                        Content= answer.Content,
                        AuthorUsername = answer.AuthorUsername,
                        QuestionId = answer.QuestionId
                    });
                }
            });
            return result;
        }
        public void Save(AnswerPost data)
        {
            Answer answer = new Answer()
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.UtcNow,
                Content = data.Content,
                AuthorUsername = data.AuthorUsername,
                QuestionId = data.QuestionId,
            };
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }
        public void Update(AnswerPut data, string id) 
        {
            Answer answer = FindById(id);
            answer.Content = data.Content;
            _context.Answers.Update(answer);
            _context.SaveChanges();
        }
        public void Delete(string id) 
        { 
            _context.Answers.Remove(FindById(id));
            _context.SaveChanges();
        }
    }
}
