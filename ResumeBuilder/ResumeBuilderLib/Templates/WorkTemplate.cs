using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Layout.Borders;
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
        [NonSerialized]
        private PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
        private PdfFont Font { get { return font; } set { font = value; } }
        //private PdfFont Font { get; set; } = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

        public float FontSize { get; set; } = 16;

        public WorkTemplate() 
        {
            Experience = new InfoBlockDocument();
            ProfileImage = new ImageDocument();
            Name = new TextDocument();
            ContactInfo = new InfoBlockDocument();
            Birthday = new TextDocument();
        }
        
        public InfoBlockDocument Experience { get; set; }

        public ImageDocument ProfileImage { get; set; }

        public TextDocument Name { get; set; }

        public InfoBlockDocument ContactInfo { get; set; }

        public TextDocument Birthday { get; set; }

        public IElement[] GetElements()
        {
            List<IElement> result = new List<IElement>();

            // add profile image 
            //result.Add(GetImage(ProfileImage));

            float[] columnWidth = { 150, 150 };
            Table table = new Table(columnWidth);
            table.UseAllAvailableWidth();

            Cell cell = new Cell();
            // add name
            foreach (var item in GetName())
            {
                cell.Add(item);
            }
            // add Birthday
            foreach (var item in GetBirthday())
            {
                cell.Add(item);
            }
            table.AddCell(cell);
            cell.SetBorder(Border.NO_BORDER);

            table.AddCell(new Cell().Add(GetImage(ProfileImage)).SetBorder(Border.NO_BORDER));
            result.Add(table);

            

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

            float headerScale = 1.4f;
            result.Add(new Paragraph(infoBlock.Header).SetFont(Font).SetFontSize(FontSize * headerScale));
            
            List listPdf = new List().SetFont(Font).SetFontSize(FontSize); // package list not usual one 
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
            result.Add(new Paragraph(textDocument.Text).SetFont(Font).SetFontSize(FontSize));
            return result.ToArray();
        }

        private IBlockElement[] GetBirthday() 
        {
            List<IBlockElement> result = new List<IBlockElement>();
            float birthdayScale = 1.7f;
            result.Add(new Paragraph(Birthday.Text).SetFont(Font).SetFontSize(FontSize * birthdayScale));
            return result.ToArray();
        }

        private IBlockElement[] GetName()
        {
            List<IBlockElement> result = new List<IBlockElement>();
            float nameScale = 1.8f;
            
            result.Add(new Paragraph(Name.Text).SetFont(Font).SetFontSize(FontSize * nameScale));
            return result.ToArray();
        }


        private Image GetImage(ImageDocument imageDocument) 
        {
            ImageData imageData = ImageDataFactory.Create(imageDocument.Filepath);
            // Create layout image object and provide parameters. Page number = 1
            Image image = new Image(imageData).SetWidth(150).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);
            return image;
        }


    }
}
