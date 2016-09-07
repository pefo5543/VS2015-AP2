namespace Game_AVP2.Migrations
{
    using Models.Avp2.GameModels.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Game_AVP2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Game_AVP2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //Add stories
            context.Stories.AddOrUpdate(
                 p => p.Text,
                 new Story
                  {
                    
                      Text = @"Last text <br\> <span class='text-success'>new line</span>",
                      IsBattle = true,
                      IsDialogue = false,
                      IsFirst = false,
                      IsLast = true,
                      NextText = 0,
                      EpisodeId = 1
                  }
                );
            context.SaveChanges();
            List<Story> list = context.Stories.ToList();
            Story last = list.LastOrDefault();
            int lastStoryId = last.StoryId;
            context.Stories.AddOrUpdate(
                 p => p.Text,
                  new Story
                  {
                      Text = @"middle text <br\> <span class='text-success'>new line</span>",
                      IsBattle = true,
                      IsDialogue = false,
                      IsFirst = false,
                      IsLast = false,
                      NextText = lastStoryId,
                      EpisodeId = 1
                  }
                );
            context.SaveChanges();
            //last = context.Stories.First();
            list = context.Stories.ToList();
            last = list.LastOrDefault();
            lastStoryId = last.StoryId;
            context.Stories.AddOrUpdate(
                 p => p.Text,
                  new Story
                  {
                      Text = @"first text <br\> <span class='text-success'>new line</span>",
                      IsBattle = true,
                      IsDialogue = false,
                      IsFirst = true,
                      IsLast = false,
                      NextText = lastStoryId,
                      EpisodeId = 1
                  }
                );
        }
    }
}
