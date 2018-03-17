using GoodGuysCommunity.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface ICommentService
    {
        Task Add(string Content, string AuthorId, int PostId);
    }
}
