using QuestionApp.Models;
using QuestionApp.Models.Entity;
using QuestionApp.Models.Requests.Entity;
using QuestionApp.Repositories;

namespace QuestionApp.Services
{
    public class QuestionService
    {
        private readonly QuestionRepository _db;

        public QuestionService(QuestionContext context)
        {
            _db = new QuestionRepository(context);
        }



        public List<Question> FindAll(){return _db.FindAll();}
        public Question FindById(long id){return _db.FindById(id);}
        public List<Question> FindByKeyword(string keyword){return _db.FindByKeyword(keyword);}



        public void Save(QuestionPost data){_db.Save(data);}
        public void Update(QuestionPut data, long id){ _db.Update(data, id);}
        public void Delete(long id) { _db.Delete(id); }
    }
}
