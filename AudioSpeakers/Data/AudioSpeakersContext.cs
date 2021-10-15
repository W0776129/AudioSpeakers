using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AudioSpeakers.Models;

namespace AudioSpeakers.Data
{
    public class AudioSpeakersContext : DbContext
    {
        public AudioSpeakersContext (DbContextOptions<AudioSpeakersContext> options)
            : base(options)
        {
        }

        public DbSet<AudioSpeakers.Models.Speakers> Speakers { get; set; }
    }
}
