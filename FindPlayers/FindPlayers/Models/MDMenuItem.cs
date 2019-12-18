using System;
using System.Collections.Generic;
using System.Text;

namespace FindPlayers.Models
{
    public class MDMenuItem {
        public string Text { get; set; }
        public string IconSource { get; set; }
        public string Parameter { get; set; }

        public MDMenuItem(string Text, string IconSource, string Parameter) {
            this.Text = Text;
            this.IconSource = IconSource;
            this.Parameter = Parameter;
        }
    }
}
