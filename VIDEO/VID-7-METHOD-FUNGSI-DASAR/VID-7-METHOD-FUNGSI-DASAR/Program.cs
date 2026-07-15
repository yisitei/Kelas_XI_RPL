static void Salam() //method salam
{
    Console.WriteLine("Hello world");
}

Salam();

static void Sapa(string nama) //parameter tipe string
{
    Console.WriteLine("Halo " + nama); //variabel di tambahkan ke method
}

Sapa("Budi");

//methode return value
static int Tambah(int a, int b)
{
    return a + b;
}

Console.WriteLine(Tambah(5, 7));