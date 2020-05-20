using iText.IO.Image;
using iText.Kernel.Font;
using iText.Layout.Element;
using ResumeBuilderLib.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Templates
{
    [Serializable]
    public class WorkTemplate : ITemplate
    {
        public PdfFont Font { get; set; }

        public InfoBlockDocument Experience { get; set; }

        public ImageDocument ProfileImage { get; set; }

        public TextDocument Name { get; set; }

        public InfoBlockDocument ContactInfo { get; set; }

        public TextDocument Birthday { get; set; }

        public IElement[] GetElements()
        {
            List<IElement> result = new List<IElement>();

            // add profile image 
            result.Add(GetImage(ProfileImage));

            // add name
            foreach (var item in GetText(Name))
            {
                result.Add(item);
            }

            // add Birthday
            foreach (var item in GetText(Birthday))
            {
                result.Add(item);
            }

            // add ContactInfo
            foreach (var item in GetBlock(ContactInfo))
            {
                result.Add(item);
            }

            // add experience
            foreach (var item in GetBlock(Experience))
            {
                result.Add(item);
            }

            return result.ToArray();
        }

        private IBlockElement[] GetBlock(InfoBlockDocument infoBlock)
        {
            List<IBlockElement> result = new List<IBlockElement>();

            result.Add(new Paragraph(infoBlock.Header).SetFont(Font));
            
            List listPdf = new List().SetFont(Font); // package list not usual one 
            foreach (var item in infoBlock.Info)
            {
                listPdf.Add(new ListItem(item));
            }
            result.Add(listPdf);

            return result.ToArray();
        }

        private IBlockElement[] GetText(TextDocument textDocument) 
        {
            List<IBlockElement> result = new List<IBlockElement>();
            result.Add(new Paragraph(textDocument.Text).SetFont(Font));
            return result.ToArray();
        }

        private Image GetImage(ImageDocument imageDocument) 
        {
            ImageData imageData = ImageDataFactory.Create(imageDocument.Filepath);
            // Create layout image object and provide parameters. Page number = 1
            Image image = new Image(imageData).ScaleAbsolute(100, 200).SetFixedPosition(1, 25, 25);
            return image;
        }
    }
}
