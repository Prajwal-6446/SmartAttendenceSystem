﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_DataAccess.Repository
{
    public interface IMarkAttendenceRepository
    {
        public bool UserExtistnce(int id);

        public Tuple<bool,string>markUserAttendence(int id);
    }
}
