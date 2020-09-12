using System;
using System.Collections.Generic;

namespace DeskPlan.Core.Entities
{
    public partial class Sysdiagrams
    {
        public string Name { get; set; }
        public long PrincipalId { get; set; }
        public long DiagramId { get; set; }
        public long? Version { get; set; }
        public byte[] Definition { get; set; }
    }
}
