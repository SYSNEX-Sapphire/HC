using CommunityToolkit.Mvvm.ComponentModel;
using SapphireXR_App.Models;

namespace SapphireXR_App.Common
{
    internal static class RecipeValidator
    {
        public static (bool, string) ValidOnLoadedFromDisk(IList<Recipe> recipe)
        {
            if (0 < recipe.Count)
            {
                Recipe first = recipe[0];
                if (ValidFirstRecipe(first) == false)
                {
                    return (false, "첫 번째 스텝에는 모든 Analaog Device값이 설정되어 있어야 합니다");
                }
            }

            return (true, "");
        }

        private static bool ValidFirstRecipe(Recipe first)
        {
            return !(first.M01 == null || first.M02 == null || first.M03 == null || first.M04 == null || first.M05 == null || first.M06 == null || first.M07 == null || first.M08 == null ||
                    first.M09 == null || first.M10 == null || first.M11 == null || first.M12 == null || first.F01 == null || first.F02 == null || first.F03 == null || first.F04 == null ||
                    first.F05 == null || first.F06 == null);
        }

        public static bool Valid(IList<Recipe> recipes)
        {
            RecipeStepValidator? firstStepValidator = recipes.First().stepValidator;
            if (firstStepValidator != null)
            {
                return firstStepValidator.Valid;
            }
            else
            {
                throw new InvalidOperationException("첫번째 스텝의 RecipeStepValidator이 설정되지 안았습니다");
            }
        }

        internal abstract partial class RecipeStepValidator : ObservableObject
        {
            internal RecipeStepValidator(bool initalValid)
            {
                valid = initalValid;
            }
            internal abstract string validate(Recipe recipe, string analogController);

            private bool valid;
            public bool Valid
            {
                get { return valid; }
                protected set { SetProperty(ref valid, value); }
            }
        }

        internal class FirstRecipeStepValidator : RecipeStepValidator
        {
            internal FirstRecipeStepValidator(bool initalValid) : base(initalValid) { }
            internal override string validate(Recipe recipe, string analogController)
            {
                string errorMessage = "첫번째 Step의 값은 빈값일 수 없습니다";
                switch (analogController)
                {
                    case nameof(Recipe.M01):
                        if (recipe.M01 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M02):
                        if (recipe.M02 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M03):
                        if (recipe.M03 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M04):
                        if (recipe.M04 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M05):
                        if (recipe.M05 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M06):
                        if (recipe.M06 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M07):
                        if (recipe.M07 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M08):
                        if (recipe.M08 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M09):
                        if (recipe.M09 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M10):
                        if (recipe.M10 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M11):
                        if (recipe.M11 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.M12):
                        if (recipe.M12 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.F01):
                        if (recipe.F01 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.F02):
                        if (recipe.F02 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.F03):
                        if (recipe.F03 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.F04):
                        if (recipe.F04 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.F05):
                        if (recipe.F05 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;

                    case nameof(Recipe.F06):
                        if (recipe.F06 == null)
                        {
                            Valid = false;
                            return errorMessage;
                        }
                        else
                        {
                            Valid = RecipeValidator.ValidFirstRecipe(recipe);
                        }
                        break;
                }

                return string.Empty;
            }
        }

        internal class NormalRecipeStepValidator : RecipeStepValidator
        {
            internal NormalRecipeStepValidator() : base(true) { }

            internal override string validate(Recipe recipe, string analogController)
            {
                return string.Empty;
            }
        }
    }
}
