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

using CarterGames.Cart.Core.Management.Editor;
using CarterGames.Cart.Core.MetaData.Editor;
using UnityEditor;

namespace CarterGames.Cart.Core.Logs.Editor
{
    /// <summary>
    /// Handles the settings GUI for the logging system.
    /// </summary>
    public static class LoggingSettingsDrawer
    {
        private static readonly string LoggingExpanded = $"{PerUserSettings.UniqueId}_CarterGames_TheCart_Settings_Core_Logging_Expanded";
        private static readonly string LoggingSettingsExpanded = $"{PerUserSettings.UniqueId}_CarterGames_TheCart_Settings_Core_Logging_SettingsExpanded";
        private static readonly string LoggingCategoriesExpanded = $"{PerUserSettings.UniqueId}_CarterGames_TheCart_Settings_Core_Logging_CategoriesExpanded";


        private static bool IsExpanded
        {
            get => PerUserSettings.GetValue<bool>(LoggingExpanded, SettingType.EditorPref, false);
            set => PerUserSettings.SetValue<bool>(LoggingExpanded, SettingType.EditorPref, value);
        }
        
        
        private static bool IsSettingsExpanded
        {
            get => PerUserSettings.GetValue<bool>(LoggingSettingsExpanded, SettingType.EditorPref, false);
            set => PerUserSettings.SetValue<bool>(LoggingSettingsExpanded, SettingType.EditorPref, value);
        }
        
        
        private static bool IsCategoriesExpanded
        {
            get => PerUserSettings.GetValue<bool>(LoggingCategoriesExpanded, SettingType.EditorPref, false);
            set => PerUserSettings.SetValue<bool>(LoggingCategoriesExpanded, SettingType.EditorPref, value);
        }



        public static void ExpandSection(bool showSettings, bool showCategories)
        {
            IsExpanded = true;
            IsSettingsExpanded = showSettings;
            IsCategoriesExpanded = showCategories;
        }
        
        
        /// <summary>
        /// Draws the settings provider version of the settings.
        /// </summary>
        public static void DrawSettings()
        {
            EditorGUI.BeginChangeCheck();
            
            IsExpanded = EditorGUILayout.Foldout(IsExpanded, Meta.Logs.Content(Meta.SectionTitle));
            
            if (!IsExpanded) return;


            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.Space(1.5f);
            EditorGUI.indentLevel++;
            
            IsSettingsExpanded = EditorGUILayout.Foldout(IsSettingsExpanded, Meta.Logs.Content("sectionSettingsTitle"));

            if (IsSettingsExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");
                
                // Draw the provider enum field on the GUI...
                EditorGUILayout.PropertyField(UtilEditor.SettingsObject.Fp("loggingUseCartLogs"),
                    Meta.Logs.Content("useLogs"));
                EditorGUILayout.PropertyField(UtilEditor.SettingsObject.Fp("useLogsInProductionBuilds"),
                    Meta.Logs.Content("useInProduction"));
                
                EditorGUILayout.EndVertical();
                EditorGUI.indentLevel--;
            }

            IsCategoriesExpanded = EditorGUILayout.Foldout(IsCategoriesExpanded, Meta.Logs.Content("sectionCategoriesTitle"));
            
            if (IsCategoriesExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.BeginVertical("Box");
                
                EditorGUILayout.HelpBox("Toggle categories here to define if logs of that type appear in the console.", MessageType.Info);
                
                LogCategoryDrawer.DrawLogCategories();
                
                EditorGUILayout.EndVertical();
                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.Space(1.5f);
            EditorGUILayout.EndVertical();
        }


        /// <summary>
        /// Draws the inspector version of the settings.
        /// </summary>
        /// <param name="serializedObject">The target object</param>
        public static void DrawInspector(SerializedObject serializedObject)
        {
            EditorGUILayout.BeginVertical("HelpBox");
            
            EditorGUILayout.LabelField(Meta.Logs.Labels[Meta.SectionTitle], EditorStyles.boldLabel);
            GeneralUtilEditor.DrawHorizontalGUILine();
            
            EditorGUILayout.PropertyField(serializedObject.Fp("loggingUseCartLogs"), Meta.Logs.Content("useLogs"));
            EditorGUILayout.PropertyField(serializedObject.Fp("useLogsInProductionBuilds"), Meta.Logs.Content("useInProduction"));

            EditorGUILayout.EndVertical();
        }
    }
}