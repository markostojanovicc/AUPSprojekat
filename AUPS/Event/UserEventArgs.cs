using AUPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Event
{
    public class UserEventArgs : EventArgs
    {
        public User loggedUser;
    }
}
