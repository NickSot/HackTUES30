using GoodGuysCommunity.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface ICommentService
    {
        Comment Add(string Content, int CommentId, int PostId);
        void Update();
    }
}
