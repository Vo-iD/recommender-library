using System.Data.Entity;
using RL.Entity.Own;

namespace RL.OwnData.Implementation.Infrastructure
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=BooksConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireAnswer> QuestionnaireAnswers { get; set; }
        public DbSet<QuestionnaireHistory> QuestionnaireHistories { get; set; }
        public DbSet<QuestionnaireItem> QuestionnaireItems { get; set; }
    }
}
