using PL;

while (true)
{
    Console.WriteLine("Menú:");
    Console.WriteLine("1. Numeros impares 1-100 y divisibles entre 3");
    Console.WriteLine("2. N productos");
    Console.WriteLine("3. A hereda de B");
    Console.WriteLine("0. Salir");

    Console.Write("Ingrese la opción deseada: ");
    int opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            NumerosImparesYDivisiblesEntre3();
            break;

        case 2:
            NProductos();
            break;

        case 3:
            AHeredaDeB();
            break;

        case 0:
            Console.WriteLine("Saliendo del programa.");
            return;

        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }

    Console.WriteLine();
}

static void NumerosImparesYDivisiblesEntre3()
{
    var numerosPares = new List<int>();
    var numerosDivisiblesPor3 = new List<int>();

    for (int i = 1; i <= 100; i++)
    {
        if (i % 2 == 0)
        {
            numerosPares.Add(i);
        }

        if (i % 3 == 0)
        {
            numerosDivisiblesPor3.Add(i);
        }
    }

    Console.WriteLine("Los números pares son: {" + string.Join(", ", numerosPares) + "}");
    Console.WriteLine("Los números divisibles entre 3 son: {" + string.Join(", ", numerosDivisiblesPor3) + "}");
}

static void NProductos()
{
    Console.Write("Ingrese el número de productos: ");
    int numeroDeProductos = int.Parse(Console.ReadLine());

    if (numeroDeProductos <= 0)
    {
        Console.WriteLine("El número de productos debe ser mayor que 0.");
        return;
    }

    string productoMayorPrecio = "";
    decimal precioMayor = decimal.MinValue;

    string productoMenorPrecio = "";
    decimal precioMenor = decimal.MaxValue;

    for (int i = 1; i <= numeroDeProductos; i++)
    {
        Console.Write($"Ingrese el precio del producto {i}: $");
        decimal precioActual = decimal.Parse(Console.ReadLine());

        if (precioActual > precioMayor)
        {
            precioMayor = precioActual;
            productoMayorPrecio = $"producto {i}";
        }

        if (precioActual < precioMenor)
        {
            precioMenor = precioActual;
            productoMenorPrecio = $"producto {i}";
        }
    }

    Console.WriteLine($"El producto de mayor precio es el {productoMayorPrecio} con un precio de ${precioMayor}");
    Console.WriteLine($"El producto de menor precio es el {productoMenorPrecio} con un precio de ${precioMenor}");
}

static void AHeredaDeB()
{
    A objetoA = new();

    Console.WriteLine(objetoA.MetodoA());
    Console.WriteLine(objetoA.MetodoB());
}


