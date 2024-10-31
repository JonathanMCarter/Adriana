﻿#if CARTERGAMES_CART_MODULE_COLORFOLDERS

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

using System.Collections.Generic;
using System.Linq;
using CarterGames.TheCart.Core.Editor;

namespace CarterGames.Cart.Modules.ColourFolders.Editor
{
	/// <summary>
	/// A search provider for the folder color options.
	/// </summary>
	public sealed class SearchProviderFolderOptions : SearchProvider<DataFolderIconSet>
	{
		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Fields
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */
		
		private static SearchProviderFolderOptions Instance;
		
		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   SearchProvider Implementation
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */
		
		public override string ProviderTitle => "Folder Style Options";
		
		
		public override List<SearchGroup<DataFolderIconSet>> GetEntriesToDisplay()
		{
			var list = new List<SearchGroup<DataFolderIconSet>>();
			var items = new List<SearchItem<DataFolderIconSet>>();

			foreach (var folderIconSet in ColourFolderManager.folderIconsAsset.FolderGraphics.OrderBy(t => t.Id))
			{
				items.Add(SearchItem<DataFolderIconSet>.Set(folderIconSet.Id, folderIconSet));
			}

			list.Add(new SearchGroup<DataFolderIconSet>(items));
			
			return list;
		}
		
		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Helper Methods
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */
		
		public static SearchProviderFolderOptions GetProvider()
		{
			if (Instance == null)
			{
				Instance = CreateInstance<SearchProviderFolderOptions>();
			}

			return Instance;
		}
	}
}

#endif