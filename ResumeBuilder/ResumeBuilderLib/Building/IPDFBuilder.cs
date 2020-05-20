using ResumeBuilderLib.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Building
{
    /// <summary>
    /// resume builder to pdf format
    /// </summary>
    public interface IPDFBuilder
    {
        /// <summary>
        /// build pdf file from template to outputpath
        /// </summary>
        /// <param name="template">resume template</param>
        /// <param name="outputpath">output path</param>
        void Build(ITemplate template, string outputpath);
    }
}
