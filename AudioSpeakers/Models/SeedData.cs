using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AudioSpeakers.Data;


namespace AudioSpeakers.Models
{
    public class SeedData 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AudioSpeakersContext(
                serviceProvider.GetRequiredService<DbContextOptions<AudioSpeakersContext>>()))
            {
                // Look for any movies.
                if (context.Speakers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Speakers.AddRange(
                    new Speakers
                    {
                        Title = "BT 150",
                        ReleaseDate = DateTime.Parse("2014-2-12"),
                        Type = "Wireless",
                        Rating = 8,
                        Price = 7.99M
                    },

                    new Speakers
                    {
                        Title = "Noise 300",
                        ReleaseDate = DateTime.Parse("2018-3-13"),
                        Type = "Wireless",
                        Rating = 7,
                        Price = 8.99M
                    },

                    new Speakers
                    {
                        Title = "simple Fan Edition",
                        ReleaseDate = DateTime.Parse("2015-2-23"),
                        Type = "Wired",
                        Price = 9.99M,
                        Rating = 8,
                    },

                    new Speakers
                    {
                        Title = "Bassss 400",
                        ReleaseDate = DateTime.Parse("2019-4-15"),
                        Type = "Wired",
                        Rating = 9,
                        Price = 3.99M
                    },

                    new Speakers
                    {
                        Title = "Bassss 200",
                        ReleaseDate = DateTime.Parse("2012-4-15"),
                        Type = "Wired",
                        Rating = 5,
                        Price = 3.99M
                    },

                    new Speakers
                    {
                        Title = "rock 400",
                        ReleaseDate = DateTime.Parse("2019-4-15"),
                        Type = "Wired and Wireless",
                        Rating = 9,
                        Price = 9.99M
                    },

                    new Speakers
                    {
                        Title = "rock 250",
                        ReleaseDate = DateTime.Parse("2020-4-15"),
                        Type = "Wired and Wireless",
                        Rating = 9,
                        Price = 8.99M
                    },

                    new Speakers
                    {
                        Title = "BT 400",
                        ReleaseDate = DateTime.Parse("2017-8-10"),
                        Type = "Wireless",
                        Rating = 9,
                        Price = 23.99M
                    },
                    new Speakers
                    {
                        Title = "Noise 600",
                        ReleaseDate = DateTime.Parse("2015-8-15"),
                        Type = "Wired",
                        Rating = 9,
                        Price = 13.99M
                    },
                    new Speakers
                    {
                        Title = "BT 200",
                        ReleaseDate = DateTime.Parse("2016-2-19"),
                        Type = "Wireless",
                        Rating = 9,
                        Price = 6.99M
                    }


                ) ;
                context.SaveChanges();
            }
        }
    }
}
