using System;

namespace GCDC_API.EntityFramework.Models
{
    public class DownloadLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
