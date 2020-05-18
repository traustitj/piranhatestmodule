using System;
using Microsoft.EntityFrameworkCore;

namespace testmodule.EFModels
{
    public class Name
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
