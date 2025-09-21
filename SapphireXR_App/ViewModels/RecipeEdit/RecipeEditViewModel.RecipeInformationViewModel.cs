using CommunityToolkit.Mvvm.ComponentModel;
using SapphireXR_App.Bases;
using SapphireXR_App.Common;
using SapphireXR_App.Models;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SapphireXR_App.ViewModels
{
    public partial class RecipeEditViewModel: ViewModelBase
    {
        public partial class RecipeInformationViewModel : ObservableObject, IObserver<IList<Recipe>>, IDisposable
        {
            public RecipeInformationViewModel(RecipeObservableCollection recipeList)
            {
                recipes = recipeList;
                recipes.CollectionChanged += recipeCollectionChanged;
                unsubscriber = ObservableManager<IList<Recipe>>.Subscribe("RecipeEdit.TabDataGrid.RecipeAdded", this);
                foreach (Recipe recipe in recipes)
                {
                    recipe.PropertyChanged += recipePropertyChanged;
                }
                refreshTotal();
            }

            private void recipeCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args)
            {
                refreshTotal();
            }

            private void recipePropertyChanged(object? sender, PropertyChangedEventArgs args)
            {
                switch (args.PropertyName)
                {
                    case nameof(Recipe.RTime):
                        refreshTotal();
                        break;

                    case nameof(Recipe.HTime):
                        refreshTotal();
                        break;
                 

                    case nameof(Recipe.M01):
                    case nameof(Recipe.M02):
                    case nameof(Recipe.M03):
                    case nameof(Recipe.M04):
                    case nameof(Recipe.M05):
                    case nameof(Recipe.M06):
                    case nameof(Recipe.M07):
                    case nameof(Recipe.M08):
                    case nameof(Recipe.M09):
                    case nameof(Recipe.M10):
                    case nameof(Recipe.M11):
                    case nameof(Recipe.M12):
                    case nameof(Recipe.V01):
                    case nameof(Recipe.V02):
                    case nameof(Recipe.V03):
                    case nameof(Recipe.V04):
                    case nameof(Recipe.V05):
                    case nameof(Recipe.V06):
                    case nameof(Recipe.V07):
                    case nameof(Recipe.V08):
                    case nameof(Recipe.V09):
                    case nameof(Recipe.V10):
                    case nameof(Recipe.V11):
                    case nameof(Recipe.V12):
                    case nameof(Recipe.V14):
                    case nameof(Recipe.V15):
                    case nameof(Recipe.V16):
                    case nameof(Recipe.V17):
                    case nameof(Recipe.V18):
                    case nameof(Recipe.V19):
                    case nameof(Recipe.V20):
                        refreshTotalFlowRate();
                        break;
                }
            }

            private void refreshTotal()
            {
                if (0 < recipes.Count)
                {
                    int totalTime = 0;
                    foreach (Recipe recipe in recipes)
                    {
                        totalTime += (recipe.RTime + recipe.HTime);
                    }
                    TotalRecipeTime = totalTime;
                    TotalStepNumber = recipes.Count;
                }
                else
                {
                    TotalRecipeTime = null;
                    TotalStepNumber = null;
                }
            }

            private void refreshTotalFlowRate()
            {
                if(currentStep == null)
                {
                    return;
                }

                var getTargetValue = (Func<Recipe, float?> selector) =>
                {
                    float? currentValue = selector(currentStep);
                    if (currentValue != null)
                    {
                        return currentValue;
                    }
                    else
                    {
                        var findDefaultValue = (Recipe current, Func<Recipe, float?> selector) =>
                        {
                            Recipe? recipe = recipes.Where(recipe => recipe.No < current.No).Reverse().FirstOrDefault(recipe => selector(recipe) != null);
                            if (recipe != null)
                            {
                                return selector(recipe);
                            }
                            else
                            {
                                return null;
                            }
                        };

                        float? defaultValue = findDefaultValue(currentStep, selector);
                        if (defaultValue != null)
                        {
                            return defaultValue;

                        }
                        else
                        {
                            return null;
                        }
                    }
                };

                float totalFlowRate = 0;
                if (currentStep.V01 == true && currentStep.V14 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M01);
                    if(targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if(currentStep.V02 == true && currentStep.V15 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M02);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V03 == true && currentStep.V15 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M03);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V04 == true && currentStep.V16 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M04);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V05 == true && currentStep.V16 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M05);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V06 == true && currentStep.V17 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M06);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V07 == true && currentStep.V17 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M07);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V08 == true && currentStep.V18 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M08);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V09 == true && currentStep.V18 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M09);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V10 == true && currentStep.V19 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M10);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V11 == true && currentStep.V19 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M11);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }
                if (currentStep.V12 == true && currentStep.V20 == true)
                {
                    float? targetValue = getTargetValue(recipe => recipe.M12);
                    if (targetValue != null)
                    {
                        totalFlowRate += targetValue.Value;
                    }
                    else
                    {
                        TotalFlowRate = null;
                        return;
                    }
                }

                TotalFlowRate = (int)totalFlowRate;
            }

            public void setCurrentRecipe(Recipe? recipe)
            {
                if (recipe != null)
                {
                    currentStep = recipe;
                    int prevStepIndex = recipe.No - 2;
                    if (0 <= prevStepIndex && prevStepIndex < recipes.Count)
                    {
                        prevStep = recipes[prevStepIndex];
                    }
                    else
                    {
                        prevStep = null;
                    }
                    refreshTotalFlowRate();
                }
                else
                {
                    currentStep = null;
                    prevStep = null;
              
                    TotalFlowRate = null;
                }
            }

            void IObserver<IList<Recipe>>.OnCompleted()
            {
                throw new NotImplementedException();
            }

            void IObserver<IList<Recipe>>.OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            void IObserver<IList<Recipe>>.OnNext(IList<Recipe> newlyAdded)
            {
                foreach (Recipe recipe in newlyAdded)
                {
                    recipe.PropertyChanged += recipePropertyChanged;
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        unsubscriber.Dispose();
                    }

                    // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                    // TODO: 큰 필드를 null로 설정합니다.
                    disposedValue = true;
                }
            }

            void IDisposable.Dispose()
            {
                // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }

            public void dispose()
            {
                Dispose(disposing: true);
            }

            [ObservableProperty]
            private int? _totalRecipeTime = null;
            [ObservableProperty]
            private int? _totalStepNumber = null;
            [ObservableProperty]
            private int? _totalFlowRate = null;

            private Recipe? prevStep = null;
            private Recipe? currentStep = null;

            private RecipeObservableCollection recipes;
            private IDisposable unsubscriber;
            private bool disposedValue = false;
        }
    }
}
