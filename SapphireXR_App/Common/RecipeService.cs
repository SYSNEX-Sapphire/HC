using System.IO;
using CsvHelper;
using Microsoft.Win32;
using SapphireXR_App.Models;

namespace SapphireXR_App.Common
{
    public static class RecipeService
    {
        internal class OpenRecipeFileException : Exception
        {
            internal OpenRecipeFileException(string message) : base(message) { }
        }

        public static (bool, string?, List<Recipe>?) OpenRecipe(CsvHelper.Configuration.CsvConfiguration config, string? initialDirectory)
        {
            try
            {
                OpenFileDialog openFile = new();
                openFile.Multiselect = false;
                openFile.Filter = "csv 파일(*.csv)|*.csv";

                if(Path.Exists(initialDirectory) == false)
                {
                    initialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Recipe";
                    if (Path.Exists(initialDirectory) == false)
                    {
                        Directory.CreateDirectory(initialDirectory);
                    }
                }
                openFile.InitialDirectory = initialDirectory;

                if (openFile.ShowDialog() != true) return (false, null, null);
                string recipeFilePath = openFile.FileName;

                using (StreamReader streamReader = new StreamReader(recipeFilePath))
                {
                    using (var csvReader = new CsvReader(streamReader, config))
                    {
                        return (true, recipeFilePath, csvReader.GetRecords<Recipe>().ToList());
                    }
                }
            }
            catch (Exception exception)
            {
                throw new OpenRecipeFileException(exception.Message);
            }
        }

        public static PlcRecipe[] ToPLCRecipe(IList<Recipe> recipes)
        {
            (bool success, string message) = RecipeValidator.Validate(recipes);
            if (success == false)
            {
                throw new InvalidOperationException(message);
            }

            Recipe first = recipes.First();
            AnalogRecipe analogRecipe = new()
            {
                M01 = first.M01!.Value,
                M02 = first.M02!.Value,
                M03 = first.M03!.Value,
                M04 = first.M04!.Value,
                M05 = first.M05!.Value,
                M06 = first.M06!.Value,
                M07 = first.M07!.Value,
                M08 = first.M08!.Value,
                M09 = first.M09!.Value,
                M10 = first.M10!.Value,
                M11 = first.M11!.Value,
                M12 = first.M12!.Value,
                F01 = first.F01!.Value,
                F02 = first.F02!.Value,
                F03 = first.F03!.Value,
                F04 = first.F04!.Value,
                F05 = first.F05!.Value,
                F06 = first.F06!.Value
            };

            PlcRecipe[] aRecipePLC = new PlcRecipe[recipes.Count];
            int i = 0;
            foreach (Recipe iRecipeRow in recipes)
            {
                aRecipePLC[i] = new PlcRecipe(iRecipeRow, analogRecipe);
                analogRecipe.update(aRecipePLC[i]);
                i += 1;
            }

            return aRecipePLC;
        }

        public static void PLCLoad(IList<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                throw new InvalidOperationException("Recipe가 비워있습니다.");
            }

            PlcRecipe[] aRecipePLC = ToPLCRecipe(recipes);
            PLCService.WriteRecipe(aRecipePLC);
            PLCService.WriteTotalStep((short)aRecipePLC.Length);
        }
    }
}
