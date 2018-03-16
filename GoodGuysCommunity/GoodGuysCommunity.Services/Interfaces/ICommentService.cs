using System;
using System.Collections.Generic;
using System.Text;

namespace GoodGuysCommunity.Services.Interfaces
{
    interface ICommentService
    {
        void Add(string Content, string AuthorId, int PostId);
        void Update();
    }
}
