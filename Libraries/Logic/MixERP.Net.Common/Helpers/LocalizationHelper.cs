﻿/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Compilation;

namespace MixERP.Net.Common.Helpers
{
    public static class LocalizationHelper
    {
        public static void AddResourceString(string path, string key, string value)
        {
            using (ResXResourceReader reader = new ResXResourceReader(path))
            {
                reader.UseResXDataNodes = true;

                Hashtable resources = new Hashtable();

                using (ResXResourceWriter writer = new ResXResourceWriter(path))
                {
                    ITypeResolutionService iResoulution = null;

                    foreach (DictionaryEntry entry in reader)
                    {
                        if (entry.Value == null)
                        {
                            resources.Add(entry.Key.ToString(), "");
                        }
                        else
                        {
                            // ReSharper disable once ExpressionIsAlwaysNull
                            resources.Add(entry.Key.ToString(),
                                ((ResXDataNode)entry.Value).GetValue(iResoulution).ToString());
                        }

                        ResXDataNode dataNode = (ResXDataNode)entry.Value;

                        if (dataNode != null)
                        {
                            writer.AddResource(dataNode);
                        }
                    }

                    if (!resources.ContainsKey(key))
                    {
                        writer.AddResource(key, value);
                    }

                    writer.Generate();
                }
            }
        }

        public static int GetCurrencyDecimalPlaces()
        {
            CultureInfo culture = GetCurrentCulture();
            return culture.NumberFormat.CurrencyDecimalDigits;
        }

        public static CultureInfo GetCurrentCulture()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            return culture;
        }

        public static string GetDecimalSeparator()
        {
            CultureInfo culture = GetCurrentCulture();
            return culture.NumberFormat.CurrencyDecimalSeparator;
        }

        public static string GetDefaultAssemblyResourceString(string className, string key)
        {
            if (string.IsNullOrWhiteSpace(key) || HttpContext.Current == null)
            {
                return string.Empty;
            }

            try
            {
                var globalResourceObject = HttpContext.GetGlobalResourceObject(className, key, GetCurrentCulture());

                if (globalResourceObject != null)
                {
                    return globalResourceObject.ToString();
                }

                return string.Empty;
            }
            catch
            {
                throw new InvalidOperationException("Resource could not be found for the key " + key + " on class " +
                                                    className + " .");
            }
        }

        public static int GetNumberDecimalPlaces()
        {
            CultureInfo culture = GetCurrentCulture();
            return culture.NumberFormat.NumberDecimalDigits;
        }

        public static string GetResourceString(Assembly assembly, string fullyQualifiedClassName, string key)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            var baseType = BuildManager.GetGlobalAsaxType().BaseType;

            if (baseType != null && baseType.Assembly.Equals(assembly))
            {
                return GetDefaultAssemblyResourceString(UnqualifyResourceNamespace(assembly, fullyQualifiedClassName), key);
            }

            ResourceManager r = new ResourceManager(fullyQualifiedClassName, assembly);
            string value;

            try
            {
                value = r.GetString(key, GetCurrentCulture());

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Resource could not be found for the key " + key + " on Class " +
                                                        fullyQualifiedClassName + " on Assembly " +
                                                        assembly.GetName().Name);
                }
            }
            catch (MissingManifestResourceException)
            {
                throw new InvalidOperationException("Resource could not be found for the key " + key + " on Class " +
                                                    fullyQualifiedClassName + " on Assembly " + assembly.GetName().Name);
            }

            return value;
        }

        public static string GetShortDateFormat()
        {
            CultureInfo culture = GetCurrentCulture();
            return culture.DateTimeFormat.ShortDatePattern;
        }

        public static string GetThousandSeparator()
        {
            CultureInfo culture = GetCurrentCulture();
            return culture.NumberFormat.CurrencyGroupSeparator;
        }

        private static string UnqualifyResourceNamespace(Assembly assembly, string fullyQualifiedClassName)
        {
            return fullyQualifiedClassName.Replace(assembly.GetName().Name + ".Resources.", "");
        }
    }
}