using AnswerApp.Helper;
using AnswerApp.Models;
using AnswerApp.Models.Entity;
using AnswerApp.Models.Requests;

namespace AnswerApp.Services
{
    public class AnswerService
    {
        private readonly AnswerRepository _db;

        public AnswerService(AnswerContext context)
        {
            _db = new AnswerRepository(context);
        }



        public List<Answer> FindAll(){return _db.FindAll();}
        public Answer FindById(string id){return _db.FindById(id);}
        public List<Answer> FindByKeyword(string keyword){return _db.FindByKeyword(keyword);}



        public void Save(AnswerPost data){_db.Save(data);}
        public void Update(AnswerPut data, string id) { _db.Update(data, id);}
        public void Delete(string id) { _db.Delete(id); }
    }
}
