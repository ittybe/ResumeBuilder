using System;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using ResumeBuilderLib;
using ResumeBuilderLib.Building;
using ResumeBuilderLib.Templates;

namespace ResumeBuilderTests
{
    class Program
    {
        //Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab 
        //illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut 
        //fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet
        //, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad 
        //minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure 
        //reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?
        static void Main(string[] args)
        {
            //Document document = new Document();
            //document.Add();
            //AreaBreak
            WorkTemplate workTemplate = new WorkTemplate();
            workTemplate.Font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            workTemplate.Experience = new ResumeBuilderLib.Elements.InfoBlockDocument()
            {
                Header = "My exp",
                Info = new string[]
                {
                    "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab ",
                    "illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut ",
                    ", consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad ",
                    "reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                }
            };
            workTemplate.ContactInfo = new ResumeBuilderLib.Elements.InfoBlockDocument()
            {
                Header = "My contacts",
                Info = new string[]
                {
                    "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab ",
                    "illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut",
                    "consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad",
                    "reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                }
            };

            workTemplate.Birthday = new ResumeBuilderLib.Elements.TextDocument()
            {
                Text = DateTime.Now.ToLongDateString()
            };

            workTemplate.Name = new ResumeBuilderLib.Elements.TextDocument()
            {
                Text = "Gerald form Rivia"
            };

            workTemplate.ProfileImage = new ResumeBuilderLib.Elements.ImageDocument()
            {
                Filepath = @"C:\Users\Lenovo\OneDrive\Pictures\Saved Pictures\aqua_(konosuba)1.jpg"
            };


            PDFBuilder builder = new PDFBuilder();
            builder.Build(workTemplate, "text.pdf");
        }
    }
}
