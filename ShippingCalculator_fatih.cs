// Package Express Shipping Calculator
// Created by: Maria Garcia
// Version: 3.0.0
using System;
using System.Collections.Generic;

namespace ShippingCalculations
{
    public class PackageDimensionCalculator
    {
        // Package dimension structure
        public struct PackageDimensions
        {
            public decimal Width { get; set; }
            public decimal Height { get; set; }
            public decimal Length { get; set; }
            public decimal Weight { get; set; }
        }

        static void Main(string[] args)
        {
            // Print welcome message
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Get package weight
            Console.WriteLine("Please enter the package weight:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal massInput))
            {
                Console.WriteLine("Invalid weight value entered.");
                return;
            }

            // Weight limit check
            if (massInput > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return;
            }

            // Create package object
            PackageDimensions package = new PackageDimensions { Weight = massInput };

            // Get package measurements
            var dimensionPrompts = new Dictionary<string, Action<decimal>>
            {
                { "width", value => package.Width = value },
                { "height", value => package.Height = value },
                { "length", value => package.Length = value }
            };

            foreach (var dimension in dimensionPrompts)
            {
                Console.WriteLine($"Please enter the package {dimension.Key}:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    Console.WriteLine($"Invalid {dimension.Key} value entered.");
                    return;
                }
                dimension.Value(value);
            }

            // Calculate total measurements
            decimal totalMeasure = package.Width + package.Height + package.Length;

            // Size limit check
            if (totalMeasure > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return;
            }

            // Calculate shipping cost
            // Formula: (width * height * length * weight) / 100
            decimal costTotal = (package.Width * package.Height * package.Length * package.Weight) / 100;

            // Display shipping cost
            Console.WriteLine($"Your estimated total for shipping this package is: ${costTotal:F2}");
            Console.WriteLine("Thank you!");
        }
    }
} 