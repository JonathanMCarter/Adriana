﻿/*
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

using System;

namespace CarterGames.Cart.Modules
{
	public sealed class ModuleDataValues : IModule
	{
		/* ─────────────────────────────────────────────────────────────────────────────────────────────────────────────
		|   Properties
		───────────────────────────────────────────────────────────────────────────────────────────────────────────── */
        
		/// <summary>
		/// The name of the module.
		/// </summary>
		public string ModuleName => "Data Values";
        
        
		/// <summary>
		/// A description of what the module does.
		/// </summary>
		public string ModuleDescription => "A system to use scriptable objects for variables, lists, events etc. Handy for some code simplifying.";
        
        
		public string ModuleAuthor => "Carter Games";


		/// <summary>
		/// Any modules that are required for the module to work.
		/// </summary>
		public IModule[] PreRequisites => Array.Empty<IModule>();
        
		public IModule[] OptionalPreRequisites => Array.Empty<IModule>();
        
        
		public string ModuleDefine => "CARTERGAMES_CART_MODULE_DATAVALUES";
	}
}