﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    internal interface IKYCRule
    {
        bool Verify(Customer customer,String sign);
    }
}
