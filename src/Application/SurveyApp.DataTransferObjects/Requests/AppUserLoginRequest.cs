﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class AppUserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
