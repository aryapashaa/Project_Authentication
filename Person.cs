using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class Person
    {
        public int[] Id { get; set; } = new int[5];
        public string[] firstName { get; set; } = new string[5];
        public string[] lastName { get; set; } = new string[5];
        public string[] userName { get; set; } = new string[5];
        public string[] passWord { get; set; } = new string[5];
        public Person(int[] id, string[] firstname, string[] lastname, string[] username, string[] password)
        {
            Id= id;
            firstName = firstname;
            lastName = lastname;
            userName = username;
            passWord = password;
        }

        public void Buat(int[] id, string[] firstName, string[] lastName, string[] username, string[] password)
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == 0)
                {
                    id[i] = i + 1; //menentukan ID

                    Console.Write("First Name : ");
                    firstName[i] = Console.ReadLine(); //menentukan First Name

                    Console.Write("Last Name : ");
                    lastName[i] = Console.ReadLine(); //menentukan Last Name

                    username[i] = firstName[i].Substring(0, 2) + lastName[i].Substring(0, 2); //menentukan Username

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
                                        password[i] = checkPass;
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
        }
        public void Ganti(int[] id, string[] firstName, string[] lastName, string[] username, string[] password)
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
                        Console.Write("\nID yang ingin diubah: ");
                        int ubahId = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < id.Length; i++)
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

                                Console.Write("Password : ");
                                string ubahPass = Console.ReadLine();
                                password[ubahId - 1] = ubahPass;
                                break;
                            }
                        }

                        Console.Write("\nUser sudah berhasil diedit");
                        Console.ReadKey();
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
        public void Masuk(int[] id, string[] firstName, string[] lastName, string[] username, string[] password)
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
}
