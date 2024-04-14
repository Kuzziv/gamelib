﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Lootsystem.Models
{
    public interface IItem
    {
        string Name { get; }
        int Value { get; }
        void Use();
    }
}
