using INT.Application.Application.Interfaces;
using INT.Domain.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Application.Application.Services
{
    public class RoleServices: IRoleServices
    {
        private readonly IRoleRepositories _repo;
        public RoleServices(IRoleRepositories repo) { 
            _repo = repo;
        }

        //public

       
    }
}
