using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
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
    public class WorkTemplate2 : ITemplate
    {
        public PdfFont Font { get; set; } = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);


        public float FontSize { get; set; } = 16;

        public InfoBlockDocument Experience { get; set; }

        public ImageDocument ProfileImage { get; set; }

        public InfoBlockDocument Education { get; set; }

        public TextDocument Name { get; set; }

        public InfoBlockDocument ContactInfo { get; set; }

        public TextDocument Birthday { get; set; }

        private float imageWidth = 150;

        public IElement[] GetElements()
        {
            List<IElement> result = new List<IElement>();
            
            float[] columnWidth = { 150, 150 };
            Table table = new Table(columnWidth);
            table.UseAllAvailableWidth();

            // add image
            
            Cell imageCell = new Cell().SetBorder(Border.NO_BORDER); //
            imageCell.SetWidth(imageWidth);
            imageCell.Add(GetImage(ProfileImage));
            table.AddCell(imageCell);
            
            // add personal info
            
            Cell nameCell = new Cell();
            nameCell.SetBorder(Border.NO_BORDER);
            foreach (var item in GetName())
            {
                nameCell.Add(item);
            }
            foreach (var item in GetText(Birthday))
            {
                nameCell.Add(item);
            }
            table.AddCell(nameCell);

            result.Add(table);
            
            // ADD CONTANT INFO
            
            float[] columnWidthContact = { 150, 150, 150, 150 };
            Table tableContact = new Table(columnWidthContact);
            tableContact.UseAllAvailableWidth();

            foreach (var parag in GetContactInfo())
            {
                Cell cellContact = new Cell();

                cellContact.Add(parag);
                cellContact.SetBorder(Border.NO_BORDER);

                tableContact.AddCell(cellContact);
            }
            Color bgContact = new DeviceRgb(240, 240, 240);
            tableContact.SetBackgroundColor(bgContact);
            result.Add(tableContact);

            // ADD EXP and Education
            float[] columnWidthExpAndEducation = { 150, 150 };
            Table table_ExpAndEducation = new Table(columnWidthExpAndEducation);
            table_ExpAndEducation.UseAllAvailableWidth();

            // add exp
            Cell cellExp = new Cell();
            cellExp.SetBorder(Border.NO_BORDER);
            foreach (var item in GetBlock(Experience))
            {
                cellExp.Add(item);
            }
            table_ExpAndEducation.AddCell(cellExp);

            // add education
            Cell cellEduc = new Cell();
            cellEduc.SetBorder(Border.NO_BORDER);
            foreach (var item in GetBlock(Education))
            {
                cellEduc.Add(item);
            }
            table_ExpAndEducation.AddCell(cellEduc);

            result.Add(table_ExpAndEducation);

            return result.ToArray();
        }

        private IBlockElement[] GetContactInfo() 
        {
            List<IBlockElement> result = new List<IBlockElement>();
            foreach (var info in ContactInfo.Info)
            {
                result.Add(new Paragraph(info));
                
            }
            return result.ToArray();
        }

        private IBlockElement[] GetName()
        {
            List<IBlockElement> result = new List<IBlockElement>();
            float nameScale = 1.8f;
            result.Add(new Paragraph(Name.Text).SetFont(Font).SetFontSize(FontSize * nameScale).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT));
            return result.ToArray();
        }

        private Image GetImage(ImageDocument imageDocument)
        {
            ImageData imageData = ImageDataFactory.Create(imageDocument.Filepath);
            // Create layout image object and provide parameters. Page number = 1
            Image image = new Image(imageData).SetWidth(imageWidth).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
            return image;
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
            result.Add(new Paragraph(textDocument.Text).SetFont(Font).SetFontSize(FontSize).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT));
            return result.ToArray();
        }
    }
}
