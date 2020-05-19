using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Elements
{
    /// <summary>
    /// text in document
    /// </summary>
    public class TextDocument : ElementDocument
    {
        /// <summary>
        /// text
        /// </summary>
        public string Text { get; set; }
    }
}
