Console.Clear();

for (int g=0; g<3; g++) // CANTIDAD DE CARTONES A MOSTRAR
{ 
    int filas = 3;
    int columnas = 9;

    var carton = new int[filas, columnas];

    //CARGO DATOS ALEATORIOS POR CADA COLUMNA USANDO EXTREMOS

    var rd = new Random();

    int limiteInferior = 1;
    int limiteSuperior = 10;
    int offset = 10;

    bool seRepite;
    int aux;

    for (int j=0; j<=carton.GetUpperBound(1); j++)  //COLUMNAS
    {
        for (int i=0; i<=carton.GetUpperBound(0); i++)  //FILAS
        {
            do {
                seRepite = false;
                aux = rd.Next(limiteInferior, limiteSuperior);
                
                for (int h = 0; h < i; h++)
                {
                    if (carton[h, j] == aux)
                    {
                        seRepite = true;
                    }
                }
                
            } while (seRepite);

            carton[i, j] = aux;
        }

        if (j == carton.GetUpperBound(1)-1) limiteSuperior++;   //En la fila 8 le sumo 1 extra para que en la sig llegue a 90
        limiteInferior += offset;
        limiteSuperior += offset;
    }

    //ORDENO LAS COLUMNAS

    int aux2;

    for (int j=0; j<=carton.GetUpperBound(1); j++)  //COLUMNAS
    {
        for (int i=0; i<carton.GetUpperBound(0); i++)  //FILAS
        {
            for (int h=0; h<carton.GetUpperBound(0); h++)
            {
                if (carton[h,j]>carton[h+1,j])
                {
                    aux2 = carton[h, j];
                    carton[h, j] = carton[h + 1, j];
                    carton[h + 1, j] = aux2;
                }
            }
        }
    }

    // GENERO ESPACIOS ALEATORIOS PARA LA FILA 1

    int aux3;
    int contadorEspaciosVacios = 0;

    bool repetido;

    do
    {
        do
        {
            aux3 = rd.Next(1,10)-1; //resto 1 porque es para posicion del array   
            repetido = true;

            if (carton[0, aux3] != 0)
            {
                repetido = false;
            }
        } while (repetido);
       
        carton[0, aux3] = 0;
        contadorEspaciosVacios++;
    } while (contadorEspaciosVacios<4);

    // GENERO ESPACIOS ALEATORIOS PARA LA FILA 2 
    // SI EN LA POSICION ANTERIOR YA HAY UN ESPACIO VACIO TIENE MENOS CHANCE DE VOLVER A SALIR

    contadorEspaciosVacios = 0;

    do
    {
        do
        {
            aux3 = rd.Next(1, 10) - 1; //resto 1 porque es para posicion del array   
            repetido = true;

            if (carton[1, aux3] != 0)
            {
                //Con este if le quito probabilidad de repetir otro espacio vacio en la misma columna
                if (carton[0, aux3] == 0)
                {
                    aux2 = rd.Next(0,100);
                    repetido = true;
                    
                    if (aux2 == 50)
                    {
                        repetido = false;
                    }
                }
                else
                {                    
                    repetido = false;
                }
            }
        } while (repetido);

        carton[1, aux3] = 0;
        contadorEspaciosVacios++;
    } while (contadorEspaciosVacios < 4);

    // GENERO ESPACIOS ALEATORIOS PARA LA FILA 3
    //PARA ESTE CASO PRIORIZO LAS COLUMNAS DONDE NO HALLAN ESPACIOS VACIOS TODAVIA!
    //FUERZO EL ESPACIO EN BLANCO EN ESE CASO

    contadorEspaciosVacios = 0;

    for (int j=0; j<=carton.GetUpperBound(1); j++)  //COLUMNA 
    {
        if (carton[0,j]!=0 && carton[1,j]!=0)
        {
            carton[2, j] = 0;
            contadorEspaciosVacios++;
        }
    }

    //En este caso no usare probabilidad de aparicion para no alargar el codigo
    //Con tener en cuenta no poner un espacio vacio donde ya  halla dos es suficiente para la mayoria de casos posibles
    do
    {
        do
        {
            aux3 = rd.Next(1, 10) - 1; //resto 1 porque es para posicion del array   
            repetido = false;

            if ((carton[1, aux3] == 0 && carton[0,aux3]==0) || carton[2,aux3]==0)  //NO PUEDE HABER 3 ESPACIOS VACIOS
            {
                repetido = true;
            }
        } while (repetido);

        carton[2, aux3] = 0;
        contadorEspaciosVacios++;
    } while (contadorEspaciosVacios < 4);

    //MUESTRO LOS DATOS

    Console.WriteLine("\t\t    --- BINGO ---");
    Console.WriteLine("------------------------------------------------------");
    for (int i=0; i<=carton.GetUpperBound(0); i++)  //FILAS
    {
        for (int j = 0; j<=carton.GetUpperBound(1) ; j++)   //COLUMNAS  
        {
            if (carton[i, j] == 0)
            {
                Console.Write("|    |");
            }
            else
            {
                Console.Write($"| {carton[i, j]:00} |");
            }
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
}
