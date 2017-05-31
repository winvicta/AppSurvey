using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppSurvey.Models;
using Microsoft.EntityFrameworkCore;
using AppSurvey.Data;
using AppSurvey.Models.SurveyViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace AppSurvey.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        private readonly AppSurveyDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private File _file;

        public SurveyController(AppSurveyDbContext context, UserManager<AppUser> userManager, File file)
        {
            _context = context;
            _userManager = userManager;
            _file = file;

            _context.Questions.Include(q => q.Options).Load();
        }

        // GET: Questions
        public IActionResult Index(int? id = 1)
        {
            var viewModel = new QuestionViewModel();
            viewModel.Question = _context.Questions.Where(q => q.QuestionID == id).Single();
            viewModel.Options = viewModel.Question.Options.OrderBy(o => o.Rank).ToList();
            viewModel.id = (int) id;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(QuestionViewModel viewModel)
        {
            string nid = "1";

            if (viewModel.id == 19 | viewModel.id == 24)
            {
                for (int i = 0; i < viewModel.Options.Count; i++)
                {
                    if (viewModel.Options[i].Selected)
                    {
                        string[] cs = viewModel.Options[i].Code.Split();
                        if (cs[2] == "Q" & viewModel.Text == null)
                            return Redirect("/Survey/Index/" + viewModel.id.ToString());
                        else
                        {
                            viewModel.Code += cs[0] + " ";
                            nid = cs[1];
                        }
                    }
                }
                if (viewModel.Code == null)
                    return Redirect("/Survey/Index/" + viewModel.id.ToString());
            }
            else
            {
                if (viewModel.Code == null)
                    return Redirect("/Survey/Index/" + viewModel.id.ToString());

                string[] cs = viewModel.Code.Split();
                if (cs[2] == "Q" & viewModel.Text == null)
                    return Redirect("/Survey/Index/" + viewModel.id.ToString());
                else
                {
                    viewModel.Code = cs[0];
                    nid = cs[1];
                }
            }

            Answer answer = new Answer
            {
                QID = viewModel.id,
                Code = viewModel.Code,
                Text = viewModel.Text
            };
            _file.AddAnswer(answer);

            if (nid != "0")
                return Redirect("/Survey/Index/" + nid.ToString());
            else
                return RedirectToAction("Summary","Survey");
        }

        public IActionResult Summary()
        {
            var viewModel = new ResponseViewModel();
            viewModel.QAs = new List<QA>();
            viewModel.Date = DateTime.Now.ToString();
            foreach (Answer a in _file.Answers)
            {
                QA qa = new QA();
                Question que = _context.Questions.Where(q => q.QuestionID == a.QID).SingleOrDefault();
                qa.qText = que.Description;

                qa.aCates = new List<string>();
                string[] ca = a.Code.Split();
                List<Option> ops = que.Options.ToList();
                for (int i = 0; i < ca.Length; i++)
                {
                    for (int j=0; j < ops.Count; j++)
                    {
                        string os = ops[j].Code.Split()[0];
                        if (os == ca[i])
                        {
                            os = ops.Where(o => o.Code == ops[j].Code).SingleOrDefault().Category;
                            qa.aCates.Add(os);
                        }
                    }
                }

                qa.aText = a.Text;
                viewModel.QAs.Add(qa);
            }
            
            return View(viewModel);
        }

        public async Task<IActionResult> Update()
        {
            var user = await GetCurrentUserAsync();
            Record rec = new Record { Email = user.Email, Date = DateTime.Now.ToString() };
            _context.Records.Add(rec);
            _context.SaveChanges();

            rec = _context.Records.Where(r => r.Email == user.Email).SingleOrDefault();
            user.RecordID = rec.RecordID;
            await _userManager.UpdateAsync(user);

            foreach (Answer a in _file.Answers)
            {
                Answer ans = new Answer { Code = a.Code, Text = a.Text, QID = a.QID, RecordID = user.RecordID };
                _context.Answers.Add(ans);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Startover()
        {
            _file.Clear();
            return Redirect("/Survey/Index/1" );
        }

        private async Task<AppUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}