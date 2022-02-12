using System;
using System.Collections.Generic;

namespace MyNotion
{
    public partial class Interest
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Scope { get; set; }
        public string? Status { get; set; }
        public string? Progress { get; set; }
    }
}
