﻿using FluentValidation;

namespace obs_test.Domain.Validators
{
    public class TerrainValidator : AbstractValidator<string[][]>
    {
        private static readonly string[] ValidTerrainValues = { "Fe", "Se", "W", "Si", "Zn", "Obs" };
        public TerrainValidator()
        {
            //RuleForEach(terrain => terrain).Must(row => row != null && row.Length > 0).WithMessage("Invalid terrain row.");
            //RuleFor(terrain => terrain)
            //    .Must(terrain => terrain.Length > 0 && terrain.All(row => row.Length == terrain[0].Length))
            //    .WithMessage("Terrain rows must have the same length.");
            RuleFor(terrain => terrain).Must(ValidateTerrainDimensions).WithMessage("Invalid terrain dimensions.");
            RuleFor(terrain => terrain).Must(ValidateTerrainValues).WithMessage("Invalid terrain values detected.");

        }
        private static bool ValidateTerrainDimensions(string[][] terrain)
        {
            if (terrain.Length == 0 || terrain[0].Length == 0)
            {
                return false;
            }

            int expectedColumnCount = terrain[0].Length;
            return terrain.All(row => row.Length == expectedColumnCount);
        }
        private static bool ValidateTerrainValues(string[][] terrain)
        {
            foreach (var row in terrain)
            {
                foreach (var cell in row)
                {
                    if (!ValidTerrainValues.Contains(cell))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
