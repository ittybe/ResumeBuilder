using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResumeBuilderLib.ConvertingPdf
{
    public class Converter
    {
        public Document Document { get; set; }

        public Converter(string filepath, FileFormat fileFormat) 
        {
            Document = new Document(filepath, fileFormat);
        }

        public void Convert(string output, FileFormat fileFormat) 
        {
            Document.SaveToFile(output, fileFormat);
        }

        public void ConvertToImage(FileInfo output, Spire.Doc.Documents.ImageType imageType) 
        {
            //for (int i = 1; i < Document.PageCount; i++)
            //{
            //    //int indexPoint = output.Name.LastIndexOf('.');
            //    //string Name;
            //    //if (indexPoint >= 0)
            //    //    Name = output.Name.Substring(0, indexPoint) + i;
            //    //else
            //    //    Name = output.Name + i;
            //}
            Document.SaveToImages(0, Document.PageCount, imageType);
        }
    }
}
