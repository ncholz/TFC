using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Prueba_pizarra
{
    // Le decimos explícitamente que use el UserControl de WPF
    public partial class PizarraTactical : System.Windows.Controls.UserControl
    {
        bool estaArrastrando = false;
        System.Windows.Point clickPosition; // Especificamos que es el Point de WPF
        UIElement elementoArrastrado;

        // Fíjate: Esto solo debe aparecer UNA vez en todo el archivo
        public PizarraTactical()
        {
            InitializeComponent();

            ActivarModoMover();

            PizarraInk.DefaultDrawingAttributes.Color = Colors.White;
            PizarraInk.DefaultDrawingAttributes.Width = 4;
            PizarraInk.DefaultDrawingAttributes.Height = 4;
            PizarraInk.DefaultDrawingAttributes.FitToCurve = true;
        }

        private void BtnModoMover_Click(object sender, RoutedEventArgs e) { ActivarModoMover(); }
        private void BtnModoDibujar_Click(object sender, RoutedEventArgs e)
        {
            PizarraInk.EditingMode = InkCanvasEditingMode.Ink;
            PizarraInk.IsHitTestVisible = true;
        }
        private void BtnBorrar_Click(object sender, RoutedEventArgs e) { PizarraInk.Strokes.Clear(); }

        private void ActivarModoMover()
        {
            PizarraInk.EditingMode = InkCanvasEditingMode.None;
            PizarraInk.IsHitTestVisible = false;
        }

        private void Ficha_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PizarraInk.IsHitTestVisible == false)
            {
                estaArrastrando = true;
                elementoArrastrado = sender as UIElement;
                clickPosition = e.GetPosition(CapaJugadores);
                elementoArrastrado.CaptureMouse();
            }
        }

        private void Ficha_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (estaArrastrando && elementoArrastrado != null)
            {
                System.Windows.Point currentPosition = e.GetPosition(CapaJugadores);
                double deltaX = currentPosition.X - clickPosition.X;
                double deltaY = currentPosition.Y - clickPosition.Y;
                double currentLeft = Canvas.GetLeft(elementoArrastrado);
                double currentTop = Canvas.GetTop(elementoArrastrado);

                Canvas.SetLeft(elementoArrastrado, currentLeft + deltaX);
                Canvas.SetTop(elementoArrastrado, currentTop + deltaY);
                clickPosition = currentPosition;
            }
        }

        private void Ficha_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            estaArrastrando = false;
            if (elementoArrastrado != null)
            {
                elementoArrastrado.ReleaseMouseCapture();
                elementoArrastrado = null;
            }
        }
    }
}