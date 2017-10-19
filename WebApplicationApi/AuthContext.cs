﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationApi
{
  public class AuthContext : IdentityDbContext<IdentityUser>
  {
    public AuthContext() : base("AuthContext")
    {
    }
  }
}
