string[] namaBuah = { "Apel", "Mangga", "Jeruk" };

Console.WriteLine(namaBuah[0]);
Console.WriteLine(namaBuah[1]);

foreach (string buah in namaBuah)
{
    Console.WriteLine(buah)
}

List<string> namaSiswa = new List<string>();

//menambah data ke list
namaSiswa.Add("Budi"); //.add di gunakan untuk menambah ke list
namaSiswa.Add("Anton");
namaSiswa.Add("Siti");

foreach (string siswa in namaSiswa)
{
    Console.WriteLine(siswa);
}