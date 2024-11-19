﻿#if CARTERGAMES_CART_MODULE_NOTIONDATA && UNITY_EDITOR

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
using CarterGames.Cart.Core.Data;
using CarterGames.Cart.ThirdParty;

namespace CarterGames.Cart.Modules.NotionData.Editor
{
	/// <summary>
	/// A data class for the info of a request as it is being processed.
	/// </summary>
	public sealed class NotionRequestData
	{
		private readonly string apiKey;

		private readonly string databaseId;
		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Fields
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */

		private readonly DataAsset requestingAsset;
		private readonly bool silentCall;
		private readonly NotionSortProperty[] sorts;
		private NotionRequestResult resultData;

		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Constructor
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */

		/// <summary>
		/// Creates a new request data class instance when called.
		/// </summary>
		/// <param name="requestingAsset">The asset to use.</param>
		/// <param name="databaseId">The database id to get.</param>
		/// <param name="apiKey">The api key to get.</param>
		/// <param name="sorts">The sorting properties to apply.</param>
		/// <param name="silentResponse">Should the response from the request be hidden from the user? DEF = false</param>
		public NotionRequestData(DataAsset requestingAsset, string databaseId, string apiKey, NotionSortProperty[] sorts, bool silentResponse = false)
		{
			this.requestingAsset = requestingAsset;
			this.databaseId = databaseId;
			this.apiKey = apiKey;
			this.sorts = sorts;
			silentCall = silentResponse;
		}

		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Properties
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */

		/// <summary>
		/// The data asset the request is for.
		/// </summary>
		public DataAsset RequestingAsset => requestingAsset;


		/// <summary>
		/// The url for the call.
		/// </summary>
		public string Url => $"https://api.notion.com/{DataAccess.GetAsset<DataAssetSettingsNotionData>().NotionApiVersion.ToString()}/databases/{databaseId}/query";


		/// <summary>
		/// The api key for the database to be accessed with.
		/// </summary>
		public string ApiKey => apiKey;


		/// <summary>
		/// The sorting to apply on requesting the data from the database.
		/// </summary>
		public NotionSortProperty[] Sorts => sorts;


		/// <summary>
		/// The result of the request.
		/// </summary>
		public NotionRequestResult ResultData => resultData;


		/// <summary>
		/// Should the dialogues show for this request?
		/// </summary>
		public bool ShowResponseDialogue => !silentCall;

		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Methods
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */

		/// <summary>
		/// Appends the data with more info when called (when over 100 entries etc).
		/// </summary>
		/// <param name="data">The data to add.</param>
		public void AppendResultData(List<KeyValuePair<string, JSONNode>> data)
		{
			if (resultData == null)
			{
				resultData = new NotionRequestResult(data, silentCall);
			}
			else
			{
				resultData.Data.AddRange(data);
			}
		}
	}
}

#endif