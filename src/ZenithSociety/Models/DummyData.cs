

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithSociety.Data;
using ZenithSociety.Models.ActivityEventModels;
using Microsoft.Extensions.DependencyInjection;

namespace ZenithSociety.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            getActivity(db);
            getEvent(db);
        }

        
        private static void getEvent(ApplicationDbContext db)
        {
            if (!db.Events.Any())
            {
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 03, 27),
                    DateFrom = new DateTime(2017, 03, 27, 12, 00, 00),
                    DateTo = new DateTime(2017, 03, 27, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 7).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 03, 27),
                    DateFrom = new DateTime(2017, 03, 27, 13, 00, 00),
                    DateTo = new DateTime(2017, 03, 27, 14, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 6).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 03, 29),
                    DateFrom = new DateTime(2017, 03, 29, 1, 00, 00),
                    DateTo = new DateTime(2017, 03, 29, 2, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 5).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 03, 30),
                    DateFrom = new DateTime(2017, 03, 30, 9, 00, 00),
                    DateTo = new DateTime(2017, 03, 30, 10, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 4).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 03, 31),
                    DateFrom = new DateTime(2017, 03, 31, 12, 00, 00),
                    DateTo = new DateTime(2017, 03, 31, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 3).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 1),
                    DateFrom = new DateTime(2017, 04, 1, 12, 00, 00),
                    DateTo = new DateTime(2017, 04, 1, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 2).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 2),
                    DateFrom = new DateTime(2017, 04, 2, 12, 00, 00),
                    DateTo = new DateTime(2017, 04, 2, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 7).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 2),
                    DateFrom = new DateTime(2017, 04, 2, 7, 00, 00),
                    DateTo = new DateTime(2017, 04, 2, 8, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 1).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 3),
                    DateFrom = new DateTime(2017, 04, 3, 12, 00, 00),
                    DateTo = new DateTime(2017, 04, 3, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 2).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 4),
                    DateFrom = new DateTime(2017, 04, 4, 2, 00, 00),
                    DateTo = new DateTime(2017, 04, 4, 3, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 3).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 5),
                    DateFrom = new DateTime(2017, 04, 5, 1, 00, 00),
                    DateTo = new DateTime(2017, 04, 5, 1, 30, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 6).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 6),
                    DateFrom = new DateTime(2017, 04, 6, 8, 00, 00),
                    DateTo = new DateTime(2017, 04, 6, 9, 14, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 4).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 7),
                    DateFrom = new DateTime(2017, 04, 7, 1, 30, 00),
                    DateTo = new DateTime(2017, 04, 7, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 5).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 8),
                    DateFrom = new DateTime(2017, 04, 8, 1, 00, 00),
                    DateTo = new DateTime(2017, 04, 8, 6, 20, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 3).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 9),
                    DateFrom = new DateTime(2017, 04, 9, 12, 00, 00),
                    DateTo = new DateTime(2017, 04, 9, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 2).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 10),
                    DateFrom = new DateTime(2017, 04, 10, 6, 00, 00),
                    DateTo = new DateTime(2017, 04, 10, 6, 30, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 8).ActivityId
                });
                db.Events.Add(new Event
                {
                    EventDate = new DateTime(2017, 04, 11),
                    DateFrom = new DateTime(2017, 04, 11, 12, 00, 00),
                    DateTo = new DateTime(2017, 04, 11, 13, 00, 00),
                    IsActive = true,
                    UserName = "p",
                    CreationDate = DateTime.Now,
                    ActivityId = db.Activities.FirstOrDefault(f => f.ActivityId == 5).ActivityId
                });
                db.SaveChanges();
            }
        }

        internal static void Initialize(object context)
        {
            throw new NotImplementedException();
        }

        private static void getActivity(ApplicationDbContext db)
        {
            if (!db.Activities.Any())
            {
                db.Activities.Add(new Activity
                {
                    Description = "Luncheon Girls",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Parents Night out",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Hockey Tournament",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Youth Enrichment class",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Kids craft lessons",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Youth choir practise",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Rehabilation Guidance",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Pancake Breakfast",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Yoga Classes",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Learn through Play",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Skyzone Tournament",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Lunch & Learn",
                    CreationDate = DateTime.Now,
                });
                db.Activities.Add(new Activity
                {
                    Description = "Happy Friday",
                    CreationDate = DateTime.Now,
                });
                db.SaveChanges();
            }
        }

    }


}