using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApi.Core.Entities;

namespace BlogApi.Infrastructure.Data
{
    public interface IBlogDatabaseContext
    {
        // BlogApi.Infrastructure.Data/IBlogDatabaseContext.cs


            DbSet<Post> Posts { get; set; }
            DbSet<Comment> Comments { get; set; }

        Task<int> SaveChangesAsync();

    }

}

