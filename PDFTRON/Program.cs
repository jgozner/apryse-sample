// See https://aka.ms/new-console-template for more information

using pdftron;
using pdftron.PDF;
using pdftron.SDF;

PDFNet.Initialize("demo:1701731196462:7ca228c103000000005e46581a1882b46379dc11c8003a58246516df04");
HTML2PDF.SetModulePath("./HTML2PDF");

if (!HTML2PDF.IsModuleAvailable())
{
    Console.WriteLine();
    Console.WriteLine("Unable to run HTML2PDFTest: PDFTron SDK HTML2PDF module not available.");
    Console.WriteLine("---------------------------------------------------------------");
    Console.WriteLine("The HTML2PDF module is an optional add-on, available for download");
    Console.WriteLine("at http://www.pdftron.com/. If you have already downloaded this");
    Console.WriteLine("module, ensure that the SDK is able to find the required files");
    Console.WriteLine("using the HTML2PDF.SetModulePath() function.");
    Console.WriteLine();
    return;
}

try
{
    using (PDFDoc doc = new PDFDoc())
    {
        HTML2PDF converter = new HTML2PDF();

        string html = "<html><body><h1>Heading</h1><p><Paragraph.</p></body></html>";

        converter.InsertFromHtmlString(html);

        converter.Convert(doc);

        doc.Save("Sample.pdf", SDFDoc.SaveOptions.e_linearized);
    }
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}

