using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCDC_API.EntityFramework;
using GCDC_API.EntityFramework.Models;

namespace GCDC_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DownloadLogsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public DownloadLogsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/DownloadLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DownloadLog>>> GetDownloadLog()
        {
            return await _context.DownloadLogs.ToListAsync();
        }

        //GET: api/DownloadLogs/20190101/20193112
        [HttpGet("{fromDate}/{toDate}")]
        public async Task<ActionResult<IEnumerable<DownloadLog>>> GetDownloadLog([FromRoute] DateTime fromDate, [FromRoute] DateTime toDate)
        {
            return await _context.DownloadLogs.Where(x => x.Date >= fromDate && x.Date <= toDate).ToListAsync();
        }

        // POST: api/DownloadLogs
        [HttpPost]
        public async Task<ActionResult<DownloadLog>> PostDownloadLog(DownloadLog downloadLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.DownloadLogs.Add(downloadLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDownloadLog", new { id = downloadLog.Id }, downloadLog);
        }

    }
}
