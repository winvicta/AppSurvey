using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AppSurvey.Models;
using AppSurvey.Data;
using AppSurvey.Models.AdminViewModels;
using AppSurvey.Models.SurveyViewModels;

namespace AppSurvey.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> _userManager;

        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;

        private readonly AppSurveyDbContext _context;
        private File _file;

        public AdminController(UserManager<AppUser> userManager, IUserValidator<AppUser> userValidator, IPasswordValidator<AppUser> passValidator, IPasswordHasher<AppUser> passwordHasher, AppSurveyDbContext context, File file)
        {
            _userManager = userManager;
            _userValidator = userValidator;
            _passwordValidator = passValidator;
            _passwordHasher = passwordHasher;
            _context = context;
            _file = file;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", _userManager.Users);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user,
                        password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }

        public async Task<IActionResult> Survey(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            Record rec = _context.Records.Where(r => r.Email == user.Email).SingleOrDefault();
            if (user != null & rec != null)
            {
                List<Answer> answers = _context.Answers.Where(a => a.RecordID == rec.RecordID).OrderBy(a => a.QID).ToList();
                var viewModel = new ResponseViewModel();
                viewModel.QAs = new List<QA>();
                viewModel.QAs.Clear();
                viewModel.Date = rec.Date;
                viewModel.Email = rec.Email;

                foreach (Answer a in answers)
                {
                    QA qa = new QA();
                    Question que = _context.Questions.Where(q => q.QuestionID == a.QID).SingleOrDefault();
                    qa.qText = que.Description;

                    qa.aCates = new List<string>();
                    string[] ca = a.Code.Split();
                    List<Option> ops = _context.Options.Where(o => o.QuestionID == a.QID).ToList();
                    for (int i = 0; i < ca.Length; i++)
                    {
                        for (int j = 0; j < ops.Count; j++)
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
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Report(ResponseViewModel vw)
        {
            Record rec = _context.Records.Where(r => r.Email == vw.Email).SingleOrDefault();

            List<Answer> answers = _context.Answers.Where(a => a.RecordID == rec.RecordID).OrderBy(a => a.QID).ToList();
            var viewModel = new ResponseViewModel();
            viewModel.QAs = new List<QA>();
            viewModel.QAs.Clear();
            viewModel.Date = rec.Date;
            viewModel.Email = rec.Email;
            foreach (Answer a in answers)
            {
                QA qa = new QA();
                Question que = _context.Questions.Where(q => q.QuestionID == a.QID).SingleOrDefault();
                qa.qText = que.Index.ToString();

                qa.aCates = new List<string>();
                qa.aCates.Add(a.Code);
                qa.aText = a.Text;
                viewModel.QAs.Add(qa);
            }
            return View(viewModel);
        }
    }
}