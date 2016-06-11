using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RL.Entity.Own
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Message> ReceivedMessages { get; set; }

        public IEnumerable<Message> SendedMessages { get; set; }

        public IEnumerable<QuestionnaireItem> Items { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
