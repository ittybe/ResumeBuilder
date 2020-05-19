using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Elements
{
    /// <summary>
    /// image document
    /// </summary>
    public class ImageDocument: ElementDocument
    {
        /// <summary>
        /// filepath to image
        /// </summary>
        public string Filepath { get; set; }
    }
}
