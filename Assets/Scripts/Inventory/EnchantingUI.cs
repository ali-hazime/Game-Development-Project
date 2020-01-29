using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantingUI : MonoBehaviour
{ 
    [SerializeField] RectTransform arrowParent;
    [SerializeField] BaseItemSlots[] itemSlots;

    public ItemContainer ItemContainer;

    private EnchantingRecipe enchantingRecipe;

    public EnchantingRecipe EnchantingRecipe
    {
        get { return enchantingRecipe; }
        set { SetEnchantingRecipe(value); }
    }

    public event Action<BaseItemSlots> OnPointerEnterEvent;
    public event Action<BaseItemSlots> OnPointerExitEvent;

    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<BaseItemSlots>(includeInactive: true);
    }

    private void Start()
    {
        foreach (BaseItemSlots itemSlot in itemSlots)
        {
            itemSlot.OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlot.OnPointerExitEvent += OnPointerExitEvent;
        }
    }

    public void OnEnchantButtonClick()
    {
        enchantingRecipe.Enchant(ItemContainer);
    }

    private void SetEnchantingRecipe(EnchantingRecipe newEnchantingRecipe)
    {
        enchantingRecipe = newEnchantingRecipe;

        if (enchantingRecipe != null)
        {
            int slotIndex = 0;
            slotIndex = SetSlots(enchantingRecipe.Materials, slotIndex);
            arrowParent.SetSiblingIndex(slotIndex);
            slotIndex = SetSlots(enchantingRecipe.Results, slotIndex);

            for (int i = slotIndex; i < itemSlots.Length; i++)
            {
                itemSlots[i].transform.parent.gameObject.SetActive(false);
            }

            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
    {
        for (int i = 0; i < itemAmountList.Count; i++, slotIndex++)
        {
            ItemAmount itemAmount = itemAmountList[i];
            BaseItemSlots itemSlot = itemSlots[slotIndex];

            itemSlot.Item = itemAmount.Item;
            itemSlot.Amount = itemAmount.Amount;
            itemSlot.transform.parent.gameObject.SetActive(true);
        }
        return slotIndex;
    }

}
