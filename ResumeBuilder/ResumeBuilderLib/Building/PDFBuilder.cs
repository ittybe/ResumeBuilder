using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ResumeBuilderLib.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Building
{
    public class PDFBuilder : IPDFBuilder
    {
        public void Build(ITemplate template, string outputpath)
        {
            PdfDocument pdf = new PdfDocument(new PdfWriter(outputpath));
            Document document = new Document(pdf);
            var elements = template.GetElements();

            foreach (var element in elements)
            {
                if (element is AreaBreak)
                {
                    AreaBreak areaBreak = (AreaBreak)element;
                    document.Add(areaBreak);
                }
                else if (element is IBlockElement)
                {
                    IBlockElement blockElement = (IBlockElement)element;
                    document.Add(blockElement);
                }
                else if (element is Image) 
                {
                    Image image = (Image)element;
                    document.Add(image);
                }
            }
            document.Flush();
            document.Close();
        }
    }
}
