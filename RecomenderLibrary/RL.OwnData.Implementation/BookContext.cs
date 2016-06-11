using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RL.Entity.Own;

namespace RL.OwnData.Implementation
{
    public class BookContext : IdentityDbContext<User>
    {
        public BookContext()
            : base("name=BooksConnection")
        {
        }

        public override IDbSet<User> Users { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireAnswer> QuestionnaireAnswers { get; set; }
        public DbSet<QuestionnaireHistory> QuestionnaireHistories { get; set; }
        public DbSet<QuestionnaireItem> QuestionnaireItems { get; set; }
    }
}
