using AccountApp.Models.Entities;
using AccountApp.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Project000.Models;
using System.Security.Principal;

namespace Project000.Helper
{
    public class AccountRepository
    {
        private AccountContext _context;
        public AccountRepository(AccountContext context) { _context = context; }

        public List<Account> FindAll()
        {
            List<Account> result = new List<Account>();
            var dataList = _context.Accounts.ToList();
            dataList.ForEach(row => result.Add(new Account()
            {
                Username = row.Username
            }));
            var questionList = _context.Questions.ToList();
            var answerList = _context.Answers.ToList();
            result.ForEach(account =>
            {
                questionList.ForEach(question => 
                { 
                    if(question.AuthorUsername == account.Username) 
                    {
                        if(account.Questions == null) { account.Questions = new List<Question>(); }
                        account.Questions.Add(question);
                    }
                });
                answerList.ForEach(answer => 
                {
                    if (answer.AuthorUsername == account.Username)
                    {
                        if (account.Answers == null) { account.Answers = new List<Answer>(); }
                        account.Answers.Add(answer);
                    }
                });
            });
            return result;
        }
        public Account FindByUsername(string username)
        {
            var result = new Account();
            var dataList = _context.Accounts.ToList();
            dataList.ForEach(account =>
            {
                if (account.Username == username) { result = account; }
            });
            var questionList = _context.Questions.ToList();
            var answerList = _context.Answers.ToList();
            questionList.ForEach(question =>
            {
                if (question.AuthorUsername == result.Username)
                {
                    if (result.Questions == null) { result.Questions = new List<Question>(); }
                    result.Questions.Add(question);
                }
            });
            answerList.ForEach(answer =>
            {
                if (answer.AuthorUsername == result.Username)
                {
                    if (result.Answers == null) { result.Answers = new List<Answer>(); }
                    result.Answers.Add(answer);
                }
            });
            return result;
        }
        public void Save(AccountDto request)
        {
            var data = new Account() { Username = request.Username};
            _context.Accounts.Add(data);
            _context.SaveChanges();
        }

        
        public void Update(AccountDto request, string username)
        {
            var data = FindByUsername(username);
            data.Username = request.Username;
            _context.Accounts.Add(data);
            List<Answer> answerDataList = _context.Answers.ToList();
            answerDataList.ForEach(answerItem =>
            {
                if(answerItem.AuthorUsername == username) 
                {
                    answerItem.AuthorUsername = data.Username;
                    _context.Answers.Update(answerItem);
                }
            });
            List<Question> questionDataList = _context.Questions.ToList();
            questionDataList.ForEach(questionItem =>
            {
                if(questionItem.AuthorUsername == username) 
                {
                    questionItem.AuthorUsername = data.Username;
                    _context.Questions.Update(questionItem);
                }
            });
            //Delete(username);
            _context.SaveChanges();
        }
        

        public void Delete(string username)
        {
            _context.Accounts.Remove(FindByUsername(username));
            _context.SaveChanges();
        }
    }
}
