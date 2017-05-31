using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using AppSurvey.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace AppSurvey.Models
{
    public class File
    {
        public List<Answer> Answers = new List<Answer>();

        public virtual void AddAnswer(Answer answer) => Answers.Add(answer); 
        public virtual void RemoveAnswer(Answer answer) => Answers.Remove(answer);
        public virtual void Clear() => Answers.Clear();
    }

    public class SessionFile : File
    {
        public static File GetFile(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionFile file = session?.GetJson<SessionFile>("File") ?? new SessionFile();
            file.Session = session;
            return file;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddAnswer(Answer answer)
        {
            base.AddAnswer(answer);
            Session.SetJson("File", this);
        }
        public override void RemoveAnswer(Answer answer)
        {
            base.RemoveAnswer(answer);
            Session.SetJson("File", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("File");
        }
    }
}
