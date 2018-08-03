namespace CP.Data.Migrations
{
    using CP.Domain.Entities;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.CPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.CPContext context)
        {
            if (!context.CourseTypes.Any(x => x.Description == "Bachelor Degree"))
            {
                context.CourseTypes.Add(new CourseType("Bachelor", true));
                context.CourseTypes.Add(new CourseType("Technology", true));
                context.CourseTypes.Add(new CourseType("Technique", true));
                context.SaveChanges();
            }
        }
    }
}
