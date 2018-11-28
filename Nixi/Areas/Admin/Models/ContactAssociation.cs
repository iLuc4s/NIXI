using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class ContactAssociation
    {
        public int ContactAssociationId { get; set; }
        public Guid Contact1Id { get; set; }
        public Guid Contact2Id { get; set; }
        public Association Association { get; set; }
    }
}