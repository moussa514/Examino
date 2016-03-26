using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Examino.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Examino.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        //Configuration des DbSets pour la Base de Données
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseFile> CourseFiles { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<UserAnswer> UserAnswers { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserQuiz> UserQuizzes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Pour éviter l'erreur de multiples cascade paths. On change le valeur cascade delete pour:
        //Userdetail et UseQuiz
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //UserDetail
            modelBuilder.Entity<UserDetail>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(false);
            //UserQuiz
            modelBuilder.Entity<UserQuiz>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserQuiz>()
                .HasRequired(c => c.Group)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserQuiz>()
                .HasRequired(c => c.Course)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserQuiz>()
                .HasRequired(c => c.Quiz)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}