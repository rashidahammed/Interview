using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INT.Application.Contexts;

namespace INT.Application.Application.Interfaces
{
    public interface ICurrentUserContext
    {
        UserContext GetUserContext();
        void SetUserContext(UserContext userContext);
    }
}
