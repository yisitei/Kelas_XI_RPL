for (int i = 1; i < 5; i++)
{
    Console.WriteLine("Perulangan ke -" + i);
}

//while loop
int angka = 1;
while (angka <= 5)  
{
    Console.WriteLine("Angka: " + angka);

    angka++; //increment wajib
}

//foreach loop
string[] namaBuah = { "Apel", "Pisang", "Mangga" };

foreach (string buah in namaBuah)
{
    Console.WriteLine(buah);
}