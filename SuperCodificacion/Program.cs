using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class SuperCodificacion
{
    public static void Codificar(string fichero)
    {
        using StreamReader sr = new StreamReader(fichero);
        string nuevoNombre = Path.GetFileNameWithoutExtension(fichero) + "_codificado" + Path.GetExtension(fichero);
        using StreamWriter sw = new StreamWriter(nuevoNombre);

        while (!sr.EndOfStream)
        {
            string linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea))
            {
                sw.WriteLine();
                continue;
            }

            linea = linea.ToLower();

            var palabras = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < palabras.Count - 1; i++)
            {
                string actual = palabras[i];
                string siguiente = palabras[i + 1];

                char ultimaActual = actual[^1];
                char primeraSiguiente = siguiente[0];

                palabras[i] = actual.Substring(0, actual.Length - 1) + primeraSiguiente;
                palabras[i + 1] = ultimaActual + siguiente.Substring(1);
            }

            for (int i = 0; i < palabras.Count; i++)
            {
                char[] chars = palabras[i].ToCharArray();
                Array.Reverse(chars);
                palabras[i] = new string(chars);
            }

            if (palabras.Count > 1)
            {
                string last = palabras[^1];
                for (int i = palabras.Count - 1; i > 0; i--)
                    palabras[i] = palabras[i - 1];
                palabras[0] = last;
            }

            string concatenada = string.Join(" ", palabras);
            concatenada = MirrorSwap(concatenada);

            concatenada = CifradoCesar(concatenada, +3);

            concatenada = MayusculasPosicionesPares(concatenada);

            sw.WriteLine(concatenada);
        }
        Console.WriteLine($"Archivo codificado guardado en: {nuevoNombre}");
    }

    public static void Descodificar(string fichero)
    {
        using StreamReader sr = new StreamReader(fichero);
        string nuevoNombre = Path.GetFileNameWithoutExtension(fichero) + "_descodificado" + Path.GetExtension(fichero);
        using StreamWriter sw = new StreamWriter(nuevoNombre);

        while (!sr.EndOfStream)
        {
            string linea = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(linea))
            {
                sw.WriteLine();
                continue;
            }

            linea = linea.ToLower();

            linea = CifradoCesar(linea, -3);

            linea = MirrorSwap(linea);

            var palabras = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (palabras.Count > 1)
            {
                string first = palabras[0];
                for (int i = 0; i < palabras.Count - 1; i++)
                    palabras[i] = palabras[i + 1];
                palabras[^1] = first;
            }

            for (int i = 0; i < palabras.Count; i++)
            {
                char[] chars = palabras[i].ToCharArray();
                Array.Reverse(chars);
                palabras[i] = new string(chars);
            }

            for (int i = palabras.Count - 2; i >= 0; i--)
            {
                string actual = palabras[i];
                string siguiente = palabras[i + 1];

                char ultimaActual = siguiente[0];
                char primeraSiguiente = actual[^1];

                palabras[i] = actual.Substring(0, actual.Length - 1) + ultimaActual;
                palabras[i + 1] = primeraSiguiente + siguiente.Substring(1);
            }

            sw.WriteLine(string.Join(" ", palabras));
        }
        Console.WriteLine($"Archivo descodificado guardado en: {nuevoNombre}");
    }

    private static string MirrorSwap(string input)
    {
        char[] chars = input.ToCharArray();
        int n = chars.Length;
        for (int i = 0; i < n / 2; i++)
        {
            (chars[i], chars[n - 1 - i]) = (chars[n - 1 - i], chars[i]);
        }
        return new string(chars);
    }

    private static string CifradoCesar(string input, int desplazamiento)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                int letraDesplazada = (c - baseChar + desplazamiento) % 26;
                if (letraDesplazada < 0) letraDesplazada += 26;
                sb.Append((char)(baseChar + letraDesplazada));
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    private static string MayusculasPosicionesPares(string input)
    {
        char[] chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i += 2)
        {
            chars[i] = char.ToUpper(chars[i]);
        }
        return new string(chars);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Super Codificador");
        Console.Write("¿Quieres codificar (c) o descodificar (d)? ");
        string opcion = Console.ReadLine()?.Trim().ToLower();

        Console.Write("Introduce el nombre del fichero: ");
        string fichero = Console.ReadLine();

        if (!File.Exists(fichero))
        {
            Console.WriteLine("El fichero no existe.");
            return;
        }

        if (opcion == "c")
        {
            Codificar(fichero);
        }
        else if (opcion == "d")
        {
            Descodificar(fichero);
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }
}
