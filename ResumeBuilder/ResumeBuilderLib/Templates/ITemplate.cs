using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Templates
{
    /// <summary>
    /// template for document pdf
    /// (template also contains ElementDocument objects)
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// get pdf itext package elements
        /// </summary>
        /// <returns>elements to PDFBuilder</returns>
        iText.Layout.Element.IElement[] GetElements();
    }
}
