﻿// See https://aka.ms/new-console-template for more information
using System;
using System.IO; // uso la libreria para el manejo de archivos
internal class Program
{
    private static void Main(string[] args)
    {
        // string [] Discos= Directory.GetLogicalDrives();
        // foreach (string disco in Discos)
        // {
        //     System.Console.WriteLine(disco);
        // }
        System.Console.WriteLine("Dame el nombre de la carpeta de la cual queres tener la info, ubicada en el disco D");
        string nombreCarpeta=Console.ReadLine();
        //string ruta="D:\\"+nombreCarpeta;
        if (Directory.Exists("D:\\"+nombreCarpeta))
        {
            
                System.Console.WriteLine("Directorios pertenecientes a la carpeta:");
                List<string> subcarpetas = Directory.GetDirectories("D:\\"+nombreCarpeta).ToList();
                foreach (string buenas in subcarpetas)
                {
                    System.Console.WriteLine(buenas);
                }
                System.Console.WriteLine("Los archivos pertenecientes a la carpeta son: ");
                List<string> archivos = Directory.GetFiles("D:\\"+nombreCarpeta).ToList();
                string nuevoArchivo="index.csv";
                if (!File.Exists(nuevoArchivo))
                {
                    File.Create(nuevoArchivo);
                }
                //string winDir=Environment.GetEnvironmentVariable("windir");
                string aux;
                //escribo en el archivonuevoArchivocada archivo perteneciente a la carpeta
                string [] auxDos= new string[archivos.Count];
                int i=0;
                foreach (string item in archivos)
                {
                    System.Console.WriteLine(item);
                    FileInfo fileop= new FileInfo(item);
                    System.Console.WriteLine();
                    //System.Console.WriteLine(fileop.FullName+","+fileop.Length+","+fileop.LastAccessTime.ToString("ddMMyyyy")+","+fileop.Name+","+fileop.Extension);
                    auxDos[i]=fileop.FullName+","+fileop.Length+","+fileop.LastAccessTime.ToString("ddMMyyyy")+","+fileop.Name+","+fileop.Extension;
                    //File.WriteAllText("index.csv",aux);
                    i++;
                }
                File.WriteAllLines(nuevoArchivo,auxDos);
                //obtengo las lineas escritas en el archivo index.cvs
                System.Console.WriteLine("Lineas de el nuevo archivo: ");
                List<string> lineas=File.ReadAllLines(nuevoArchivo).ToList();
                foreach (string linea in lineas)
                {
                    System.Console.WriteLine(linea);
                }
                //nuevoArchivo.Close();
        }
        else
        {
            System.Console.WriteLine("No existe dicho directorio");
        }
    }
}