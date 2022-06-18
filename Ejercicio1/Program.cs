/*
Con los conocimientos vistos hasta ahora en clase realizar un programa que haga lo siguiente:
 */

int longitud;

//1)      Pedir al usuario la longitud de un vector

Console.WriteLine("Hola usuario, por favor indique la longitud que desee para el vector");
longitud = int.Parse(Console.ReadLine());


//2)      Crear el vector del tamaño ingresado.
int[] vector = new int[longitud];


//3)      Llenar el mismo con datos aleatorios
Random rd = new Random();

for (int i=0; i<vector.Length; i++) {
    vector[i] = rd.Next(1,101);
}


//4)      Mostrar el vector por pantalla
Console.WriteLine("-------------------------------------");
Console.WriteLine("-------------------------------------");

Console.WriteLine();
Console.Write("Vector generado: ");
foreach (int e in vector) {
    Console.Write($"{e} ");
}


/*
 5)      Invertir el vector, de manera que el primer elemento quede al último y el útimo en el primero; 
el segundo en anteúltimo, el anteúltimo en el segundo y así sucesivamente. 
En otra palabras si el vector es de 5 posiciones y el usuario ingresó: 10, 20, 30, 40, 50, una vez invertido,
el vector debe quedar así: 50, 40, 30, 20, 10.  
Se debe usar solo lo visto en clase hasta ahora y no los métodos que trae C# para estas cuestiones.
*/
int aux = 0;
for (int i=0; i<vector.Length/2; i++) {
    aux = vector[i];
    vector[i] = vector[vector.GetUpperBound(0) - i];
    vector[vector.GetUpperBound(0)-i] = aux;
}


//6)      Mostrar el vector nuevamente.
Console.WriteLine();
Console.WriteLine("-------------------------------------");
Console.WriteLine("-------------------------------------");

Console.WriteLine();
Console.Write("Vector invertido: ");
foreach (int e in vector) {
    Console.Write($"{e} ");
}
