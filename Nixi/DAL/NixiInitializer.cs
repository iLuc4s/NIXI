using Nixi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.DAL
{
    public class NixiInitializer : System.Data.Entity.DropCreateDatabaseAlways<NixiContext>
    {
        protected override void Seed(NixiContext context)
        {
            List<Guid> guids = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
            };
            
            Address address = new Address { Id = guids[9], Street = "OnzeSteenweg", Housenumber = "123", Postalcode = 1234, City = "Onsdorp" };
            context.Addresses.Add(address);
            context.SaveChanges();

            Location location = new Location { Id = guids[16], DaycareName = "De Tutjes", AddressId = guids[9] };
            context.Locations.Add(location);
            context.SaveChanges();

            Class c1 = new Class { Id = guids[15], Name = "De Tutjes 1", LocationId = guids[16], MaxToddlersEachDay = 5 };
            Class c2 = new Class { Id = guids[17], Name = "De Tutjes 2", LocationId = guids[16], MaxToddlersEachDay = 5 };
            context.Classes.Add(c1);
            context.Classes.Add(c2);
            context.SaveChanges();



            Person Jan = new Person { Id = guids[5], FirstName = "Jan", LastName = "Janssens", Gender = Gender.Male };
            Person Carine = new Person { Id = guids[6], FirstName = "Carine", LastName = "Milis", Gender = Gender.Female };
            Person Lut = new Person { Id = guids[7], FirstName = "Lut", LastName = "Vermaelen", Gender = Gender.Female };
            Person Marc = new Person { Id = guids[8], FirstName = "Marc", LastName = "Van den Perre", Gender = Gender.Male };

            Toddler StevenVM = new Toddler { Id = guids[0], Gender = Gender.Male, DayOfBirth = new DateTime(1989, 01, 01), FirstName = "Steven", LastName = "Van Marcke", GuaranteePrice = 450 };
            Toddler Karo = new Toddler { Id = guids[1], Gender = Gender.Female, DayOfBirth = new DateTime(1989, 01, 01), FirstName = "Karo", LastName = "Van den Perre", GuaranteePrice = 450 };
            Toddler Stef = new Toddler { Id = guids[2], Gender = Gender.Female, DayOfBirth = new DateTime(1987, 09, 09), FirstName = "Stef", LastName = "Van den Perre", GuaranteePrice = 450 };
            Toddler StevenJ = new Toddler { Id = guids[3], Gender = Gender.Male, DayOfBirth = new DateTime(1988, 09, 20), FirstName = "Steven", LastName = "Janssens", GuaranteePrice = 450 };
            Toddler Kristof = new Toddler { Id = guids[4], Gender = Gender.Male, DayOfBirth = new DateTime(1986, 10, 22), FirstName = "Kristof", LastName = "Janssens", GuaranteePrice = 450 };

            var parents = new List<Person> { Jan, Carine, Lut, Marc };
            parents.ForEach(t => context.People.Add(t));
            context.SaveChanges();

            var toddlers = new List<Toddler> { StevenVM, Karo, Stef, StevenJ, Kristof };
            toddlers.ForEach(t => context.Toddlers.Add(t));
            context.SaveChanges();

            var CMFiles = new List<CMFile>();
            foreach (Toddler t in toddlers)
            {
                CMFile CMFile = new CMFile { Id = t.Id, Doctor = "Dr. Doolittle" };
                t.CMFile = CMFile;
                CMFiles.Add(CMFile);
            }
            CMFiles.ForEach(cmf => context.CMFiles.Add(cmf));
            context.SaveChanges();

            var ContactAssiociations = new List<ContactAssociation>()
            {
                new ContactAssociation{Contact1Id = guids[1], Contact2Id = guids[2], Association = Association.Sibling},
                new ContactAssociation{Contact1Id = guids[3], Contact2Id = guids[4], Association = Association.Sibling},
                new ContactAssociation{Contact1Id = guids[1], Contact2Id = guids[7], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[1], Contact2Id = guids[8], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[2], Contact2Id = guids[7], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[2], Contact2Id = guids[8], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[3], Contact2Id = guids[5], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[3], Contact2Id = guids[6], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[4], Contact2Id = guids[5], Association = Association.Parent},
                new ContactAssociation{Contact1Id = guids[4], Contact2Id = guids[6], Association = Association.Parent},
            };
            ContactAssiociations.ForEach(ca => context.ContactAssociations.Add(ca));
            context.SaveChanges();

            
            var AgreedPeriods = new List<AgreedPeriod>()
            {
                new AgreedPeriod{Id = guids[10], ToddlerId = guids[0], StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 12, 31), Monday = DayType.FullDay, Tuesday = DayType.FullDay, Wednesday = DayType.FullDay, Thursday = DayType.FullDay, Friday = DayType.FullDay, CreationDate= DateTime.Now, Active=true, Activated=true },
                new AgreedPeriod{Id = guids[11], ToddlerId = guids[1], StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 12, 31), Monday = DayType.FullDay, Tuesday = DayType.FullDay, Wednesday = DayType.FullDay, Thursday = DayType.FullDay, Friday = DayType.FullDay, CreationDate= DateTime.Now, Active=true, Activated=true },
                new AgreedPeriod{Id = guids[12], ToddlerId = guids[2], StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 12, 31), Monday = DayType.FullDay, Tuesday = DayType.FullDay, Wednesday = DayType.NotComing, Thursday = DayType.FullDay, Friday = DayType.NotComing, CreationDate= DateTime.Now, Active=true, Activated=true },
                new AgreedPeriod{Id = guids[13], ToddlerId = guids[3], StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 12, 31), Monday = DayType.FullDay, Tuesday = DayType.PM, Wednesday = DayType.NotComing, Thursday = DayType.FullDay, Friday = DayType.NotComing, CreationDate= DateTime.Now, Active=true, Activated=true },
                new AgreedPeriod{Id = guids[14], ToddlerId = guids[4], StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2018, 12, 31), Monday = DayType.FullDay, Tuesday = DayType.AM, Wednesday = DayType.NotComing, Thursday = DayType.PM, Friday = DayType.NotComing, CreationDate= DateTime.Now, Active =true, Activated=true },
                new AgreedPeriod{Id = guids[18], ToddlerId = guids[4], StartDate = new DateTime(2019, 1, 1), EndDate = new DateTime(2019, 12, 31), Monday = DayType.NotComing, Tuesday = DayType.PM, Wednesday = DayType.NotComing, Thursday = DayType.PM, Friday = DayType.FullDay, CreationDate= DateTime.Now, Active =true, Activated=true }

            };
            AgreedPeriods.ForEach(ap => context.AgreedPeriods.Add(ap));
            context.SaveChanges();

            
            foreach ( AgreedPeriod ap in AgreedPeriods)
            {
                List<AgreedDay> agreeddays = new List<AgreedDay>();
                                
                for (DateTime dt = ap.StartDate; dt <= ap.EndDate; dt = dt.AddDays(1))
                {
                    switch (dt.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            if (ap.Monday != DayType.NotComing)
                            {
                                AgreedDay ad = new AgreedDay();
                                ad.AgreedPeriodId = ap.Id;
                                ad.ToddlerId = ap.ToddlerId;
                                ad.Id = Guid.NewGuid();
                                ad.PaymentStatus = PaymentStatus.Open;
                                ad.Date = dt;
                                ad.DayType = ap.Monday;
                                ad.AgreedDayStatus = AgreedDaysStatus.FutureDay;
                                ad.ClassId = guids[15];
                                agreeddays.Add(ad);
                            }
                            break;
                        case DayOfWeek.Tuesday:
                            if (ap.Tuesday != DayType.NotComing)
                            {
                                AgreedDay ad = new AgreedDay();
                                ad.AgreedPeriodId = ap.Id;
                                ad.ToddlerId = ap.ToddlerId;
                                ad.Id = Guid.NewGuid();
                                ad.PaymentStatus = PaymentStatus.Open;
                                ad.Date = dt;
                                ad.DayType = ap.Tuesday;
                                ad.AgreedDayStatus = AgreedDaysStatus.FutureDay;
                                ad.ClassId = guids[15];
                                agreeddays.Add(ad);
                            }
                            break;
                        case DayOfWeek.Wednesday:
                            if (ap.Wednesday != DayType.NotComing)
                            {
                                AgreedDay ad = new AgreedDay();
                                ad.AgreedPeriodId = ap.Id;
                                ad.ToddlerId = ap.ToddlerId;
                                ad.Id = Guid.NewGuid();
                                ad.PaymentStatus = PaymentStatus.Open;
                                ad.Date = dt;
                                ad.DayType = ap.Wednesday;
                                ad.AgreedDayStatus = AgreedDaysStatus.FutureDay;
                                ad.ClassId = guids[15];
                                agreeddays.Add(ad);
                            }
                            break;
                        case DayOfWeek.Thursday:
                            if (ap.Thursday != DayType.NotComing)
                            {
                                AgreedDay ad = new AgreedDay();
                                ad.AgreedPeriodId = ap.Id;
                                ad.ToddlerId = ap.ToddlerId;
                                ad.Id = Guid.NewGuid();
                                ad.PaymentStatus = PaymentStatus.Open;
                                ad.Date = dt;
                                ad.DayType = ap.Thursday;
                                ad.AgreedDayStatus = AgreedDaysStatus.FutureDay;
                                ad.ClassId = guids[15];
                                agreeddays.Add(ad);
                            }
                            break;
                        case DayOfWeek.Friday:
                            if (ap.Friday != DayType.NotComing)
                            {
                                AgreedDay ad = new AgreedDay();
                                ad.AgreedPeriodId = ap.Id;
                                ad.ToddlerId = ap.ToddlerId;
                                ad.Id = Guid.NewGuid();
                                ad.PaymentStatus = PaymentStatus.Open;
                                ad.Date = dt;
                                ad.DayType = ap.Friday;
                                ad.AgreedDayStatus = AgreedDaysStatus.FutureDay;
                                ad.ClassId = guids[15];
                                agreeddays.Add(ad);
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
                agreeddays.ForEach(ads => context.AgreedDays.Add(ads));
                context.SaveChanges();
            }





            //var settings = new List<Settings>
            //{
            //    new Settings{
            //        Id = 1,
            //        CompanyName ="Kinderdagverblijf",
            //        Locations ="1",
            //        Classes ="2",

            //        WeWorkWithHalfDays =true,
            //        PayWhenIllness =true,
            //        WeBuyDiapers =true,
            //        SecondChildDiscount =true,
            //        SiblingNoGuarantee =true,
            //        PriceToPaycheck =true,

            //        DayPrice =25,
            //        HalfDayPrice =15,
            //        DiaperPrice =400,
            //        SecondChildDiscountPrice =24,
            //        PriceToPayCheckFactor =100}
            //};
            //settings.ForEach(s => context.Settings.Add(s));
            //context.SaveChanges();
        }
    }
}