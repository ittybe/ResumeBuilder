using System;
using System.Text;
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
            WorkTemplate2 workTemplate = new WorkTemplate2();
            workTemplate.Font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            byte[] bytes = Encoding.Default.GetBytes("something");
            
            workTemplate.Experience = new ResumeBuilderLib.Elements.InfoBlockDocument()
            {
                Header = "My Experience",
                Info = new string[]
                {
                    Encoding.UTF8.GetString(bytes),
                    "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab ",
                    "illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut ",
                    ", consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad ",
                    "reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                }
            };
            workTemplate.Education = new ResumeBuilderLib.Elements.InfoBlockDocument() 
            {
                Header = "My Education",
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
                    "istagramm: dslfjajfs",
                    "email: Lpx@gmail.com",
                    "+380 69 420 420",
                    "github: https://github.com/ittybe"
                }
            };
            workTemplate.Birthday = new ResumeBuilderLib.Elements.TextDocument()
            {
                Text = DateTime.Now.ToString()
            };
            workTemplate.Name = new ResumeBuilderLib.Elements.TextDocument()
            {
                Text = "Geralt of Rivia"
            };
            workTemplate.ProfileImage = new ResumeBuilderLib.Elements.ImageDocument()
            {
                Filepath = @"C:\Users\Lenovo\OneDrive\Pictures\Saved Pictures\aqua_(konosuba)1.jpg"
            };
            workTemplate.FontSize = 16;

            PDFBuilder builder = new PDFBuilder();
            builder.Build(workTemplate, "text.pdf");
        }
    }
}
