using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFocus.Shared.DTOs.Profile
{
    public class LeaderboardEntryDto
    {
        public string Username { get; set; } = string.Empty;
        public int TotalPoints { get; set; }
    }
}
