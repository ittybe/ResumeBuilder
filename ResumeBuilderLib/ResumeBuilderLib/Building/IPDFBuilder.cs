using ResumeBuilderLib.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilderLib.Building
{
    public interface IPDFBuilder
    {
        void Build(ITemplate template, string outputpath);
    }
}
