using SerializationForSummerSchool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationDEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** DEMO: Understanding Object Serialization *****");

            JamesBondCar jbc = new JamesBondCar();
            jbc.CanFly = true;
            jbc.CanSubmerge = false;
            jbc.TheRadio.StationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.TheRadio.HasTweeters = true;
            PrintJamesBondCar(jbc);

            // Binary
            string fileName = "Anna.dat";
            SaveAsBinaryFormat(jbc, fileName);
            JamesBondCar jbcLoad = LoadFromBinaryFile(fileName);
            PrintJamesBondCar(jbcLoad);

            //JSON
            string jsonFileName = "Anna.txt";
            Employee empDetails = new Employee
            {
                FirstName = "Anna",
                LastName = "Hakobyan",
                Address = new Address { Country = "Armenia", State = "Yerevan", ZipCode = "895578" },
                EmployeeId = "189811211",
                Test = new Dictionary<string, int>()
            };
            empDetails.Test.Add("7", 9);
            empDetails.Test.Add("2", 3);
            empDetails.Test.Add("8", 9);
            empDetails.Test.Add("12", 56);

            SaveAsJsonFormat(empDetails, jsonFileName);
            Employee fakeEmployeFromJSON = LoadFromJSONFile(jsonFileName);
            PrintEmployee(fakeEmployeFromJSON);

            Console.ReadLine();
        }

        static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }

            Console.WriteLine();
            Console.WriteLine("=> Saved car in binary format!");
        }

        static JamesBondCar LoadFromBinaryFile(string fileName)
        {
            Console.WriteLine("=> Deserialization: Load a car from binary format!");
            BinaryFormatter binFormat = new BinaryFormatter();

            JamesBondCar carFromDisk;
            using (Stream fStream = File.OpenRead(fileName))
            {
                carFromDisk = (JamesBondCar)binFormat.Deserialize(fStream);

                Console.WriteLine("=> Deserialized car from binary format!");
            }

            return carFromDisk;
        }

        static void SaveAsJsonFormat(object objGraph, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(objGraph);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine();
            Console.WriteLine("=> Saved Employee in JSON format!");
        }

        static Employee LoadFromJSONFile(string fileName)
        {
            Console.WriteLine("=> Deserialization: Load a Employee from JSON format!");
            string jsonString = File.ReadAllText(fileName);
            Employee employee = JsonSerializer.Deserialize<Employee>(jsonString);

            return employee;
        }

        static void PrintJamesBondCar(JamesBondCar jbc)
        {
            if (jbc == null) return;

            Console.WriteLine("***** Print JamesBondCar type *****");
            Console.WriteLine($" CanFly: {jbc.CanFly}");
            Console.WriteLine($" CanSubmerge: {jbc.CanSubmerge}");

            Console.Write($" TheRadio.StationPresets: ");
            foreach (var station in jbc.TheRadio.StationPresets)
            {
                Console.Write($"{station}; ");
            }

            Console.WriteLine();
            Console.WriteLine($"TheRadio.HasTweeters: {jbc.TheRadio.HasTweeters}");
        }

        static void PrintEmployee(Employee e)
        {
            if (e == null) return;

            Console.WriteLine();
            Console.WriteLine("***** Print Employee type *****");
            Console.WriteLine($" FirstName: {e.FirstName}");
            Console.WriteLine($" LastName: {e.LastName}");
            Console.WriteLine($" EmployeeId: {e.EmployeeId}");
            Console.WriteLine($" Employee.Address.ZipCode: {e.Address.ZipCode}");
            Console.WriteLine($" Employee.Address.State: {e.Address.State}");
            Console.WriteLine($" Employee.Address.Country: {e.Address.Country}");

            Console.Write($" Employee.Test: ");
            foreach (var test in e.Test)
            {
                Console.Write($"Key: {test.Key}, Value: {test.Value}; ");
            }
        }
    }
}