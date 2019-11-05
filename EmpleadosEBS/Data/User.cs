﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Data
{
    
    public class User : IdentityUser
    {
        [PersonalData]
        public DateTime Registro { get; set; }

    }
}
