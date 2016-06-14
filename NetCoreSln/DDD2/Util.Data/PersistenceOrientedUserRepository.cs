﻿using Domains.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Data
{
    public interface PersistenceOrientedUserRepository
    {
        void save(User user);
        User userById(String userId);
        List<User> allUsers();
        void remove(User user); 
    }
}
