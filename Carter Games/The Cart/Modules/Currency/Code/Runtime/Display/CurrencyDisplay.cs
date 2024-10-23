﻿#if CARTERGAMES_CART_MODULE_CURRENCY

/*
 * Copyright (c) 2024 Carter Games
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using CarterGames.Cart.Core;
using TMPro;
using UnityEngine;

namespace CarterGames.Cart.Modules.Currency
{
    public class CurrencyDisplay : MonoBehaviour
    {
        [SerializeField] private string accountId;
        [SerializeField] private TMP_Text label;


        public bool InSync => CurrencyManager.GetBalance(accountId).DoubleEquals(LastBalanceShown);
        private double LastBalanceShown { get; set; }
        

        private void OnEnable()
        {
            CurrencyManager.AccountBalanceChanged.Add(UpdateDisplay);
            UpdateDisplay(CurrencyManager.GetAccount(accountId));
        }


        private void UpdateDisplay(CurrencyAccount account)
        {
            label.SetText(account.Balance.Format<MoneyFormatterGeneric>());
        }


        public void UpdateDisplayManually(double valueToDisplay)
        {
            label.SetText(valueToDisplay.Format<MoneyFormatterGeneric>());
        }
    }
}

#endif