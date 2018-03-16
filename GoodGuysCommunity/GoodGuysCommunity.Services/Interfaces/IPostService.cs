﻿using GoodGuysCommunity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
    }
}
