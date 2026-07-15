//MATERI PERCABANGAN

int umur = 18;

//if
if (umur >=17)
{
    Console.WriteLine("Boleh membuat ktp");
}
//else
else //else digunakan jika kondisi false
    //else digunakan sebagai alternatif ketika kondisi if tidak terpenuhi
{
    Console.WriteLine("Belum boleh membuat ktp");
}

//else if
int nilai = 85;

if (nilai >= 90)
{
    Console.WriteLine("Grade A");
} else if (nilai >= 75) {
    Console.WriteLine("Grade b");
} else
{
    Console.WriteLine("Grade c");
}

//swtich

string hari = "senin";

switch (hari)
{
    case "Senin":
        Console.WriteLine("Hari pertama");
        break;

    default:
        Console.WriteLine("Hari lain");
        break;
}