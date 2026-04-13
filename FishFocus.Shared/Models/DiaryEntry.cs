using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FishFocus.Shared.Models;

public class DiaryEntry
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CompletionTime { get; set; }
    public int MinutesSpent { get; set; }
    public string FishName { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}