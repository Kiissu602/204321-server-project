﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Setting
{
    public class UserSettings : IUserSettings
    {
        public string Secret { get; set; }
    }

    public interface IUserSettings
    {
        public string Secret { get; set; }
    }
}

