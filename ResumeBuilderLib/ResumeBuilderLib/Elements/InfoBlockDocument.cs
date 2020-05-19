using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Elements
{
    /// <summary>
    /// info block format list 
    /// </summary>
    public class InfoBlockDocument : ElementDocument
    {
        /// <summary>
        /// header of list
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// string list for listing this info in pdf file 
        /// </summary>
        public string[] Info { get; set; }
    }
}
