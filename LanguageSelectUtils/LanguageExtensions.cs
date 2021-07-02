using System;
using System.Linq;
using LanguageSelectUitil;
using LanguageSelectUitils;

namespace LanguageSelectUtils
{
    public static class LanguageExtensions
    {
        /// <summary>
        /// 從 model中取得指定的 language field，如果找不到或得到空值，值回傳 default language 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string GetName(this object model, LanguageEnum language)
        {
            var name = model.GetType().GetProperties()
                .Select(x => (property: x, language: Attribute.GetCustomAttribute(x, typeof(LanguageAttribute))))
                .Where(x => (x.language as LanguageAttribute)?.Language == language)
                .Select(x => x.property.GetValue(model)?.ToString())
                .FirstOrDefault() ?? "";


            return language == LanguageEnum.En || !string.IsNullOrEmpty(name)
                ? name
                : model.GetName(LanguageEnum.En);
        }
    }
}