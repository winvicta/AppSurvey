using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppSurvey.Models;

namespace AppSurvey.Data
{
    public class AppSurveyIdDbInitializer
    {
        private const string stdUser = "anonymous";
        private const string stdEmail = "anonymous@Acme.com"; 
        private const string stdPassword = "Secret123";
        public static async void Initialize(IApplicationBuilder app)
        {
            UserManager<AppUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<AppUser>>();
            AppUser user = (AppUser) await userManager.FindByIdAsync(stdUser);
            if (user == null)
            {
                user = new AppUser { UserName = stdUser, Email = stdEmail };
                await userManager.CreateAsync(user, stdPassword);
            }
        }
    }
}
