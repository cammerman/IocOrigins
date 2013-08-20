﻿using IocOrigins.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocOrigins.DataCommands.Services
{
    public interface IPromoteUserService
    {
        void Promote(IDataTransaction tx, string username);
    }
}