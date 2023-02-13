using System;
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
            Console.Clear();

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
                //View(banyakUsers);
                break;
            case 3: //LOGIN
                //Login();
                break;
            case 4: //EXIT
                System.Environment.Exit(0);
                break;
            default:
                Console.Write("\nTidak ada pilihan");
                Console.ReadKey();
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
    }
    static void View(List<User> banyakUsers)
    {
        int i = 0;

        foreach (User n in banyakUsers)
        {
            i++;
            Console.WriteLine("========================");
            Console.WriteLine($"ID\t: {i}");
            Console.WriteLine($"Name\t: {n.FirstName} {n.LastName}");
            Console.WriteLine($"Username: {n.Username}");
            Console.WriteLine($"Password: {n.Password}");
            Console.WriteLine("========================");
        }
    }
    static void Edit(int[] id, string[] firstName, string[] lastName, string[] username, string[] password)
    {
        bool key = true;
        do
        {
            Console.Clear();

            Console.WriteLine("==SHOW USER==");
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] != 0)
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("ID       : " + id[i]);
                    Console.WriteLine("Name     : " + firstName[i] + " " + lastName[i]);
                    Console.WriteLine("Username : " + username[i]);
                    Console.WriteLine("Password : " + password[i]);
                    Console.WriteLine("====================");
                }
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
                    for (int i = 0; i < id.Length; i++)
                    {
                        Console.Write("\nID yang ingin diubah: ");
                        int ubahId = Convert.ToInt32(Console.ReadLine());
                        if (id[i] == ubahId)
                        {
                            for (int j = 0; j < id.Length; j++)
                            {
                                if (id.Length != null)
                                {
                                    Console.Write("First Name : ");
                                    string ubahFirst = Console.ReadLine();
                                    firstName[ubahId - 1] = ubahFirst;

                                    Console.Write("Last Name : ");
                                    string ubahLast = Console.ReadLine();
                                    lastName[ubahId - 1] = ubahLast;

                                    username[ubahId - 1] = firstName[ubahId - 1].Substring(0, 2) + lastName[ubahId - 1].Substring(0, 2);

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
                                                        password[ubahId - 1] = ubahPass;
                                                        check = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        Console.WriteLine("\nPassword must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.\n");
                                    } while (check);
                                    break;
                                }
                            }

                            Console.Write("\nUser sudah berhasil diedit");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nUser tidak ditemukan !!!\n");
                            Console.ReadKey();
                        }
                    }
                    break;
                case 2:
                    Console.Write("\nID yang ingin dihapus: ");
                    int hapusId = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < id.Length; i++)
                    {
                        if (id.Length != null)
                        {
                            id[hapusId - 1] = hapusId - hapusId;
                            firstName[hapusId - 1] = "";
                            lastName[hapusId - 1] = "";
                            username[hapusId - 1] = "";
                            password[hapusId - 1] = "";
                            break;
                        }
                    }

                    Console.Write("\nUser sudah berhasil dihapus");
                    Console.ReadKey();
                    break;
                case 3:
                    key = false;
                    break;
                default:
                    Console.Write("\nTidak ada pilihan");
                    Console.ReadKey();
                    break;
            }
        } while (key);
    }
    static void Login(int[] id, string[] firstName, string[] lastName, string[] username, string[] password)
    {
        Console.Clear();

        Console.WriteLine("==LOGIN==");
        Console.Write("USERNAME : ");
        string inputUser = Console.ReadLine();

        Console.Write("PASSWORD : ");
        string inputPass = Console.ReadLine();

        bool status = false;
        for (int i = 0; i < id.Length; i++)
        {
            if (username[i] == inputUser && password[i] == inputPass)
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