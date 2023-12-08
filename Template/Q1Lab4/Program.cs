// See https://aka.ms/new-console-template for more information
using Q1Lab4;
using System;
using System.Data.SqlClient;

Console.WriteLine("Francisco Mellado, 301304340 /n /n");
Console.WriteLine("Question 01 - Lab 04 /n" );
;

var countries = Country.GetCountries();

// Invokes methods
Question1_1();
Question1_2();
Question1_3();
Question1_4();
Question1_5();
Question1_6();


// 1.1 List the names of the countries in alphabetical order [0.5 mark]
void Question1_1()
{
    try
    {
        var alphabetCountries = from country in countries
                                orderby country.Name
                                select country.Name;
        Console.WriteLine("Question 1_1: ");
        foreach (var Nombre in alphabetCountries)
        {
            Console.WriteLine(Nombre);
        }
        Console.WriteLine($"\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

    // 1.2 List the names of the countries in descending order of number of resources [0.5 mark]
    void Question1_2()
    {

        try
        {


            var countriesByResources = from country in countries
                                       orderby country.Resources.Count descending
                                       select country.Name;
            Console.WriteLine($"Question 1_2:");
            foreach (var countryName in countriesByResources)
            {
                Console.WriteLine(countryName);
            }
            Console.WriteLine($"\n");
        }
        catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
    }

    // 1.3 List the names of the countries that shares a border with Argentina [0.5 mark]
    void Question1_3()
    {

    try
        {
            var argentinaNeighbors = from country in countries
                                     where country.Borders.Contains("Argentina")
                                     select country.Name;
            Console.WriteLine($"Question 1_3:");
            foreach (var countryName in argentinaNeighbors)
            {
                Console.WriteLine(countryName);
            }
            Console.WriteLine($"\n");
        }
        catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
    }


    // 1.4 List the names of the countries that has more than 10,000,000 population [0.5 mark]
    void Question1_4()
    {

    try
        {
            var highPopulationCountries = from country in countries
                                          where country.Population > 10000000
                                          select country.Name;
            Console.WriteLine($"Question 1_4:");
            foreach (var countryName in highPopulationCountries)
            {
                Console.WriteLine(countryName);
            }
            Console.WriteLine($"\n");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // 1.5 List the country with highest population [1 mark]
    void Question1_5()
    {

    if (countries != null && countries.Any())
        {
            var highestPopulation = (from country in countries
                                     orderby country.Population descending
                                     select country.Name).FirstOrDefault();

            Console.WriteLine($"Question 1_5:");
            Console.WriteLine(highestPopulation);
            Console.WriteLine("\n");
        }
        else
        {
            Console.WriteLine("No countries available.");
        }
    }

    // 1.6 List all the religion in south America in dictionary order [1 mark]
    void Question1_6()
    {

    try
        {
            var countries = Country.GetCountries();

            // Selecciona todas las religiones de cada país, luego aplanamos la lista y la ordenamos
            var religions = (from country in countries
                             from religion in country.Religions
                             orderby religion
                             select religion).Distinct().ToList();

            Console.WriteLine("Religiones en Sudamérica en orden de diccionario:");
            foreach (var religion in religions)
            {
                Console.WriteLine(religion);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo un error: {ex.Message}");
        }
    }

