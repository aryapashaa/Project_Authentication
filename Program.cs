using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Project_Authentication;

class Program
{
    public static List<User> banyakUsers = new List<User>();
    static void Main()
    {
        Menu();
    }
    static void Menu()
    {
        bool key = true;
        do
        {
            string[] menuTampilan = { "Create", "Show", "Login", "Exit" };

            Console.WriteLine("==BASIC AUTHENTICATION==");
            for (int i = 0; i < menuTampilan.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuTampilan[i]} User");
            }

            Pilih();
        } while (key);
    }
    static void Pilih()
    {
        Console.Write("Input : ");
        int pilihMenu = Convert.ToInt32(Console.ReadLine());

        switch (pilihMenu)
        {
            case 1: //CREATE
                Create();
                break;
            case 2: //EDIT
                View(banyakUsers);
                break;
            case 3: //LOGIN
                Login();
                Console.Clear();
                break;
            case 4: //EXIT
                System.Environment.Exit(0);
                break;
            default:
                Console.Write("\nTidak ada pilihan");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
    static void Create()
    {
        Console.Clear();

        User singleUser = new User();

        Console.Write("First Name : ");
        singleUser.FirstName = Console.ReadLine(); //menentukan First Name

        Console.Write("Last Name : ");
        singleUser.LastName = Console.ReadLine(); //menentukan Last Name

        singleUser.Username = singleUser.FirstName[..2] + singleUser.LastName.Substring(0, 2); //menentukan Username

        bool check = true;
        do //menentukan Password
        {
            Console.Write("Password : ");
            string checkPass = Console.ReadLine();
            if (checkPass.Length >= 8)
            {
                if (checkPass.Any(char.IsUpper))
                {
                    if (checkPass.Any(char.IsLower))
                    {
                        if (checkPass.Any(char.IsNumber))
                        {
                            singleUser.Password = checkPass;
                            check = false;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("\nPassword must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.\n");
        } while (check);

        for (int i = 0; i <= banyakUsers.Count; i++)
        {
            singleUser.Id = i + 1; //menentukan ID
        }

        banyakUsers.Add(singleUser);

        Console.Write("\nData user berhasil dibuat");
        Console.ReadKey();
        Console.Clear();
    }
    static void View(List<User> banyakUsers)
    {
        bool key = true;
        do
        {
            Console.Clear();

        Console.WriteLine("==SHOW USER==");

        foreach (User item in banyakUsers)
        {
            Console.WriteLine("========================");
            Console.WriteLine($"ID\t: {item.Id}");
            Console.WriteLine($"Name\t: {item.FirstName} {item.LastName}");
            Console.WriteLine($"Username: {item.Username}");
            Console.WriteLine($"Password: {item.Password}");
            Console.WriteLine("========================");
        }

        
            Console.WriteLine("\nMenu");

            string[] menuEdit = { "Edit User", "Delete User", "Back" };

            for (int i = 0; i < menuEdit.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuEdit[i]}");
            }

            Console.Write("Input : ");
            int pilihEdit = Convert.ToInt16(Console.ReadLine());

            switch (pilihEdit)
            {
                case 1:
                    bool kunci = true;
                    do
                    {
                        Console.Write("\nID yang ingin diubah: ");
                        int ubahId = Convert.ToInt32(Console.ReadLine());

                        foreach (User item in banyakUsers)
                        {
                            if (ubahId == item.Id)
                            {
                                Console.Write("First Name : ");
                                string ubahFirst = Console.ReadLine();
                                item.FirstName = ubahFirst;

                                Console.Write("Last Name : ");
                                string ubahLast = Console.ReadLine();
                                item.LastName = ubahLast;

                                item.Username = item.FirstName[..2] + item.LastName.Substring(0, 2);

                                bool check = true;
                                do
                                {
                                    Console.Write("Password : ");
                                    string ubahPass = Console.ReadLine();
                                    if (ubahPass.Length >= 8)
                                    {
                                        if (ubahPass.Any(char.IsUpper))
                                        {
                                            if (ubahPass.Any(char.IsLower))
                                            {
                                                if (ubahPass.Any(char.IsNumber))
                                                {
                                                    item.Password = ubahPass;
                                                    check = false;
                                                    break;
                                                }   
                                            }
                                        }
                                    }
                                    Console.WriteLine("\nPassword must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.\n");
                                } while (check);

                                Console.Write("\nUser sudah berhasil diedit");
                                kunci = false;
                                Console.ReadKey();
                                goto Selesai;
                            }
                        }
                        Console.Write("\nUser tidak ditemukan !!!\n");
                        Console.ReadKey();
                        break;
                    Selesai:;
                    } while (kunci);
                    break;
                case 2:
                    Console.Write("\nID yang ingin dihapus: ");
                    int hapusId = Convert.ToInt32(Console.ReadLine());

                    foreach (User item in banyakUsers.ToArray())
                    {
                        if (hapusId == item.Id)
                        {
                            banyakUsers.Remove(item);
                            break;
                        }
                    }

                    Console.Write("\nUser sudah berhasil dihapus");
                    Console.ReadKey();
                    break;
                case 3:
                    key = false;
                    Console.Clear();
                    break;
                default:
                    Console.Write("\nTidak ada pilihan");
                    Console.ReadKey();
                    break;
            }
        } while (key);
    }
    static void Login()
    {
        Console.Clear();

        Console.WriteLine("==LOGIN==");
        Console.Write("USERNAME : ");
        string inputUser = Console.ReadLine();

        Console.Write("PASSWORD : ");
        string inputPass = Console.ReadLine();

        bool status = false;

        foreach (var item in banyakUsers)
        {
            if (item.Username == inputUser && item.Password == inputPass)
            {
                status = true;
                break;
            }
        }

        if (status == true)
        {
            Console.Write("Login Berhasil");
            Console.ReadKey();
        }
        else
        {
            Console.Write("Login Gagal");
            Console.ReadKey();
        }
    }
}