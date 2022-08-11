﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Configurations
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public double ExpireInHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
