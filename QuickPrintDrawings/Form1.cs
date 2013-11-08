using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Tekla.Structures.Catalogs;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model.Operations;
using TSM = Tekla.Structures.Model;

namespace QuickPrintDrawings
{
    public partial class button1 : Form
    {
        private ArrayList aDrawings = new ArrayList();

        public button1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            DrawingHandler MyDrawingHandler = new DrawingHandler();
            int nDrawings = 0;
            if (MyDrawingHandler.GetConnectionStatus())
            {
                DrawingEnumerator SelectedDrawings = MyDrawingHandler.GetDrawingSelector().GetSelected();
                int iCounter = 0;
                while (SelectedDrawings.MoveNext())
                {
                    iCounter++;
                }
                nDrawings = iCounter;
            }

            progressBar1.Minimum = 0;
            progressBar1.Maximum = nDrawings;
            progressBar1.Step = 1;

            if (MyDrawingHandler.GetConnectionStatus())
            {
                DrawingEnumerator SelectedDrawings = MyDrawingHandler.GetDrawingSelector().GetSelected();
                int iCounter = 1;
                while (SelectedDrawings.MoveNext())
                {
                    progressBar1.PerformStep();

                    Drawing currentDrawing = SelectedDrawings.Current;
                    ListViewItem currentRow = new ListViewItem(currentDrawing.Mark);

                    currentRow.SubItems.Add(currentDrawing.Name);
                    string strHeight = currentDrawing.Layout.SheetSize.Height.ToString();
                    string strWidth = currentDrawing.Layout.SheetSize.Width.ToString();
                    currentRow.SubItems.Add(strWidth + "x" + strHeight);
                    string PrinterInstance = "QP_" + strWidth + "x" + strHeight;

                    //TSM.Operations.Operation.DisplayPrompt("Drawing " + currentDrawing.Name + ": " + iCounter.ToString() + "/" + nDrawings.ToString());
                    lblMessage.Text = "";
                    lblMessage.Text = "Drawing " + currentDrawing.Name + ": " + iCounter.ToString() + "/" + nDrawings.ToString();
                    iCounter++;

                    if (chkPDF.Checked)
                        WriteCurrentDrawing(currentDrawing, PrinterInstance);

                    if (chkDWG.Checked)
                        PrintToFile(currentDrawing);
                }
            }

            //TSM.Operations.Operation.DisplayPrompt("Write command completed!");
            lblMessage.Text = "Write command completed!";
            progressBar1.Value = 0;
        }

        private bool PrintToFile(Drawing currentDrawing)
        {
            bool Result = false;
            double scale = 1.0;

            if (rbtnSCALE.Checked)
            {
                //get scale of the first view
                //scale = GetScaleFromTheView();
            }

            DrawingHandler MyDrawingHandler = new DrawingHandler();
            PrintAttributes printAttributes = new PrintAttributes();
            printAttributes.Scale = scale;
            printAttributes.PrintToMultipleSheet = false;
            printAttributes.NumberOfCopies = 1;
            printAttributes.Orientation = DotPrintOrientationType.Auto;
            printAttributes.PrintArea = DotPrintAreaType.EntireDrawing;
            printAttributes.PrinterInstance = "DWG";

            string DrawingType = GetDrawingTypeCharacter(currentDrawing);

            /*
set XS_DRAWING_PLOT_FILE_DIRECTORY=.\PlotFiles
set XS_DRAWING_PLOT_FILE_NAME_A=%%UDA:PROJECT_USERFIELD_1%%-%%NAME.-%%%%REV_MARK?_Rev%%%%REV_MARK%%
set XS_DRAWING_PLOT_FILE_NAME_W=%%UDA:PROJECT_USERFIELD_1%%-%%NAME.-%%%%REV_MARK?_Rev%%%%REV_MARK%%
set XS_DRAWING_PLOT_FILE_NAME_C=%%UDA:PROJECT_USERFIELD_1%%-%%NAME.-%%%%REV_MARK?_Rev%%%%REV_MARK%%
set XS_DRAWING_PLOT_FILE_NAME_G=%%UDA:PROJECT_USERFIELD_1%%-%%TITLE.-%%%%REV_MARK?_Rev%%%%REV_MARK%%
set XS_DRAWING_PLOT_FILE_NAME_M=%%UDA:PROJECT_USERFIELD_1%%-%%TITLE.-%%%%REV_MARK?_Rev%%%%REV_MARK%%
             */

            //string output_path = Environment.GetEnvironmentVariable("XS_DRAWING_PLOT_FILE_DIRECTORY");
            string output_path = "c:\\pdf";
            string output_file = "out.dwg";

            Model CurrentModel = new Model();
            ProjectInfo ProjectInfo = CurrentModel.GetProjectInfo();
            if (CurrentModel.GetConnectionStatus())
            {
                output_file = ProjectInfo.ProjectNumber;
            }

            string DrawingName = "";

            //TSM.Operations.Operation.DisplayPrompt("DrawingType" + DrawingType);

            switch (DrawingType)
            {
                case "A":
                //output_file = Environment.GetEnvironmentVariable("XS_DRAWING_PLOT_FILE_NAME_A");
                case "W":
                //output_file = Environment.GetEnvironmentVariable("XS_DRAWING_PLOT_FILE_NAME_W");
                case "C":
                    //output_file = Environment.GetEnvironmentVariable("XS_DRAWING_PLOT_FILE_NAME_C");
                    DrawingName = currentDrawing.Mark;
                    DrawingName = RemoveBrackets(DrawingName);
                    break;
                case "G":
                //output_file = Environment.GetEnvironmentVariable("XS_DRAWING_PLOT_FILE_NAME_G");
                case "M":
                    //output_file = Environment.GetEnvironmentVariable("XS_DRAWING_PLOT_FILE_NAME_M");
                    DrawingName = currentDrawing.Name;
                    break;
                default:
                    goto case "A";
            }

            DrawingName = DrawingName.Replace('.', '-');
            output_file += "-" + DrawingName + ".dwg";

            if (!String.IsNullOrEmpty(output_path) && !String.IsNullOrEmpty(output_file))
                Result = MyDrawingHandler.PrintDrawing(currentDrawing, printAttributes, output_path + "\\" + output_file);

            return Result;
        }

        private string RemoveBrackets(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                int iS = inputString.IndexOf("[");
                if (iS != -1)
                    inputString = inputString.Remove(iS, 1);
                iS = inputString.IndexOf("]");
                if (iS != -1)
                    inputString = inputString.Remove(iS, 1);
            }

            return inputString;
        }

        private string GetDrawingTypeCharacter(Drawing DrawingInstance)
        {
            string Result = "U"; // Unknown drawing

            if (DrawingInstance is GADrawing)
            {
                Result = "G";
            }
            else if (DrawingInstance is AssemblyDrawing)
            {
                Result = "A";
            }
            else if (DrawingInstance is CastUnitDrawing)
            {
                Result = "C";
            }
            else if (DrawingInstance is MultiDrawing)
            {
                Result = "M";
            }
            else if (DrawingInstance is SinglePartDrawing)
            {
                Result = "W";
            }

            return Result;
        }

        private bool WriteCurrentDrawing(Drawing currentDrawing, string PrinterInstance)
        {
            bool Result = false;
            DrawingHandler MyDrawingHandler = new DrawingHandler();
            PrintAttributes printAttributes = new PrintAttributes();
            printAttributes.Scale = 1.0;
            printAttributes.PrintToMultipleSheet = false;
            printAttributes.NumberOfCopies = 1;
            printAttributes.Orientation = DotPrintOrientationType.Auto;
            printAttributes.PrintArea = DotPrintAreaType.EntireDrawing;
            printAttributes.PrinterInstance = PrinterInstance;

            Result = MyDrawingHandler.PrintDrawing(currentDrawing, printAttributes);

            return Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawingHandler MyDrawingHandler = new DrawingHandler();

            PrintAttributes printAttributes = new PrintAttributes();
            printAttributes.Scale = 1.0;
            printAttributes.PrintToMultipleSheet = false;
            printAttributes.NumberOfCopies = 1;
            printAttributes.Orientation = DotPrintOrientationType.Auto;
            printAttributes.PrintArea = DotPrintAreaType.EntireDrawing;
            printAttributes.PrinterInstance = "PDF_594x420";

            if (MyDrawingHandler.GetConnectionStatus())
            {
                DrawingEnumerator SelectedDrawings = MyDrawingHandler.GetDrawingSelector().GetSelected();
                while (SelectedDrawings.MoveNext())
                {
                    Drawing currentDrawing = SelectedDrawings.Current;

                    //Get print attributes: we need only PrinterInstance
                    MyDrawingHandler.PrintDrawing(currentDrawing, printAttributes);
                }
            }
        }
    }
}










