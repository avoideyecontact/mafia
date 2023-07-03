using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Organization : Entity
    {
        public OrganizationTypes OrganizationTypeId { get; private set; }

    }
}
