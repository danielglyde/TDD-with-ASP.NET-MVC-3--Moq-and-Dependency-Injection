using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBlog.Models
{
    public interface IBlogsRepository
    {
        IEnumerable<BlogEntry> GetAllBlogEntries();
    }
}
