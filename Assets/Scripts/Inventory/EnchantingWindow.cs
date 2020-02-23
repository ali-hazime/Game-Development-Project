using System;
using System.Collections.Generic;
using UnityEngine;

public class EnchantingWindow : MonoBehaviour
{ 
	[SerializeField] EnchantingUI recipeUIPrefab;
	[SerializeField] RectTransform recipeUIParent;
	[SerializeField] List<EnchantingUI> enchantingRecipeUIs;

	public ItemContainer ItemContainer;
	public List<EnchantingRecipe> EnchantingRecipes;

	public event Action<BaseItemSlots> OnPointerEnterEvent;
	public event Action<BaseItemSlots> OnPointerExitEvent;

	private void OnValidate()
	{
		Init();
	}

	private void Awake()
	{
		Init();

		foreach (EnchantingUI enchantingRecipeUI in enchantingRecipeUIs)
		{
			enchantingRecipeUI.OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
			enchantingRecipeUI.OnPointerExitEvent += slot => OnPointerExitEvent(slot);
		}
	}

	private void Init()
	{
		recipeUIParent.GetComponentsInChildren<EnchantingUI>(includeInactive: true, result: enchantingRecipeUIs);
		UpdateEnchantingRecipes();
	}

	public void UpdateEnchantingRecipes()
	{
		for (int i = 0; i < EnchantingRecipes.Count; i++)
		{
			if (enchantingRecipeUIs.Count == i)
			{
				enchantingRecipeUIs.Add(Instantiate(recipeUIPrefab, recipeUIParent, false));
			}
			else if (enchantingRecipeUIs[i] == null)
			{
				enchantingRecipeUIs[i] = Instantiate(recipeUIPrefab, recipeUIParent, false);
			}

			enchantingRecipeUIs[i].ItemContainer = ItemContainer;
			enchantingRecipeUIs[i].EnchantingRecipe = EnchantingRecipes[i];
		}

		for (int i = EnchantingRecipes.Count; i < enchantingRecipeUIs.Count; i++)
		{
			enchantingRecipeUIs[i].EnchantingRecipe = null;
		}
	}
}
