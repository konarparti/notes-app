﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotion.Model.Abstract
{
    public interface IRepository
    {
        IQueryable<Interest> Interests { get; }
        void SaveInterest(Interest interest);
        Interest? DeleteInterest(long interestsID);
    }
}