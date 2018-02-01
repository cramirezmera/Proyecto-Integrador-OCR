
using System;
using System.Collections.Generic;
using codeImage;

namespace OCR
{
    static class Program
    {
      
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MethodsOCR grap = new MethodsOCR();
            String unidad = "B";
            String file = "imgIN-15.png";
            String layout = "layoutor";
            String campos = "camposor";
            if (args.Length != 0)
            {
                unidad = args[0]; 
            }
            if (args.Length >1)
            {
                file = args[1]; 
            }
            if (args.Length >2)
            {
                layout = args[2];
            }
            if (args.Length >3)
            {
                campos = args[3]; 
            }
          


            grap.archivo = unidad + ":/OCR/" + file ;
            grap.ruta = unidad + ":/OCR/";
            grap.layout = layout;
            grap.campos = campos;
            grap.unidad = unidad;
            grap.cargarCampos();
           

           if(grap.Deskew())
                Console.WriteLine("Se corrigió rotación de pagina");

            if(grap.recortarROI())
            Console.WriteLine("Se corrigió traslación de pagina");

            grap.escalarImagen();
            Console.WriteLine("Se redimensionó la imagen");

             grap.ExtraerArea();
            Console.WriteLine("Se obtuvieron las areas de la imagen");

           grap.procesar();
            Console.ReadKey();
            grap.mostrarTexto();
           
            Console.WriteLine("Archivo Generado...");

            Console.ReadKey();
        }
    }
}