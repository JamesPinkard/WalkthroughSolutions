using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Ink;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Markup;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Be in Ink mode by defualt.
            this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.comboColors.SelectedIndex = 0;            
            this.inkRadio.IsChecked = true;
            PopulateDocument();
            EnableAnnotations();

            // Rig up some Click handlers for the save/load of the flow doc.
            btnSaveDoc.Click += (o, s) =>
            {
                using (FileStream fStream = File.Open("documentData.xaml", FileMode.Create))
                {
                    XamlWriter.Save(this.myDocumentReader.Document, fStream);
                }
            };

            btnLoadDoc.Click += (o, s) =>
                {
                    using (FileStream fStream = File.Open("documentData.xaml", FileMode.Open))
                    {
                        try
                        {
                            FlowDocument doc = XamlReader.Load(fStream) as FlowDocument;
                            this.myDocumentReader.Document = doc;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error Loading Doc!");
                        }
                    }
                };
        }

        private void RadioButton_Clicked(object sender, RoutedEventArgs e)
        {
            /* Based on which button sent the event,
             * place the InkCanvas in a unique mode of operation */
            switch ((sender as RadioButton).Content.ToString())
            {
                /* These strings must be the same
                 * as the Content values for each RadioButton */
                case "Ink Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
             
        }

        private void Color_Changed(object sender, SelectionChangedEventArgs e)
        {
            // Get the Tag of the selected StackPanel.
            string colorToUse = (this.comboColors.SelectedItem as StackPanel).Tag.ToString();

            // Change the color used to render the strokes.
            this.myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            // Save all data on the InkCanvas to a local file.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.myInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            // Fill StrokeCollection from file.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.myInkCanvas.Strokes = strokes;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            // Clear all strokes.
            this.myInkCanvas.Strokes.Clear();
        }

        private void PopulateDocument()
        {
            // Add some data to the List item.
            this.listOfFunFacts.FontSize = 14;
            this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            this.listOfFunFacts.ListItems.Add(
                new ListItem(
                    new Paragraph(
                        new Run("Fixed documents are for WYSIWYG print ready docs!"))));
            this.listOfFunFacts.ListItems.Add(
                new ListItem(
                    new Paragraph(
                        new Run("Flow documents are read only!"))));
            this.listOfFunFacts.ListItems.Add(
                new ListItem(
                    new Paragraph(
                        new Run("BlockUIContainer allows you to embed WPF controls in the document!"))));

            // Now add some data to the Paragraph.
            // First part of sentence.
            Run prefix = new Run("This paragraph was generated ");

            // Middle of paragraph.
            Bold b = new Bold();
            Run infix = new Run ("dynamically");
            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);

            // Last part of paragraph.
            Run suffix = new Run(" at runtime!");

            // Now add each piece to the collection
            // of inline elements of the Paragraph.
            this.paraBodyText.Inlines.Add(prefix);
            this.paraBodyText.Inlines.Add(infix);
            this.paraBodyText.Inlines.Add(suffix);
        }

        private void EnableAnnotations()
        {
            // Create the AnnotationService object that works
            // with our FlowDocumentReader.
            AnnotationService annoService = new AnnotationService(myDocumentReader);

            // Create a MemoryStream that will hold the annotations.
            MemoryStream annoStream = new MemoryStream();

            /* Now, create an XML-based store based on the MemoryStream.
             * You could use this object to programmatically add, delete,
             * or find annotations. */
            AnnotationStore store = new XmlStreamStore(annoStream);

            // Enable the annotation services.
            annoService.Enable(store);
        }
    }
}
